using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Linq;

namespace FaturaKasaSistemi
{
    public partial class CustomerForm : Form
    {
        private List<IlceModel> ilceList = new List<IlceModel>();
        private Dictionary<string, List<string>> ilIlceDict = new Dictionary<string, List<string>>();

        public CustomerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.ClientSize = new System.Drawing.Size(474, 320);
            LoadIlIlceData();
            LoadIller();
            cmbIl.SelectedIndexChanged += cmbIl_SelectedIndexChanged;
            this.Load += CustomerForm_Load;
            this.Resize += CustomerForm_Resize;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            UpdateWindowButtons();
        }
        private void CustomerForm_Resize(object sender, EventArgs e)
        {
            UpdateWindowButtons();
        }
        private void UpdateWindowButtons()
        {
            int padding = 10;
            int btnW = 30, btnH = 30;
            btnClose.Size = btnMinimize.Size = new System.Drawing.Size(btnW, btnH);
            btnClose.Location = new System.Drawing.Point(this.ClientSize.Width - btnW - padding, padding);
            btnMinimize.Location = new System.Drawing.Point(this.ClientSize.Width - 2 * btnW - 2 * padding, padding);
            btnClose.BringToFront();
            btnMinimize.BringToFront();
        }

        private void LoadIlIlceData()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string ilceJsonPath = Path.Combine(basePath, "turkiye_ilce.json");
                string ilceJson = File.ReadAllText(ilceJsonPath);
                ilceList = JsonConvert.DeserializeObject<List<IlceModel>>(ilceJson);
                ilIlceDict = new Dictionary<string, List<string>>();
                foreach (var ilce in ilceList)
                {
                    string sehirKey = ilce.ilce_sehirkey;
                    if (!ilIlceDict.ContainsKey(sehirKey))
                        ilIlceDict[sehirKey] = new List<string>();
                    ilIlceDict[sehirKey].Add(ilce.ilce_title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İl-İlçe verisi yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void LoadIller()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string ilJsonPath = Path.Combine(basePath, "turkiye_il.json");
                string ilJson = File.ReadAllText(ilJsonPath);
                var iller = JsonConvert.DeserializeObject<List<IlModel>>(ilJson);
                cmbIl.DataSource = iller.Select(x => x.sehir_title).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İl verisi yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Items.Clear();
            if (cmbIl.SelectedItem != null && ilIlceDict != null)
            {
                string seciliIlAd = cmbIl.SelectedItem.ToString();
                var seciliIl = (from il in LoadIllerList() where il.sehir_title == seciliIlAd select il).FirstOrDefault();
                if (seciliIl != null && ilIlceDict.ContainsKey(seciliIl.sehir_key))
                {
                    cmbIlce.Items.AddRange(ilIlceDict[seciliIl.sehir_key].ToArray());
                }
            }
        }

        private List<IlModel> LoadIllerList()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string ilJsonPath = Path.Combine(basePath, "turkiye_il.json");
            string ilJson = File.ReadAllText(ilJsonPath);
            return JsonConvert.DeserializeObject<List<IlModel>>(ilJson);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || 
                cmbIl.SelectedItem == null || cmbIlce.SelectedItem == null || string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer yeniMusteri = new Customer
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                City = cmbIl.SelectedItem.ToString(),
                District = cmbIlce.SelectedItem.ToString(),
                Address = txtAddress.Text,
                CreatedAt = DateTime.Now
            };

            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO customers (first_name, last_name, card_number, card_type, city, district, address_line, created_at) 
                               VALUES (@first, @last, '', '', @city, @district, @address, @created_at)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", yeniMusteri.FirstName);
                        cmd.Parameters.AddWithValue("@last", yeniMusteri.LastName);
                        cmd.Parameters.AddWithValue("@city", yeniMusteri.City);
                        cmd.Parameters.AddWithValue("@district", yeniMusteri.District);
                        cmd.Parameters.AddWithValue("@address", yeniMusteri.Address);
                        cmd.Parameters.AddWithValue("@created_at", yeniMusteri.CreatedAt);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void CustomerForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        public class IlModel
        {
            public string sehir_key { get; set; }
            public string sehir_title { get; set; }
        }
        public class IlceModel
        {
            public string ilce_key { get; set; }
            public string ilce_title { get; set; }
            public string ilce_sehirkey { get; set; }
        }
    }
} 