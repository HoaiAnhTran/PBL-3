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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void DangNhap()
        {
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                if (BLLClothShop.Instance.CheckDN(tbUsername.Text, tbPassword.Text))
                {
                    if (BLLClothShop.Instance.CheckChucVu(tbUsername.Text) == 0)
                    {
                        Form_Dashboard f = new Form_Dashboard(tbUsername.Text);
                        f.Show();
                    }
                    else if (BLLClothShop.Instance.CheckChucVu(tbUsername.Text) == 1)
                    {
                        Form_Dashboard_ThuNgan f = new Form_Dashboard_ThuNgan(tbUsername.Text);
                        f.Show();
                    }
                    else if (BLLClothShop.Instance.CheckChucVu(tbUsername.Text) == 2)
                    {
                        Form_Dashboard_BanHang f = new Form_Dashboard_BanHang(tbUsername.Text);
                        f.Show();
                    }
                    else if (BLLClothShop.Instance.CheckChucVu(tbUsername.Text) == 3)
                    {
                        Form_Dashboard_NhapKho f = new Form_Dashboard_NhapKho(tbUsername.Text);
                        f.Show();
                    }
                }
                else
                {
                    Form_Message f = new Form_Message("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    f.Show();
                }
            }
            else
            {
                Form_Message f = new Form_Message("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                f.Show();
            }
            tbPassword.Text = "";
        }
        private void butLogin_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void Form_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DangNhap();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DangNhap();
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DangNhap();
        }
    }
}
