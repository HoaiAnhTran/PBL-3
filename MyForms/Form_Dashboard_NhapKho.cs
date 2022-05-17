using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothShop.MyForms
{
    public partial class Form_Dashboard_NhapKho : Form
    {
        public Form_Dashboard_NhapKho()
        {
            InitializeComponent();
            timer1.Start();
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            UserControls.UC_Account uc = new UserControls.UC_Account();
            addControls(uc);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MoveSidePannel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }
        private void buttonCDTK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_Account uc = new UserControls.UC_Account();
            addControls(uc);
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_SanPham uc = new UserControls.UC_SanPham();
            addControls(uc);
        }
        private void buttonNK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhapKho uc = new UserControls.UC_NhapKho();
            addControls(uc);
        }
        private void buttonNCC_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhaCungCap_NhapKho uc = new UserControls.UC_NhaCungCap_NhapKho();
            addControls(uc);
        }
        private void buttonDX_Click(object sender, EventArgs e)
        {
            MyForms.Form_XacNhanDX f = new MyForms.Form_XacNhanDX();
            f.Show();
        }

        
    }
}
