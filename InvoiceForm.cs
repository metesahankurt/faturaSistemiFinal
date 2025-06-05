using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font;
using System.Runtime.InteropServices;

namespace FaturaKasaSistemi
{
    public partial class InvoiceForm : Form
    {
        private List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

        public InvoiceForm()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCustomers();
            LoadProducts();
        }

        private void LoadCustomers()
        {
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, first_name, last_name, city, district FROM customers";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dt.Columns.Add("display", typeof(string), "first_name + ' ' + last_name");
                        cmbCustomers.DataSource = dt;
                        cmbCustomers.DisplayMember = "display";
                        cmbCustomers.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteri listesi yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem is DataRowView row)
            {
                string city = row["city"].ToString();
                string district = row["district"].ToString();
                lblCustomerDetail.Text = $"{city} / {district}";
            }
            else
            {
                lblCustomerDetail.Text = "";
            }
        }

        private void LoadProducts()
        {
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, name, price, vat_rate FROM products";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbProducts.DataSource = dt;
                        cmbProducts.DisplayMember = "name";
                        cmbProducts.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null) return;
            DataRowView selectedProduct = (DataRowView)cmbProducts.SelectedItem;
            int productId = Convert.ToInt32(selectedProduct["id"]);
            string name = selectedProduct["name"].ToString();
            decimal price = Convert.ToDecimal(selectedProduct["price"]);
            decimal vat = Convert.ToDecimal(selectedProduct["vat_rate"]);
            int quantity = (int)numQuantity.Value;

            // Aynı ürün daha önce eklenmiş mi kontrol et
            var existingItem = invoiceItems.Find(item => item.ProductId == productId && item.UnitPrice == price && item.VatRate == vat);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                invoiceItems.Add(new InvoiceItem
                {
                    ProductId = productId,
                    ProductName = name,
                    UnitPrice = price,
                    VatRate = vat,
                    Quantity = quantity
                });
            }
            RefreshInvoiceItems();
        }

        private void RefreshInvoiceItems()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = invoiceItems;
            // Sütun başlıklarını Türkçe yap
            if (dataGridView1.Columns["ProductId"] != null) dataGridView1.Columns["ProductId"].HeaderText = "Ürün ID";
            if (dataGridView1.Columns["ProductName"] != null) dataGridView1.Columns["ProductName"].HeaderText = "Ürün Adı";
            if (dataGridView1.Columns["UnitPrice"] != null) dataGridView1.Columns["UnitPrice"].HeaderText = "Fiyat";
            if (dataGridView1.Columns["VatRate"] != null) dataGridView1.Columns["VatRate"].HeaderText = "KDV (%)";
            if (dataGridView1.Columns["Quantity"] != null) dataGridView1.Columns["Quantity"].HeaderText = "Miktar";
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0, totalVat = 0, total = 0;
            foreach (var item in invoiceItems)
            {
                decimal Toplam = item.UnitPrice * item.Quantity;
                decimal lineVat = Toplam * item.VatRate / 100;
                subtotal += Toplam;
                totalVat += lineVat;
            }
            total = subtotal + totalVat;
            lblSubtotal.Text = $"Ara Toplam: {subtotal:N2} ₺";
            lblVat.Text = $"KDV: {totalVat:N2} ₺";
            lblTotal.Text = $"Genel Toplam: {total:N2} ₺";
        }

        private string GenerateNextInvoiceNo()
        {
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT invoice_no FROM invoices ORDER BY id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string lastNo = result.ToString();
                        int num = 1;
                        if (lastNo.StartsWith("FAT-") && int.TryParse(lastNo.Substring(4), out num))
                        {
                            num++;
                            return $"FAT-{num:D3}";
                        }
                    }
                }
            }
            return "FAT-001";
        }

        private void SaveInvoice()
        {
            if (cmbCustomers.SelectedItem == null || invoiceItems.Count == 0)
            {
                MessageBox.Show("Lütfen müşteri ve ürün seçiniz.");
                return;
            }
            DataRowView customer = (DataRowView)cmbCustomers.SelectedItem;
            string customerName = customer["first_name"] + " " + customer["last_name"];
            decimal subtotal = 0, totalVat = 0, total = 0;
            foreach (var item in invoiceItems)
            {
                decimal Toplam = item.UnitPrice * item.Quantity;
                decimal lineVat = Toplam * item.VatRate / 100;
                subtotal += Toplam;
                totalVat += lineVat;
            }
            total = subtotal + totalVat;
            string invoiceNo = GenerateNextInvoiceNo();
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string insertInvoice = "INSERT INTO invoices (customer_name, invoice_date, subtotal, vat, total, invoice_no) VALUES (@customer, NOW(), @subtotal, @vat, @total, @invoice_no)";
                using (MySqlCommand cmd = new MySqlCommand(insertInvoice, conn))
                {
                    cmd.Parameters.AddWithValue("@customer", customerName);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@vat", totalVat);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@invoice_no", invoiceNo);
                    cmd.ExecuteNonQuery();
                }
                // Son eklenen fatura id'sini al
                long invoiceId = cmdLastId(conn);
                // Fatura satırlarını ekle
                foreach (var item in invoiceItems)
                {
                    string insertItem = "INSERT INTO invoice_items (invoice_id, product_id, quantity, unit_price, vat_rate) VALUES (@invoice_id, @product_id, @quantity, @unit_price, @vat_rate)";
                    using (MySqlCommand cmd = new MySqlCommand(insertItem, conn))
                    {
                        cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        cmd.Parameters.AddWithValue("@product_id", item.ProductId);
                        cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@unit_price", item.UnitPrice);
                        cmd.Parameters.AddWithValue("@vat_rate", item.VatRate);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show($"Fatura başarıyla kaydedildi. Fatura No: {invoiceNo}");
        }

        private long cmdLastId(MySqlConnection conn)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
            {
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            SaveInvoice();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (invoiceItems.Count == 0)
            {
                MessageBox.Show("Önce faturayı kaydedin.");
                return;
            }
            DataRowView? customer = cmbCustomers.SelectedItem as DataRowView;
            string firstName = customer?["first_name"]?.ToString() ?? "";
            string lastName = customer?["last_name"]?.ToString() ?? "";
            string fileName = $"Fatura_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            try
            {
                var fontPath = @"C:\\Windows\\Fonts\\arial.ttf";
                using (var writer = new iText.Kernel.Pdf.PdfWriter(fullPath))
                using (var pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                {
                    var font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                    using (var document = new iText.Layout.Document(pdf))
                    {
                        document.Add(new Paragraph("FATURA").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetFont(font));
                        document.Add(new Paragraph($"Müşteri: {firstName} {lastName}").SetFont(font));
                        document.Add(new Paragraph($"Tarih: {DateTime.Now:dd.MM.yyyy}").SetFont(font));
                        document.Add(new Paragraph(" ").SetFont(font));

                        // Tablo başlıkları
                        Table table = new Table(new float[] { 3, 1, 2, 1, 2 });
                        table.SetWidth(UnitValue.CreatePercentValue(100));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ürün Adı").SetFont(font)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Adet").SetFont(font)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Birim Fiyat").SetFont(font)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("KDV (%)").SetFont(font)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Tutar").SetFont(font)));

                        // Ürünler
                        foreach (var item in invoiceItems)
                        {
                            table.AddCell(new Cell().Add(new Paragraph((item.ProductName ?? "-").ToString()).SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph(item.Quantity.ToString()).SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph(item.UnitPrice.ToString("C2")).SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph(item.VatRate.ToString()).SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph((item.UnitPrice * item.Quantity * (1 + item.VatRate / 100)).ToString("C2")).SetFont(font)));
                        }
                        document.Add(table);

                        // Toplamlar
                        decimal subtotal = 0, totalVat = 0, total = 0;
                        foreach (var item in invoiceItems)
                        {
                            decimal Toplam = item.UnitPrice * item.Quantity;
                            decimal lineVat = Toplam * item.VatRate / 100;
                            subtotal += Toplam;
                            totalVat += lineVat;
                        }
                        total = subtotal + totalVat;
                        document.Add(new Paragraph($"\nAra Toplam: {subtotal:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                        document.Add(new Paragraph($"KDV: {totalVat:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                        document.Add(new Paragraph($"Genel Toplam: {total:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                    }
                }
                if (File.Exists(fullPath))
                {
                    MessageBox.Show($"PDF başarıyla oluşturuldu: {fullPath}\nOtomatik olarak açılıyor.");
                    try
                    {
                        Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show($"PDF dosyası oluşturuldu fakat otomatik açılamadı. Dosya: {fullPath}\nHata: {ex2.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"PDF dosyası oluşturulamadı! Lütfen klasörü ve izinleri kontrol edin.\nBeklenen yol: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken hata oluştu: " + ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var pen = new Pen(System.Drawing.Color.RoyalBlue, 3))
            {
                int y = btnMinimize.Height - 10;
                g.DrawLine(pen, 8, y, btnMinimize.Width - 8, y);
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void InvoiceForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private class InvoiceItem
        {
            public int ProductId { get; set; }
            public string? ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal VatRate { get; set; }
            public int Quantity { get; set; }
            public decimal Toplam => UnitPrice * Quantity * (1 + VatRate / 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
} 