
namespace ClothShop.View.MyForms
{
    partial class Form_AddNhomSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddNhomSP));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbNhomSP = new System.Windows.Forms.TextBox();
            this.butYes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.tbNhomSP);
            this.panel2.Controls.Add(this.butYes);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 488);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(520, 320);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // tbNhomSP
            // 
            this.tbNhomSP.Location = new System.Drawing.Point(55, 58);
            this.tbNhomSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNhomSP.Name = "tbNhomSP";
            this.tbNhomSP.Size = new System.Drawing.Size(447, 27);
            this.tbNhomSP.TabIndex = 39;
            // 
            // butYes
            // 
            this.butYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.butYes.FlatAppearance.BorderSize = 0;
            this.butYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butYes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.butYes.Image = ((System.Drawing.Image)(resources.GetObject("butYes.Image")));
            this.butYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butYes.Location = new System.Drawing.Point(536, 51);
            this.butYes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butYes.Name = "butYes";
            this.butYes.Size = new System.Drawing.Size(39, 42);
            this.butYes.TabIndex = 38;
            this.butYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butYes.UseVisualStyleBackColor = false;
            this.butYes.Click += new System.EventHandler(this.butYes_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(50, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập tên nhóm sản phẩm muốn thêm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 46);
            this.panel1.TabIndex = 4;
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.butClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.butClose.FlatAppearance.BorderSize = 0;
            this.butClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.Location = new System.Drawing.Point(575, 0);
            this.butClose.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(41, 46);
            this.butClose.TabIndex = 39;
            this.butClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butClose.UseVisualStyleBackColor = false;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 33);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(50, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thêm Mới Nhóm Sản Phẩm";
            // 
            // Form_AddNhomSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(171)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(640, 556);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_AddNhomSP";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AddNhomSP";
            this.TopMost = true;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butYes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNhomSP;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butClose;
    }
}