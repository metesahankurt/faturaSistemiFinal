namespace FaturaKasaSistemi
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            cmbIl = new ComboBox();
            cmbIlce = new ComboBox();
            txtAddress = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnClose = new Button();
            btnMinimize = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            resources.ApplyResources(txtFirstName, "txtFirstName");
            txtFirstName.Name = "txtFirstName";
            // 
            // txtLastName
            // 
            resources.ApplyResources(txtLastName, "txtLastName");
            txtLastName.Name = "txtLastName";
            // 
            // cmbIl
            // 
            cmbIl.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(cmbIl, "cmbIl");
            cmbIl.FormattingEnabled = true;
            cmbIl.Name = "cmbIl";
            cmbIl.SelectedIndexChanged += cmbIl_SelectedIndexChanged;
            // 
            // cmbIlce
            // 
            cmbIlce.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(cmbIlce, "cmbIlce");
            cmbIlce.FormattingEnabled = true;
            cmbIlce.Name = "cmbIlce";
            // 
            // txtAddress
            // 
            resources.ApplyResources(txtAddress, "txtAddress");
            txtAddress.Name = "txtAddress";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.ForeColor = Color.White;
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.RoyalBlue;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.RoyalBlue;
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.RoyalBlue;
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.RoyalBlue;
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = Color.RoyalBlue;
            label5.Name = "label5";
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
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.RoyalBlue;
            label6.Name = "label6";
            // 
            // CustomerForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.WhiteSmoke;
            resources.ApplyResources(this, "$this");
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(cmbIlce);
            Controls.Add(cmbIl);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            MouseDown += CustomerForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cmbIl;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
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
        private Button button2;
        private Label label6;
    }
} 