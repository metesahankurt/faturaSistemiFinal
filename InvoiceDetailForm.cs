using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FaturaKasaSistemi
{
    public partial class InvoiceDetailForm : Form
    {
        private string _invoiceNo;
        public InvoiceDetailForm(string invoiceNo)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _invoiceNo = invoiceNo;
        }

        private void InvoiceDetailForm_Load(object sender, EventArgs e)
        {
            string connectionString = DbConfig.ConnectionString;
            string query = @"SELECT p.name AS Urun, ii.quantity AS Miktar, ii.unit_price AS BirimFiyat, ii.vat_rate AS KDV, (ii.quantity * ii.unit_price) AS AraToplam, (ii.quantity * ii.unit_price * ii.vat_rate / 100) AS KDV_Tutar, ((ii.quantity * ii.unit_price) + (ii.quantity * ii.unit_price * ii.vat_rate / 100)) AS Toplam
FROM invoice_items ii
JOIN products p ON ii.product_id = p.id
JOIN invoices f ON ii.invoice_id = f.id
WHERE f.invoice_no = @invoiceNo";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@invoiceNo", _invoiceNo);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
} 