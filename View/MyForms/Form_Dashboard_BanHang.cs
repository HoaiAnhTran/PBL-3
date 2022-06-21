using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothShop.BLL;

namespace ClothShop.View.MyForms
{
    public partial class Form_Dashboard_BanHang : Form
    {
        string MaNV;
        public Form_Dashboard_BanHang(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            lbTenNV.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
            lbChucVu.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu;
            timer1.Start();
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            UserControls.UC_Account uc = new UserControls.UC_Account(MaNV);
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
            UserControls.UC_Account uc = new UserControls.UC_Account(MaNV);
            addControls(uc);
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_SanPham_Staff uc = new UserControls.UC_SanPham_Staff();
            addControls(uc);
        }

        private void buttonKH_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_KhachHang_BanHang uc = new UserControls.UC_KhachHang_BanHang();
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
            f.d = new Form_XacNhanDX.MyDel(CloseForm);
            f.Show();
        }
        public void CloseForm()
        {
            this.Close();
        }
    }
}
