using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace FaturaKasaSistemi
{
    public partial class KasaRaporuForm : Form
    {
        public KasaRaporuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadKasaRaporu();
        }

        private void LoadKasaRaporu()
        {
            string connectionString = DbConfig.ConnectionString;
            DateTime seciliTarih = dtpTarih.Value.Date;
            string query = "SELECT invoice_no, customer_name, invoice_date, subtotal, vat, total FROM invoices WHERE DATE(invoice_date) = @tarih";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@tarih", seciliTarih);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Sütun başlıklarını Türkçeleştir
                if (dataGridView1.Columns["invoice_no"] != null) dataGridView1.Columns["invoice_no"].HeaderText = "Fatura No";
                if (dataGridView1.Columns["customer_name"] != null) dataGridView1.Columns["customer_name"].HeaderText = "Müşteri";
                if (dataGridView1.Columns["invoice_date"] != null) dataGridView1.Columns["invoice_date"].HeaderText = "Tarih";
                if (dataGridView1.Columns["subtotal"] != null) dataGridView1.Columns["subtotal"].HeaderText = "Ara Toplam";
                if (dataGridView1.Columns["vat"] != null) dataGridView1.Columns["vat"].HeaderText = "KDV";
                if (dataGridView1.Columns["total"] != null) dataGridView1.Columns["total"].HeaderText = "Genel Toplam";

                decimal toplamSatis = 0, toplamKdv = 0, genelToplam = 0;
                foreach (DataRow row in dt.Rows)
                {
                    toplamSatis += row["subtotal"] != DBNull.Value ? Convert.ToDecimal(row["subtotal"]) : 0;
                    toplamKdv += row["vat"] != DBNull.Value ? Convert.ToDecimal(row["vat"]) : 0;
                    genelToplam += row["total"] != DBNull.Value ? Convert.ToDecimal(row["total"]) : 0;
                }
                lblToplamSatis.Text = $"Toplam Satış: {toplamSatis:N2} ₺";
                lblToplamKDV.Text = $"Toplam KDV: {toplamKdv:N2} ₺";
                lblGenelToplam.Text = $"Genel Toplam: {genelToplam:N2} ₺";
            }
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            LoadKasaRaporu();
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
        private void KasaRaporuForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
    }
} 