namespace FaturaKasaSistemi
{
    partial class KasaRaporuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblToplamSatis;
        private System.Windows.Forms.Label lblToplamKDV;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.DataGridView dataGridView1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasaRaporuForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblToplamSatis = new Label();
            lblToplamKDV = new Label();
            lblGenelToplam = new Label();
            dataGridView1 = new DataGridView();
            btnClose = new Button();
            btnMinimize = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTarih
            // 
            resources.ApplyResources(lblTarih, "lblTarih");
            lblTarih.ForeColor = Color.RoyalBlue;
            lblTarih.Name = "lblTarih";
            // 
            // dtpTarih
            // 
            resources.ApplyResources(dtpTarih, "dtpTarih");
            dtpTarih.Name = "dtpTarih";
            dtpTarih.ValueChanged += dtpTarih_ValueChanged;
            // 
            // lblToplamSatis
            // 
            resources.ApplyResources(lblToplamSatis, "lblToplamSatis");
            lblToplamSatis.ForeColor = Color.RoyalBlue;
            lblToplamSatis.Name = "lblToplamSatis";
            // 
            // lblToplamKDV
            // 
            resources.ApplyResources(lblToplamKDV, "lblToplamKDV");
            lblToplamKDV.ForeColor = Color.RoyalBlue;
            lblToplamKDV.Name = "lblToplamKDV";
            // 
            // lblGenelToplam
            // 
            resources.ApplyResources(lblGenelToplam, "lblGenelToplam");
            lblGenelToplam.ForeColor = Color.RoyalBlue;
            lblGenelToplam.Name = "lblGenelToplam";
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
            // KasaRaporuForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(dataGridView1);
            Controls.Add(lblGenelToplam);
            Controls.Add(lblToplamKDV);
            Controls.Add(lblToplamSatis);
            Controls.Add(dtpTarih);
            Controls.Add(lblTarih);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KasaRaporuForm";
            MouseDown += KasaRaporuForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 