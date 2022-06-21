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
using ClothShop.View;

namespace ClothShop.View.MyForms
{
    public partial class Form_Dashboard : Form
    {
        string MaNV;
        public Form_Dashboard(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            lbTenNV.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
            lbChucVu.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu;
            timer1.Start();
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            UserControls.UC_TrangChu uc = new UserControls.UC_TrangChu();
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
            labelTime.Text = dt.ToString("HH:mm");
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
            UserControls.UC_TrangChu uc = new UserControls.UC_TrangChu();
            addControls(uc);
        }
        private void buttonHD_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_HoaDon uc = new UserControls.UC_HoaDon(MaNV); 
            addControls(uc);
        }
        private void buttonSP_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_SanPham uc = new UserControls.UC_SanPham(MaNV);
            addControls(uc);
        }
        private void buttonNK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhapKho uc = new UserControls.UC_NhapKho(MaNV);
            addControls(uc);
        }
        private void buttonNV_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhanVien uc = new UserControls.UC_NhanVien(MaNV);
            addControls(uc);
        }

        private void buttonDT_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_DoiTac uc = new UserControls.UC_DoiTac(MaNV);
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
            UserControls.UC_KhuyenMai uc = new UserControls.UC_KhuyenMai(MaNV);
            addControls(uc);
        }
        private void buttonCDTK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_Account uc = new UserControls.UC_Account(MaNV);
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
