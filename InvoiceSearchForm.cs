using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font;
using System.Diagnostics;

namespace FaturaKasaSistemi
{
    public partial class InvoiceSearchForm : Form
    {
        public InvoiceSearchForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            string invoiceNo = txtInvoiceNo.Text.Trim();
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;
            string connectionString = DbConfig.ConnectionString;
            string query = "SELECT invoice_no, customer_name, invoice_date, subtotal, vat, total FROM invoices WHERE 1=1";
            if (!string.IsNullOrEmpty(customerName))
                query += " AND customer_name LIKE @customerName";
            if (!string.IsNullOrEmpty(invoiceNo))
                query += " AND invoice_no LIKE @invoiceNo";
            query += " AND DATE(invoice_date) >= @startDate AND DATE(invoice_date) <= @endDate";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                if (!string.IsNullOrEmpty(customerName))
                    adapter.SelectCommand.Parameters.AddWithValue("@customerName", "%" + customerName + "%");
                if (!string.IsNullOrEmpty(invoiceNo))
                    adapter.SelectCommand.Parameters.AddWithValue("@invoiceNo", "%" + invoiceNo + "%");
                adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dataGridView1.Columns["invoice_no"] != null) dataGridView1.Columns["invoice_no"].HeaderText = "Fatura No";
                if (dataGridView1.Columns["customer_name"] != null) dataGridView1.Columns["customer_name"].HeaderText = "Müşteri";
                if (dataGridView1.Columns["invoice_date"] != null) dataGridView1.Columns["invoice_date"].HeaderText = "Tarih";
                if (dataGridView1.Columns["subtotal"] != null) dataGridView1.Columns["subtotal"].HeaderText = "Ara Toplam";
                if (dataGridView1.Columns["vat"] != null) dataGridView1.Columns["vat"].HeaderText = "KDV";
                if (dataGridView1.Columns["total"] != null) dataGridView1.Columns["total"].HeaderText = "Genel Toplam";
            }
        }

        private void InvoiceSearchForm_Load(object sender, EventArgs e)
        {
            // Varsayılan olarak son 30 günü göster
            dtpEnd.Value = DateTime.Today;
            dtpStart.Value = DateTime.Today.AddDays(-30);
            btnSearch_Click(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string invoiceNo = row.Cells["invoice_no"].Value?.ToString();
                if (!string.IsNullOrEmpty(invoiceNo))
                {
                    InvoiceDetailForm detailForm = new InvoiceDetailForm(invoiceNo);
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridView1.SelectedRows[0];
            string invoiceNo = row.Cells["invoice_no"].Value?.ToString();
            if (string.IsNullOrEmpty(invoiceNo))
            {
                MessageBox.Show("Fatura numarası alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"{invoiceNo} numaralı faturayı silmek istediğinize emin misiniz?\nBu işleme ait tüm satırlar da silinecek!", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string connectionString = DbConfig.ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Önce invoice_items'tan sil
                        string delItems = "DELETE ii FROM invoice_items ii JOIN invoices f ON ii.invoice_id = f.id WHERE f.invoice_no = @invoiceNo";
                        using (MySqlCommand cmd1 = new MySqlCommand(delItems, conn))
                        {
                            cmd1.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                            cmd1.ExecuteNonQuery();
                        }
                        // Sonra faturayı sil
                        string delInvoice = "DELETE FROM invoices WHERE invoice_no = @invoiceNo";
                        using (MySqlCommand cmd2 = new MySqlCommand(delInvoice, conn))
                        {
                            cmd2.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                            cmd2.ExecuteNonQuery();
                        }
                        MessageBox.Show("Fatura ve satırları başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSearch_Click(null, null); // Listeyi güncelle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        private void InvoiceSearchForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen PDF için bir fatura seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridView1.SelectedRows[0];
            string invoiceNo = row.Cells["invoice_no"].Value?.ToString();
            if (string.IsNullOrEmpty(invoiceNo))
            {
                MessageBox.Show("Fatura numarası alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM invoices WHERE invoice_no = @invoiceNo";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Fatura bulunamadı.");
                            return;
                        }
                        string customerName = reader["customer_name"].ToString();
                        DateTime invoiceDate = Convert.ToDateTime(reader["invoice_date"]);
                        decimal subtotal = Convert.ToDecimal(reader["subtotal"]);
                        decimal vat = Convert.ToDecimal(reader["vat"]);
                        decimal total = Convert.ToDecimal(reader["total"]);
                        reader.Close();
                        // Fatura satırlarını çek
                        string itemQuery = "SELECT p.name, ii.quantity, ii.unit_price, ii.vat_rate FROM invoice_items ii JOIN products p ON ii.product_id = p.id JOIN invoices f ON ii.invoice_id = f.id WHERE f.invoice_no = @invoiceNo";
                        using (MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn))
                        {
                            itemCmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                            using (var itemReader = itemCmd.ExecuteReader())
                            {
                                string fileName = $"Fatura_{invoiceNo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                                var fontPath = @"C:\\Windows\\Fonts\\arial.ttf";
                                using (var writer = new PdfWriter(fullPath))
                                using (var pdf = new PdfDocument(writer))
                                {
                                    var font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                                    using (var document = new Document(pdf))
                                    {
                                        document.Add(new Paragraph("FATURA").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetFont(font));
                                        document.Add(new Paragraph($"Müşteri: {customerName}").SetFont(font));
                                        document.Add(new Paragraph($"Tarih: {invoiceDate:dd.MM.yyyy}").SetFont(font));
                                        document.Add(new Paragraph(" ").SetFont(font));
                                        Table table = new Table(new float[] { 3, 1, 2, 1, 2 });
                                        table.SetWidth(UnitValue.CreatePercentValue(100));
                                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ürün Adı").SetFont(font)));
                                        table.AddHeaderCell(new Cell().Add(new Paragraph("Adet").SetFont(font)));
                                        table.AddHeaderCell(new Cell().Add(new Paragraph("Birim Fiyat").SetFont(font)));
                                        table.AddHeaderCell(new Cell().Add(new Paragraph("KDV (%)").SetFont(font)));
                                        table.AddHeaderCell(new Cell().Add(new Paragraph("Tutar").SetFont(font)));
                                        while (itemReader.Read())
                                        {
                                            string pname = itemReader["name"].ToString();
                                            int qty = Convert.ToInt32(itemReader["quantity"]);
                                            decimal unitPrice = Convert.ToDecimal(itemReader["unit_price"]);
                                            decimal vatRate = Convert.ToDecimal(itemReader["vat_rate"]);
                                            decimal lineTotal = unitPrice * qty * (1 + vatRate / 100);
                                            table.AddCell(new Cell().Add(new Paragraph(pname).SetFont(font)));
                                            table.AddCell(new Cell().Add(new Paragraph(qty.ToString()).SetFont(font)));
                                            table.AddCell(new Cell().Add(new Paragraph(unitPrice.ToString("N2") + " ₺").SetFont(font)));
                                            table.AddCell(new Cell().Add(new Paragraph(vatRate.ToString()).SetFont(font)));
                                            table.AddCell(new Cell().Add(new Paragraph(lineTotal.ToString("N2") + " ₺").SetFont(font)));
                                        }
                                        document.Add(table);
                                        document.Add(new Paragraph($"\nAra Toplam: {subtotal:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                                        document.Add(new Paragraph($"KDV: {vat:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                                        document.Add(new Paragraph($"Genel Toplam: {total:N2} ₺").SetTextAlignment(TextAlignment.RIGHT).SetFont(font));
                                    }
                                }
                                if (System.IO.File.Exists(fullPath))
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
                        }
                    }
                }
            }
        }
    }
} 