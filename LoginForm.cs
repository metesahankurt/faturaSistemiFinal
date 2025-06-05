using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FaturaKasaSistemi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = DbConfig.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, first_name, last_name, username, password, created_at FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // OOP: User nesnesi oluşturuluyor
                                User girisYapanKullanici = new User
                                {
                                    Id = reader.GetInt32("id"),
                                    FirstName = reader.GetString("first_name"),
                                    LastName = reader.GetString("last_name"),
                                    Username = reader.GetString("username"),
                                    Password = reader.GetString("password"),
                                    CreatedAt = reader.GetDateTime("created_at")
                                };
                                // İleride kullanmak için bir static değişkende veya ana formda saklanabilir
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 