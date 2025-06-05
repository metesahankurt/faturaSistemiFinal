namespace FaturaKasaSistemi
{
    partial class CustomerListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerListForm));
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnClose = new Button();
            btnMinimize = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.ForeColor = Color.RoyalBlue;
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.White;
            btnMinimize.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnMinimize, "btnMinimize");
            btnMinimize.ForeColor = Color.RoyalBlue;
            btnMinimize.Name = "btnMinimize";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.RoyalBlue;
            label6.Name = "label6";
            // 
            // CustomerListForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerListForm";
            Load += CustomerListForm_Load;
            MouseDown += CustomerListForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Sağ üstteki butonları hizalayan fonksiyon
        private void UpdateWindowButtons()
        {
            int spacing = 10;
            int gap = 10; // butonlar arası boşluk
            int btnW = 30;
            int topPadding = 10;

    btnClose.Location = new System.Drawing.Point(this.ClientSize.Width - btnW - spacing, topPadding);
    btnMinimize.Location = new System.Drawing.Point(this.ClientSize.Width - 2 * btnW - spacing - gap, topPadding);
        }
        private Label label6;
    }
} 