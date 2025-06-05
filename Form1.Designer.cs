namespace FaturaKasaSistemi;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button btnProductForm;
    private System.Windows.Forms.Button btnInvoiceForm;
    private System.Windows.Forms.Button btnCustomerForm;
    private System.Windows.Forms.Button btnKasaRaporu;
    private System.Windows.Forms.Button btnInvoiceSearch;
    private System.Windows.Forms.Button btnCustomerList;
    private System.Windows.Forms.Panel pnlRight;
    private System.Windows.Forms.Label lblWelcome;
    private System.Windows.Forms.Label lblDateTime;
    private System.Windows.Forms.Panel pnlCounterMusteri;
    private System.Windows.Forms.Panel pnlCounterUrun;
    private System.Windows.Forms.Panel pnlCounterFatura;
    private System.Windows.Forms.Panel pnlCounterSatis;
    private System.Windows.Forms.Label lblCounterMusteri;
    private System.Windows.Forms.Label lblCounterUrun;
    private System.Windows.Forms.Label lblCounterFatura;
    private System.Windows.Forms.Label lblCounterSatis;
    private System.Windows.Forms.Panel pnlInfo;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnMinimize;
    private System.Windows.Forms.Panel pnlLeft;
    private System.Windows.Forms.Timer clockTimer;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        btnProductForm = new Button();
        btnInvoiceForm = new Button();
        btnCustomerForm = new Button();
        btnKasaRaporu = new Button();
        btnInvoiceSearch = new Button();
        btnCustomerList = new Button();
        pnlRight = new Panel();
        btnAddItem = new Button();
        lblWelcome = new Label();
        lblDateTime = new Label();
        btnMinimize = new Button();
        btnClose = new Button();
        pnlCounterMusteri = new Panel();
        lblCounterMusteri = new Label();
        lblMusteri = new Label();
        pnlCounterUrun = new Panel();
        lblCounterUrun = new Label();
        lblUrun = new Label();
        pnlCounterFatura = new Panel();
        lblCounterFatura = new Label();
        lblFatura = new Label();
        pnlCounterSatis = new Panel();
        lblCounterSatis = new Label();
        lblSatis = new Label();
        pnlInfo = new Panel();
        lblInfo = new Label();
        pnlLeft = new Panel();
        clockTimer = new System.Windows.Forms.Timer(components);
        pnlRight.SuspendLayout();
        pnlCounterMusteri.SuspendLayout();
        pnlCounterUrun.SuspendLayout();
        pnlCounterFatura.SuspendLayout();
        pnlCounterSatis.SuspendLayout();
        pnlInfo.SuspendLayout();
        pnlLeft.SuspendLayout();
        SuspendLayout();
        // 
        // btnProductForm
        // 
        resources.ApplyResources(btnProductForm, "btnProductForm");
        btnProductForm.Name = "btnProductForm";
        btnProductForm.UseVisualStyleBackColor = true;
        btnProductForm.Click += btnProductForm_Click;
        // 
        // btnInvoiceForm
        // 
        resources.ApplyResources(btnInvoiceForm, "btnInvoiceForm");
        btnInvoiceForm.Name = "btnInvoiceForm";
        btnInvoiceForm.UseVisualStyleBackColor = true;
        btnInvoiceForm.Click += btnInvoiceForm_Click;
        // 
        // btnCustomerForm
        // 
        resources.ApplyResources(btnCustomerForm, "btnCustomerForm");
        btnCustomerForm.Name = "btnCustomerForm";
        btnCustomerForm.UseVisualStyleBackColor = true;
        btnCustomerForm.Click += btnCustomerForm_Click;
        // 
        // btnKasaRaporu
        // 
        resources.ApplyResources(btnKasaRaporu, "btnKasaRaporu");
        btnKasaRaporu.Name = "btnKasaRaporu";
        btnKasaRaporu.UseVisualStyleBackColor = true;
        btnKasaRaporu.Click += btnKasaRaporu_Click;
        // 
        // btnInvoiceSearch
        // 
        resources.ApplyResources(btnInvoiceSearch, "btnInvoiceSearch");
        btnInvoiceSearch.Name = "btnInvoiceSearch";
        btnInvoiceSearch.UseVisualStyleBackColor = true;
        btnInvoiceSearch.Click += btnInvoiceSearch_Click;
        // 
        // btnCustomerList
        // 
        resources.ApplyResources(btnCustomerList, "btnCustomerList");
        btnCustomerList.Name = "btnCustomerList";
        btnCustomerList.UseVisualStyleBackColor = true;
        btnCustomerList.Click += btnCustomerList_Click;
        // 
        // pnlRight
        // 
        resources.ApplyResources(pnlRight, "pnlRight");
        pnlRight.BackColor = Color.WhiteSmoke;
        pnlRight.Controls.Add(btnAddItem);
        pnlRight.Controls.Add(lblWelcome);
        pnlRight.Controls.Add(lblDateTime);
        pnlRight.Controls.Add(btnMinimize);
        pnlRight.Controls.Add(btnClose);
        pnlRight.Controls.Add(pnlCounterMusteri);
        pnlRight.Controls.Add(pnlCounterUrun);
        pnlRight.Controls.Add(pnlCounterFatura);
        pnlRight.Controls.Add(pnlCounterSatis);
        pnlRight.Controls.Add(pnlInfo);
        pnlRight.Name = "pnlRight";
        // 
        // btnAddItem
        // 
        btnAddItem.BackColor = Color.RoyalBlue;
        btnAddItem.FlatAppearance.BorderSize = 0;
        resources.ApplyResources(btnAddItem, "btnAddItem");
        btnAddItem.ForeColor = Color.White;
        btnAddItem.Name = "btnAddItem";
        btnAddItem.UseVisualStyleBackColor = false;
        btnAddItem.Click += btnAddItem_Click;
        // 
        // lblWelcome
        // 
        resources.ApplyResources(lblWelcome, "lblWelcome");
        lblWelcome.ForeColor = Color.RoyalBlue;
        lblWelcome.Name = "lblWelcome";
        // 
        // lblDateTime
        // 
        resources.ApplyResources(lblDateTime, "lblDateTime");
        lblDateTime.ForeColor = Color.Gray;
        lblDateTime.Name = "lblDateTime";
        // 
        // btnMinimize
        // 
        resources.ApplyResources(btnMinimize, "btnMinimize");
        btnMinimize.BackColor = Color.White;
        btnMinimize.FlatAppearance.BorderColor = Color.White;
        btnMinimize.FlatAppearance.BorderSize = 0;
        btnMinimize.FlatAppearance.MouseDownBackColor = Color.White;
        btnMinimize.FlatAppearance.MouseOverBackColor = Color.White;
        btnMinimize.ForeColor = Color.RoyalBlue;
        btnMinimize.Name = "btnMinimize";
        btnMinimize.TabStop = false;
        btnMinimize.UseVisualStyleBackColor = false;
        btnMinimize.Click += btnMinimize_Click;
        // 
        // btnClose
        // 
        resources.ApplyResources(btnClose, "btnClose");
        btnClose.BackColor = Color.White;
        btnClose.ForeColor = Color.RoyalBlue;
        btnClose.Name = "btnClose";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;
        // 
        // pnlCounterMusteri
        // 
        pnlCounterMusteri.BackColor = Color.White;
        pnlCounterMusteri.BorderStyle = BorderStyle.FixedSingle;
        pnlCounterMusteri.Controls.Add(lblCounterMusteri);
        pnlCounterMusteri.Controls.Add(lblMusteri);
        resources.ApplyResources(pnlCounterMusteri, "pnlCounterMusteri");
        pnlCounterMusteri.Name = "pnlCounterMusteri";
        // 
        // lblCounterMusteri
        // 
        resources.ApplyResources(lblCounterMusteri, "lblCounterMusteri");
        lblCounterMusteri.ForeColor = Color.RoyalBlue;
        lblCounterMusteri.Name = "lblCounterMusteri";
        // 
        // lblMusteri
        // 
        resources.ApplyResources(lblMusteri, "lblMusteri");
        lblMusteri.Name = "lblMusteri";
        // 
        // pnlCounterUrun
        // 
        pnlCounterUrun.BackColor = Color.White;
        pnlCounterUrun.BorderStyle = BorderStyle.FixedSingle;
        pnlCounterUrun.Controls.Add(lblCounterUrun);
        pnlCounterUrun.Controls.Add(lblUrun);
        resources.ApplyResources(pnlCounterUrun, "pnlCounterUrun");
        pnlCounterUrun.Name = "pnlCounterUrun";
        // 
        // lblCounterUrun
        // 
        resources.ApplyResources(lblCounterUrun, "lblCounterUrun");
        lblCounterUrun.ForeColor = Color.RoyalBlue;
        lblCounterUrun.Name = "lblCounterUrun";
        // 
        // lblUrun
        // 
        resources.ApplyResources(lblUrun, "lblUrun");
        lblUrun.Name = "lblUrun";
        // 
        // pnlCounterFatura
        // 
        pnlCounterFatura.BackColor = Color.White;
        pnlCounterFatura.BorderStyle = BorderStyle.FixedSingle;
        pnlCounterFatura.Controls.Add(lblCounterFatura);
        pnlCounterFatura.Controls.Add(lblFatura);
        resources.ApplyResources(pnlCounterFatura, "pnlCounterFatura");
        pnlCounterFatura.Name = "pnlCounterFatura";
        // 
        // lblCounterFatura
        // 
        resources.ApplyResources(lblCounterFatura, "lblCounterFatura");
        lblCounterFatura.ForeColor = Color.RoyalBlue;
        lblCounterFatura.Name = "lblCounterFatura";
        // 
        // lblFatura
        // 
        resources.ApplyResources(lblFatura, "lblFatura");
        lblFatura.Name = "lblFatura";
        // 
        // pnlCounterSatis
        // 
        pnlCounterSatis.BackColor = Color.White;
        pnlCounterSatis.BorderStyle = BorderStyle.FixedSingle;
        pnlCounterSatis.Controls.Add(lblCounterSatis);
        pnlCounterSatis.Controls.Add(lblSatis);
        resources.ApplyResources(pnlCounterSatis, "pnlCounterSatis");
        pnlCounterSatis.Name = "pnlCounterSatis";
        // 
        // lblCounterSatis
        // 
        resources.ApplyResources(lblCounterSatis, "lblCounterSatis");
        lblCounterSatis.ForeColor = Color.RoyalBlue;
        lblCounterSatis.Name = "lblCounterSatis";
        // 
        // lblSatis
        // 
        resources.ApplyResources(lblSatis, "lblSatis");
        lblSatis.Name = "lblSatis";
        // 
        // pnlInfo
        // 
        pnlInfo.BackColor = Color.White;
        pnlInfo.BorderStyle = BorderStyle.FixedSingle;
        pnlInfo.Controls.Add(lblInfo);
        resources.ApplyResources(pnlInfo, "pnlInfo");
        pnlInfo.Name = "pnlInfo";
        // 
        // lblInfo
        // 
        resources.ApplyResources(lblInfo, "lblInfo");
        lblInfo.ForeColor = Color.Gray;
        lblInfo.Name = "lblInfo";
        // 
        // pnlLeft
        // 
        resources.ApplyResources(pnlLeft, "pnlLeft");
        pnlLeft.BackColor = Color.FromArgb(30, 80, 180);
        pnlLeft.Controls.Add(btnProductForm);
        pnlLeft.Controls.Add(btnInvoiceForm);
        pnlLeft.Controls.Add(btnCustomerForm);
        pnlLeft.Controls.Add(btnInvoiceSearch);
        pnlLeft.Controls.Add(btnKasaRaporu);
        pnlLeft.Controls.Add(btnCustomerList);
        pnlLeft.Name = "pnlLeft";
        // 
        // clockTimer
        // 
        clockTimer.Enabled = true;
        clockTimer.Interval = 1000;
        clockTimer.Tick += clockTimer_Tick;
        // 
        // Form1
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(pnlLeft);
        Controls.Add(pnlRight);
        FormBorderStyle = FormBorderStyle.None;
        Name = "Form1";
        pnlRight.ResumeLayout(false);
        pnlCounterMusteri.ResumeLayout(false);
        pnlCounterUrun.ResumeLayout(false);
        pnlCounterFatura.ResumeLayout(false);
        pnlCounterSatis.ResumeLayout(false);
        pnlInfo.ResumeLayout(false);
        pnlLeft.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label lblMusteri;
    private Label lblUrun;
    private Label lblFatura;
    private Label lblSatis;
    private Button btnAddItem;
}
