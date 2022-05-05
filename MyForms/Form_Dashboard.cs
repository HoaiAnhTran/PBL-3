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
    public partial class Form_Dashboard : Form
    {
        public Form_Dashboard()
        {
            InitializeComponent();
            timer1.Start();
            UserControls.UC_Dashboard uc = new UserControls.UC_Dashboard();
            addControls(uc);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM");
        }
        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }
        private void buttonTC_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_Dashboard uc = new UserControls.UC_Dashboard();
            addControls(uc);
        }
        private void buttonHD_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_HoaDon uc = new UserControls.UC_HoaDon(); 
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
        private void buttonNV_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhanVien uc = new UserControls.UC_NhanVien();
            addControls(uc);
        }

        private void buttonDT_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_DoiTac uc = new UserControls.UC_DoiTac();
            addControls(uc);
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_ThongKe uc = new UserControls.UC_ThongKe();
            addControls(uc);
        }

        private void buttonKM_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_KhuyenMai uc = new UserControls.UC_KhuyenMai();
            addControls(uc);
        }
        private void buttonDX_Click(object sender, EventArgs e)
        {
            MyForms.Form_XacNhanDX f = new MyForms.Form_XacNhanDX();
            f.Show();
        }
    }
}
