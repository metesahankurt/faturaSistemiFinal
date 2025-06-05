namespace FaturaKasaSistemi
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            btnAddItem = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbProducts = new ComboBox();
            lblProduct = new Label();
            lblSelectCustomer = new Label();
            cmbCustomers = new ComboBox();
            lblCustomerDetail = new Label();
            btnSaveInvoice = new Button();
            btnExportPdf = new Button();
            btnMinimize = new Button();
            lblSubtotal = new Label();
            lblVat = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.RoyalBlue;
            label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.RoyalBlue;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
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
            // numQuantity
            // 
            resources.ApplyResources(numQuantity, "numQuantity");
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            resources.ApplyResources(lblQuantity, "lblQuantity");
            lblQuantity.ForeColor = Color.RoyalBlue;
            lblQuantity.Name = "lblQuantity";
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(cmbProducts, "cmbProducts");
            cmbProducts.Name = "cmbProducts";
            // 
            // lblProduct
            // 
            resources.ApplyResources(lblProduct, "lblProduct");
            lblProduct.ForeColor = Color.RoyalBlue;
            lblProduct.Name = "lblProduct";
            // 
            // lblSelectCustomer
            // 
            resources.ApplyResources(lblSelectCustomer, "lblSelectCustomer");
            lblSelectCustomer.ForeColor = Color.RoyalBlue;
            lblSelectCustomer.Name = "lblSelectCustomer";
            // 
            // cmbCustomers
            // 
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(cmbCustomers, "cmbCustomers");
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.SelectedIndexChanged += cmbCustomers_SelectedIndexChanged;
            // 
            // lblCustomerDetail
            // 
            resources.ApplyResources(lblCustomerDetail, "lblCustomerDetail");
            lblCustomerDetail.ForeColor = Color.Gray;
            lblCustomerDetail.Name = "lblCustomerDetail";
            // 
            // btnSaveInvoice
            // 
            btnSaveInvoice.BackColor = Color.RoyalBlue;
            btnSaveInvoice.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnSaveInvoice, "btnSaveInvoice");
            btnSaveInvoice.ForeColor = Color.White;
            btnSaveInvoice.Name = "btnSaveInvoice";
            btnSaveInvoice.UseVisualStyleBackColor = false;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
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
            // lblSubtotal
            // 
            resources.ApplyResources(lblSubtotal, "lblSubtotal");
            lblSubtotal.ForeColor = Color.RoyalBlue;
            lblSubtotal.Name = "lblSubtotal";
            // 
            // lblVat
            // 
            resources.ApplyResources(lblVat, "lblVat");
            lblVat.ForeColor = Color.RoyalBlue;
            lblVat.Name = "lblVat";
            // 
            // lblTotal
            // 
            resources.ApplyResources(lblTotal, "lblTotal");
            lblTotal.ForeColor = Color.RoyalBlue;
            lblTotal.Name = "lblTotal";
            // 
            // InvoiceForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddItem);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(cmbProducts);
            Controls.Add(lblProduct);
            Controls.Add(lblSelectCustomer);
            Controls.Add(cmbCustomers);
            Controls.Add(lblCustomerDetail);
            Controls.Add(btnSaveInvoice);
            Controls.Add(btnExportPdf);
            Controls.Add(btnMinimize);
            Controls.Add(lblSubtotal);
            Controls.Add(lblVat);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InvoiceForm";
            Load += InvoiceForm_Load;
            MouseDown += InvoiceForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button btnAddItem;
        private NumericUpDown numQuantity;
        private Label lblQuantity;
        private ComboBox cmbProducts;
        private Label lblProduct;
        private Label lblSelectCustomer;
        private ComboBox cmbCustomers;
        private Label lblCustomerDetail;
        private Button btnSaveInvoice;
        private Button btnExportPdf;
        private Button btnMinimize;
        private Label lblSubtotal;
        private Label lblVat;
        private Label lblTotal;
    }
} 