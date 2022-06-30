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
using ClothShop.DTO;

namespace ClothShop.View.MyForms
{
    public partial class Form_DetailNCC : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaNCC;
        public Form_DetailNCC(string ncc)
        {
            InitializeComponent();
            MaNCC = ncc;
            GUI();
        }
        public void GUI()
        {
            if (MaNCC != null)
            {
                lbTitle.Text = "Cập nhật nhà cung cấp";
                tbMaNCC.Text = MaNCC;
                tbTenNCC.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).TenNCC;
                tbDiaChi.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).DiaChi;
                tbEmail.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).Mail;
                tbSDT.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).SDT;
            }
            else
            {
                Random rd = new Random();
                string rand;
                do
                {
                    rand = "";
                    rand = rd.Next(0, 9999999).ToString();
                    for (int i = 0; i < (7 - rand.Length); i++)
                        rand = "0" + rand;
                    rand = "NCC" + rand;
                }
                while (BLLClothShop.Instance.GetNCCByMaNCC(rand) != null);
                tbMaNCC.Text = rand;
            }    
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            foreach (char i in tbSDT.Text)
            {
                if ((i < '0' || i > '9') && i != '+')
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    return;
                }
            }
            NhaCungCap n = new NhaCungCap
            {
                MaNCC = tbMaNCC.Text,
                TenNCC = (tbMaNCC.Text != "") ? tbTenNCC.Text : "",
                DiaChi = (tbDiaChi.Text != "")? tbDiaChi.Text : "",
                Mail = (tbEmail.Text != "")? tbEmail.Text : "",
                SDT = (tbSDT.Text != "") ? tbSDT.Text : "",
            };
            BLLClothShop.Instance.AddUpdateNCC(n);
            d();
            this.Close();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
