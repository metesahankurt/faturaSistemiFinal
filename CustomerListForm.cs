using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace FaturaKasaSistemi
{
    public partial class CustomerListForm : Form
    {
        public CustomerListForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            string connectionString = DbConfig.ConnectionString;
            string query = "SELECT id, first_name, last_name, city, district, address_line FROM customers";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dataGridView1.Columns["id"] != null) dataGridView1.Columns["id"].HeaderText = "ID";
                if (dataGridView1.Columns["first_name"] != null) dataGridView1.Columns["first_name"].HeaderText = "Ad";
                if (dataGridView1.Columns["last_name"] != null) dataGridView1.Columns["last_name"].HeaderText = "Soyad";
                if (dataGridView1.Columns["city"] != null) dataGridView1.Columns["city"].HeaderText = "İl";
                if (dataGridView1.Columns["district"] != null) dataGridView1.Columns["district"].HeaderText = "İlçe";
                if (dataGridView1.Columns["address_line"] != null) dataGridView1.Columns["address_line"].HeaderText = "Adres";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridView1.SelectedRows[0];
            int customerId = Convert.ToInt32(row.Cells["id"].Value);
            string customerName = row.Cells["first_name"].Value + " " + row.Cells["last_name"].Value;

            // Müşteri bir faturada kullanılmış mı kontrol et
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM invoices WHERE customer_name = @name";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@name", customerName);
                    int kullanilmaSayisi = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (kullanilmaSayisi > 0)
                    {
                        var result = MessageBox.Show(
                            "Bu müşteri bir faturada kullanılmış.\nYine de silmek ister misiniz? (Bu müşteriyle ilgili tüm faturalar ve satırları da silinecek!)",
                            "Uyarı",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            // Önce ilgili faturaların satırlarını sil
                            string delItems = "DELETE ii FROM invoice_items ii JOIN invoices f ON ii.invoice_id = f.id WHERE f.customer_name = @name";
                            using (MySqlCommand delItemsCmd = new MySqlCommand(delItems, conn))
                            {
                                delItemsCmd.Parameters.AddWithValue("@name", customerName);
                                delItemsCmd.ExecuteNonQuery();
                            }
                            // Sonra faturaları sil
                            string delInvoices = "DELETE FROM invoices WHERE customer_name = @name";
                            using (MySqlCommand delInvCmd = new MySqlCommand(delInvoices, conn))
                            {
                                delInvCmd.Parameters.AddWithValue("@name", customerName);
                                delInvCmd.ExecuteNonQuery();
                            }
                            // Son olarak müşteriyi sil
                            string delCustomer = "DELETE FROM customers WHERE id = @id";
                            using (MySqlCommand delCustCmd = new MySqlCommand(delCustomer, conn))
                            {
                                delCustCmd.Parameters.AddWithValue("@id", customerId);
                                delCustCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Müşteri ve ilgili tüm faturalar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomers();
                        }
                        return;
                    }
                }
            }

            var result2 = MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result2 == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM customers WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
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
        private void CustomerListForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
    }
} 