namespace FaturaKasaSistemi
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblName = new Label();
            txtName = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblVat = new Label();
            numVat = new NumericUpDown();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnClose = new Button();
            btnMinimize = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.ForeColor = Color.RoyalBlue;
            lblName.Name = "lblName";
            // 
            // txtName
            // 
            resources.ApplyResources(txtName, "txtName");
            txtName.Name = "txtName";
            // 
            // lblPrice
            // 
            resources.ApplyResources(lblPrice, "lblPrice");
            lblPrice.ForeColor = Color.RoyalBlue;
            lblPrice.Name = "lblPrice";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            resources.ApplyResources(numPrice, "numPrice");
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            // 
            // lblVat
            // 
            resources.ApplyResources(lblVat, "lblVat");
            lblVat.ForeColor = Color.RoyalBlue;
            lblVat.Name = "lblVat";
            // 
            // numVat
            // 
            numVat.DecimalPlaces = 2;
            resources.ApplyResources(numVat, "numVat");
            numVat.Name = "numVat";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.RoyalBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.ForeColor = Color.White;
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
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
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.RoyalBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.ForeColor = Color.White;
            btnDelete.Name = "btnDelete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            // ProductForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(numVat);
            Controls.Add(lblVat);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            MouseDown += ProductForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.NumericUpDown numVat;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private Label label1;
    }
} 