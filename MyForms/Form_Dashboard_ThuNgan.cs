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
    public partial class Form_Dashboard_ThuNgan : Form
    {
        public Form_Dashboard_ThuNgan()
        {
            InitializeComponent();
            timer1.Start();
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            UserControls.UC_Account uc = new UserControls.UC_Account();
            addControls(uc);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm");
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
            UserControls.UC_SanPham_Staff uc = new UserControls.UC_SanPham_Staff();
            addControls(uc);
        }
        private void buttonHD_Click(object sender, EventArgs e)
        {

            MoveSidePannel((Button)sender);
            UserControls.UC_HoaDon_ThuNgan uc = new UserControls.UC_HoaDon_ThuNgan();
            addControls(uc);
        }
        private void buttonKH_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_KhachHang_ThuNgan uc = new UserControls.UC_KhachHang_ThuNgan();
            addControls(uc);
        }
        private void buttonKM_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_KhuyenMai_Staff uc = new UserControls.UC_KhuyenMai_Staff();
            addControls(uc);
        }
        private void buttonDX_Click(object sender, EventArgs e)
        {
            MyForms.Form_XacNhanDX f = new MyForms.Form_XacNhanDX();
            f.Show();
        }
    }
}
