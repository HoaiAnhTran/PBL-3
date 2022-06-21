
namespace ClothShop.View.MyForms
{
    partial class Form_Dashboard_ThuNgan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dashboard_ThuNgan));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lbTenNV = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonDX = new System.Windows.Forms.Button();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.buttonKM = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.buttonCDTK = new System.Windows.Forms.Button();
            this.buttonHD = new System.Windows.Forms.Button();
            this.buttonKH = new System.Windows.Forms.Button();
            this.buttonSP = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(49, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chức vụ:";
            // 
            // lbTenNV
            // 
            this.lbTenNV.AutoSize = true;
            this.lbTenNV.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.lbTenNV.Location = new System.Drawing.Point(141, 13);
            this.lbTenNV.Name = "lbTenNV";
            this.lbTenNV.Size = new System.Drawing.Size(164, 23);
            this.lbTenNV.TabIndex = 1;
            this.lbTenNV.Text = "Hoàng Thị Trang";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonDX);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 487);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(196, 42);
            this.panel5.TabIndex = 11;
            // 
            // buttonDX
            // 
            this.buttonDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDX.FlatAppearance.BorderSize = 0;
            this.buttonDX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDX.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonDX.Image = ((System.Drawing.Image)(resources.GetObject("buttonDX.Image")));
            this.buttonDX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDX.Location = new System.Drawing.Point(0, 0);
            this.buttonDX.Name = "buttonDX";
            this.buttonDX.Size = new System.Drawing.Size(196, 42);
            this.buttonDX.TabIndex = 10;
            this.buttonDX.Text = "   Đăng xuất";
            this.buttonDX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDX.UseVisualStyleBackColor = true;
            this.buttonDX.Click += new System.EventHandler(this.buttonDX_Click);
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.lbChucVu.Location = new System.Drawing.Point(141, 47);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(201, 23);
            this.lbChucVu.TabIndex = 3;
            this.lbChucVu.Text = "Nhân viên thu ngân";
            // 
            // buttonKM
            // 
            this.buttonKM.FlatAppearance.BorderSize = 0;
            this.buttonKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKM.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonKM.Image = ((System.Drawing.Image)(resources.GetObject("buttonKM.Image")));
            this.buttonKM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKM.Location = new System.Drawing.Point(12, 240);
            this.buttonKM.Name = "buttonKM";
            this.buttonKM.Size = new System.Drawing.Size(184, 60);
            this.buttonKM.TabIndex = 9;
            this.buttonKM.Text = "   Khuyến mãi";
            this.buttonKM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonKM.UseVisualStyleBackColor = true;
            this.buttonKM.Click += new System.EventHandler(this.buttonKM_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.panelSide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(10, 60);
            this.panelSide.TabIndex = 4;
            // 
            // buttonCDTK
            // 
            this.buttonCDTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.buttonCDTK.FlatAppearance.BorderSize = 0;
            this.buttonCDTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCDTK.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCDTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonCDTK.Image = ((System.Drawing.Image)(resources.GetObject("buttonCDTK.Image")));
            this.buttonCDTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCDTK.Location = new System.Drawing.Point(12, 0);
            this.buttonCDTK.Name = "buttonCDTK";
            this.buttonCDTK.Size = new System.Drawing.Size(184, 60);
            this.buttonCDTK.TabIndex = 4;
            this.buttonCDTK.Text = "   Cài đặt tài khoản";
            this.buttonCDTK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCDTK.UseVisualStyleBackColor = false;
            this.buttonCDTK.Click += new System.EventHandler(this.buttonCDTK_Click);
            // 
            // buttonHD
            // 
            this.buttonHD.FlatAppearance.BorderSize = 0;
            this.buttonHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHD.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonHD.Image = ((System.Drawing.Image)(resources.GetObject("buttonHD.Image")));
            this.buttonHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHD.Location = new System.Drawing.Point(12, 120);
            this.buttonHD.Name = "buttonHD";
            this.buttonHD.Size = new System.Drawing.Size(184, 60);
            this.buttonHD.TabIndex = 6;
            this.buttonHD.Text = "   Hóa đơn";
            this.buttonHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHD.UseVisualStyleBackColor = true;
            this.buttonHD.Click += new System.EventHandler(this.buttonHD_Click);
            // 
            // buttonKH
            // 
            this.buttonKH.FlatAppearance.BorderSize = 0;
            this.buttonKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKH.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonKH.Image = ((System.Drawing.Image)(resources.GetObject("buttonKH.Image")));
            this.buttonKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKH.Location = new System.Drawing.Point(12, 180);
            this.buttonKH.Name = "buttonKH";
            this.buttonKH.Size = new System.Drawing.Size(184, 60);
            this.buttonKH.TabIndex = 7;
            this.buttonKH.Text = "   Khách hàng";
            this.buttonKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonKH.UseVisualStyleBackColor = true;
            this.buttonKH.Click += new System.EventHandler(this.buttonKH_Click);
            // 
            // buttonSP
            // 
            this.buttonSP.FlatAppearance.BorderSize = 0;
            this.buttonSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.buttonSP.Image = ((System.Drawing.Image)(resources.GetObject("buttonSP.Image")));
            this.buttonSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSP.Location = new System.Drawing.Point(12, 60);
            this.buttonSP.Name = "buttonSP";
            this.buttonSP.Size = new System.Drawing.Size(184, 60);
            this.buttonSP.TabIndex = 5;
            this.buttonSP.Text = "   Sản phẩm";
            this.buttonSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSP.UseVisualStyleBackColor = true;
            this.buttonSP.Click += new System.EventHandler(this.buttonSP_Click);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.labelTime.Location = new System.Drawing.Point(887, 32);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(80, 23);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "HH:MM";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.panel4.Controls.Add(this.labelDate);
            this.panel4.Controls.Add(this.labelTime);
            this.panel4.Controls.Add(this.lbChucVu);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lbTenNV);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(196, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(988, 85);
            this.panel4.TabIndex = 7;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.labelDate.Location = new System.Drawing.Point(752, 32);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(140, 23);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "DD/MM/YYYY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin chào,";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Imprint MT Shadow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(941, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 47);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(196, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 47);
            this.panel3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cửa Hàng Thời Trang";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 132);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.buttonKM);
            this.panel1.Controls.Add(this.panelSide);
            this.panel1.Controls.Add(this.buttonCDTK);
            this.panel1.Controls.Add(this.buttonHD);
            this.panel1.Controls.Add(this.buttonKH);
            this.panel1.Controls.Add(this.buttonSP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 529);
            this.panel1.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.panelLeft.Controls.Add(this.panel1);
            this.panelLeft.Controls.Add(this.panel2);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(196, 661);
            this.panelLeft.TabIndex = 5;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(196, 132);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(988, 529);
            this.panelControls.TabIndex = 8;
            // 
            // Form_Dashboard_ThuNgan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Dashboard_ThuNgan";
            this.Text = "Form_Dashboard_Staff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTenNV;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonDX;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Button buttonKM;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Button buttonCDTK;
        private System.Windows.Forms.Button buttonHD;
        private System.Windows.Forms.Button buttonKH;
        private System.Windows.Forms.Button buttonSP;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label labelDate;
    }
}