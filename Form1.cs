namespace FaturaKasaSistemi;
using System.Timers;
using System;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnProductForm_Click(object sender, EventArgs e)
    {
        ProductForm productForm = new ProductForm();
        productForm.ShowDialog();
    }

    private void btnInvoiceForm_Click(object sender, EventArgs e)
    {
        InvoiceForm invoiceForm = new InvoiceForm();
        invoiceForm.ShowDialog();
    }

    private void btnCustomerForm_Click(object sender, EventArgs e)
    {
        CustomerForm customerForm = new CustomerForm();
        customerForm.ShowDialog();
    }

    private void btnKasaRaporu_Click(object sender, EventArgs e)
    {
        KasaRaporuForm kasaRaporuForm = new KasaRaporuForm();
        kasaRaporuForm.ShowDialog();
    }

    private void btnInvoiceSearch_Click(object sender, EventArgs e)
    {
        InvoiceSearchForm searchForm = new InvoiceSearchForm();
        searchForm.ShowDialog();
    }

    private void btnCustomerList_Click(object sender, EventArgs e)
    {
        CustomerListForm customerListForm = new CustomerListForm();
        customerListForm.ShowDialog();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnMinimize_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void btnMinimize_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        using (var pen = new Pen(Color.RoyalBlue, 3))
        {
            int y = btnMinimize.Height - 10;
            g.DrawLine(pen, 8, y, btnMinimize.Width - 8, y);
        }
    }

    private void ApplyMenuButtonStyle(Button btn)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
        btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(60, 120, 255);
        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 120, 255);
        btn.TabStop = false;
        btn.Paint += MenuButton_Paint;
    }

    private void MenuButton_Paint(object sender, PaintEventArgs e)
    {
        // Fokus kutusunu engelle
        Button btn = (Button)sender;
        if (btn.Focused)
        {
            ControlPaint.DrawBorder(e.Graphics, btn.ClientRectangle, btn.BackColor, ButtonBorderStyle.None);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // Responsive sol panel ve butonlar - dikey ortalama
        int leftPanelWidth = 200;
        int leftPanelHeight = this.Height;
        pnlLeft.Width = leftPanelWidth;
        pnlLeft.Height = leftPanelHeight;
        pnlLeft.Location = new System.Drawing.Point(0, 0);
        pnlLeft.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
        System.Windows.Forms.Button[] menuButtons = { btnProductForm, btnInvoiceForm, btnCustomerForm, btnInvoiceSearch, btnKasaRaporu, btnCustomerList };
        int btnCount = menuButtons.Length;
        int btnHeight = 45;
        int totalBtnHeight = btnCount * btnHeight;
        int availableSpace = leftPanelHeight - totalBtnHeight;
        int btnMargin = availableSpace / (btnCount + 1);
        int btnWidth = leftPanelWidth - 40;
        for (int i = 0; i < btnCount; i++)
        {
            var btn = menuButtons[i];
            ApplyMenuButtonStyle(btn);
            btn.BackColor = System.Drawing.Color.RoyalBlue;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btn.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btn.Location = new System.Drawing.Point((leftPanelWidth - btnWidth) / 2, btnMargin + i * (btnHeight + btnMargin));
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.MouseEnter += (s, ev) => { ((System.Windows.Forms.Button)s).BackColor = System.Drawing.Color.FromArgb(60, 120, 255); };
            btn.MouseLeave += (s, ev) => { ((System.Windows.Forms.Button)s).BackColor = System.Drawing.Color.RoyalBlue; };
        }
        // Responsive sağ panel sayaç kutuları
        int rightPanelWidth = pnlRight.Width;
        int counterCount = 4;
        int counterSpacing = 18;
        int totalSpacing = (counterCount + 1) * counterSpacing;
        int counterWidth = (rightPanelWidth - totalSpacing) / counterCount;
        int counterHeight = 90;
        pnlCounterMusteri.Size = pnlCounterUrun.Size = pnlCounterFatura.Size = pnlCounterSatis.Size = new System.Drawing.Size(counterWidth, counterHeight);
        pnlCounterMusteri.Location = new System.Drawing.Point(counterSpacing, 110);
        pnlCounterUrun.Location = new System.Drawing.Point(counterSpacing * 2 + counterWidth * 1, 110);
        pnlCounterFatura.Location = new System.Drawing.Point(counterSpacing * 3 + counterWidth * 2, 110);
        pnlCounterSatis.Location = new System.Drawing.Point(counterSpacing * 4 + counterWidth * 3, 110);
        System.Windows.Forms.Panel[] counters = { pnlCounterMusteri, pnlCounterUrun, pnlCounterFatura, pnlCounterSatis };
        foreach (var c in counters)
        {
            c.BackColor = System.Drawing.Color.White;
            c.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }
        lblCounterMusteri.Font = lblCounterUrun.Font = lblCounterFatura.Font = lblCounterSatis.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblCounterMusteri.ForeColor = lblCounterUrun.ForeColor = lblCounterFatura.ForeColor = lblCounterSatis.ForeColor = System.Drawing.Color.RoyalBlue;
        // Hoşgeldin mesajı ve sayaçlar
        lblWelcome.Text = $"Hoşgeldiniz, admin!";
        lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
        string connStr = DbConfig.ConnectionString;
        using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
        {
            conn.Open();
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM customers", conn))
                lblCounterMusteri.Text = cmd.ExecuteScalar().ToString();
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM products", conn))
                lblCounterUrun.Text = cmd.ExecuteScalar().ToString();
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM invoices", conn))
                lblCounterFatura.Text = cmd.ExecuteScalar().ToString();
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT IFNULL(SUM(total),0) FROM invoices WHERE DATE(invoice_date) = CURDATE()", conn))
            {
                var satis = cmd.ExecuteScalar();
                decimal satisDecimal = 0;
                decimal.TryParse(satis.ToString(), out satisDecimal);
                lblCounterSatis.Text = (Math.Floor(satisDecimal)).ToString("0") + " ₺";
            }
        }
        UpdateWindowButtons();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateWindowButtons();
    }

    private void UpdateWindowButtons()
    {
        int padding = 10;
        int btnW = 30, btnH = 30;
        btnClose.Text = "X";
        btnMinimize.Text = "";
        btnClose.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
        btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
        btnClose.Size = btnMinimize.Size = new System.Drawing.Size(btnW, btnH);
        btnClose.Location = new System.Drawing.Point(this.ClientSize.Width - btnW - padding, padding);
        btnMinimize.Location = new System.Drawing.Point(this.ClientSize.Width - 2 * btnW - 2 * padding, padding);
        btnClose.BackColor = System.Drawing.Color.White;
        btnMinimize.BackColor = System.Drawing.Color.White;
        btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
        btnMinimize.ForeColor = System.Drawing.Color.RoyalBlue;
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClose.BringToFront();
        btnMinimize.BringToFront();
        btnClose.Visible = true;
        btnMinimize.Visible = true;
    }

    private void clockTimer_Tick(object sender, EventArgs e)
    {
        lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        TumSayaClariGuncelle();
    }

    private string FormatNumber(decimal number)
    {
        if (number >= 1_000_000_000)
            return (number / 1_000_000_000M).ToString("0.#") + "B";
        if (number >= 1_000_000)
            return (number / 1_000_000M).ToString("0.#") + "M";
        if (number >= 1_000)
            return (number / 1_000M).ToString("0.#") + "K";
        return number.ToString("0");
    }

    private void TumSayaClariGuncelle()
    {
        string connStr = DbConfig.ConnectionString;
        using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
        {
            conn.Open();
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM customers", conn))
            {
                decimal val = Convert.ToDecimal(cmd.ExecuteScalar());
                lblCounterMusteri.Text = FormatNumber(val);
            }
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM products", conn))
            {
                decimal val = Convert.ToDecimal(cmd.ExecuteScalar());
                lblCounterUrun.Text = FormatNumber(val);
            }
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM invoices", conn))
            {
                decimal val = Convert.ToDecimal(cmd.ExecuteScalar());
                lblCounterFatura.Text = FormatNumber(val);
            }
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT IFNULL(SUM(total),0) FROM invoices WHERE DATE(invoice_date) = CURDATE()", conn))
            {
                var satis = cmd.ExecuteScalar();
                decimal satisDecimal = 0;
                decimal.TryParse(satis.ToString(), out satisDecimal);
                lblCounterSatis.Text = FormatNumber(Math.Floor(satisDecimal)) + " ₺";
            }
        }
    }

    private void btnSatisYenile_Click(object sender, EventArgs e)
    {
        TumSayaClariGuncelle();
    }
}

internal static class NativeMethods
{
    [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
}
