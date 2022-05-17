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

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                if (tbUsername.Text == "admin" && tbPassword.Text == "1111")
                {
                    Form_Dashboard f = new Form_Dashboard();
                    f.Show();
                }
                else if (tbUsername.Text == "thungan01" && tbPassword.Text == "2222")
                {
                    Form_Dashboard_ThuNgan f = new Form_Dashboard_ThuNgan();
                    f.Show();
                }
                else if (tbUsername.Text == "banhang01" && tbPassword.Text == "3333")
                {
                    Form_Dashboard_BanHang f = new Form_Dashboard_BanHang();
                    f.Show();
                }
                else if (tbUsername.Text == "nhapkho01" && tbPassword.Text == "5555")
                {
                    Form_Dashboard_NhapKho f = new Form_Dashboard_NhapKho();
                    f.Show();
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
            
        }
    }
}
