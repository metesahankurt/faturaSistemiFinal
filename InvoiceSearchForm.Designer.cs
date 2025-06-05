namespace FaturaKasaSistemi
{
    partial class InvoiceSearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnExportPdf;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceSearchForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlSearch = new Panel();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblInvoiceNo = new Label();
            txtInvoiceNo = new TextBox();
            lblDateRange = new Label();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            btnSearch = new Button();
            lblArrow = new Label();
            dataGridView1 = new DataGridView();
            btnDeleteInvoice = new Button();
            btnClose = new Button();
            btnMinimize = new Button();
            label1 = new Label();
            btnExportPdf = new Button();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            resources.ApplyResources(pnlSearch, "pnlSearch");
            pnlSearch.BackColor = Color.Transparent;
            pnlSearch.Controls.Add(lblCustomerName);
            pnlSearch.Controls.Add(txtCustomerName);
            pnlSearch.Controls.Add(lblInvoiceNo);
            pnlSearch.Controls.Add(txtInvoiceNo);
            pnlSearch.Controls.Add(lblDateRange);
            pnlSearch.Controls.Add(dtpStart);
            pnlSearch.Controls.Add(dtpEnd);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(lblArrow);
            pnlSearch.Name = "pnlSearch";
            // 
            // lblCustomerName
            // 
            resources.ApplyResources(lblCustomerName, "lblCustomerName");
            lblCustomerName.ForeColor = Color.RoyalBlue;
            lblCustomerName.Name = "lblCustomerName";
            // 
            // txtCustomerName
            // 
            resources.ApplyResources(txtCustomerName, "txtCustomerName");
            txtCustomerName.Name = "txtCustomerName";
            // 
            // lblInvoiceNo
            // 
            resources.ApplyResources(lblInvoiceNo, "lblInvoiceNo");
            lblInvoiceNo.ForeColor = Color.RoyalBlue;
            lblInvoiceNo.Name = "lblInvoiceNo";
            // 
            // txtInvoiceNo
            // 
            resources.ApplyResources(txtInvoiceNo, "txtInvoiceNo");
            txtInvoiceNo.Name = "txtInvoiceNo";
            // 
            // lblDateRange
            // 
            resources.ApplyResources(lblDateRange, "lblDateRange");
            lblDateRange.ForeColor = Color.RoyalBlue;
            lblDateRange.Name = "lblDateRange";
            // 
            // dtpStart
            // 
            resources.ApplyResources(dtpStart, "dtpStart");
            dtpStart.Name = "dtpStart";
            // 
            // dtpEnd
            // 
            resources.ApplyResources(dtpEnd, "dtpEnd");
            dtpEnd.Name = "dtpEnd";
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.BackColor = Color.RoyalBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.ForeColor = Color.White;
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblArrow
            // 
            resources.ApplyResources(lblArrow, "lblArrow");
            lblArrow.ForeColor = Color.RoyalBlue;
            lblArrow.Name = "lblArrow";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnDeleteInvoice
            // 
            btnDeleteInvoice.BackColor = Color.RoyalBlue;
            btnDeleteInvoice.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnDeleteInvoice, "btnDeleteInvoice");
            btnDeleteInvoice.ForeColor = Color.White;
            btnDeleteInvoice.Name = "btnDeleteInvoice";
            btnDeleteInvoice.UseVisualStyleBackColor = false;
            btnDeleteInvoice.Click += btnDeleteInvoice_Click;
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.RoyalBlue;
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            resources.ApplyResources(btnMinimize, "btnMinimize");
            btnMinimize.BackColor = Color.White;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.ForeColor = Color.RoyalBlue;
            btnMinimize.Name = "btnMinimize";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            btnMinimize.Paint += btnMinimize_Paint;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.RoyalBlue;
            label1.Name = "label1";
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.RoyalBlue;
            btnExportPdf.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnExportPdf, "btnExportPdf");
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // InvoiceSearchForm
            // 
            resources.ApplyResources(this, "$this");
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnDeleteInvoice);
            Controls.Add(btnMinimize);
            Controls.Add(btnClose);
            Controls.Add(pnlSearch);
            Controls.Add(btnExportPdf);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InvoiceSearchForm";
            Load += InvoiceSearchForm_Load;
            MouseDown += InvoiceSearchForm_MouseDown;
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblArrow;
        private Label label1;
    }
} 