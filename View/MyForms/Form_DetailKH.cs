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
    public partial class Form_DetailKH : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaKH;
        public Form_DetailKH(string kh)
        {
            InitializeComponent();
            MaKH = kh;
            GUI();
        }
        public void GUI()
        {
            if (MaKH != null)
            {
                lbTitle.Text = "Cập nhật khách hàng";
                tbMaKH.Text = MaKH;
                tbTenKH.Text = BLLClothShop.Instance.GetKHByMaKH(MaKH).TenKH;
                tbDiaChi.Text = BLLClothShop.Instance.GetKHByMaKH(MaKH).DiaChi;
                tbSDT.Text = BLLClothShop.Instance.GetKHByMaKH(MaKH).SDT;
                if (BLLClothShop.Instance.GetKHByMaKH(MaKH).GioiTinh)
                    rbNam.Checked = true;
                else rbNu.Checked = true;
                dateTimePicker1.Value = BLLClothShop.Instance.GetKHByMaKH(MaKH).NgaySinh;
            }
            else
            {
                Random rd = new Random();
                string rand;
                do
                {
                    rand = "";
                    rand = rd.Next(0, 99999999).ToString();
                    for (int i = 0; i < (8 - rand.Length); i++)
                        rand = "0" + rand;
                    rand = "KH" + rand;
                }
                while (BLLClothShop.Instance.GetKHByMaKH(rand) != null);
                tbMaKH.Text = rand;
            }    
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            KhachHang k = new KhachHang
            {
                MaKH = tbMaKH.Text,
                TenKH = (tbTenKH.Text != "") ? tbTenKH.Text : "",
                DiaChi = (tbDiaChi.Text != "") ? tbDiaChi.Text : "",
                SDT = (tbSDT.Text != "") ? tbSDT.Text : "",
                NgaySinh = dateTimePicker1.Value,
                GioiTinh = rbNam.Checked,
            };
            BLLClothShop.Instance.AddUpdateKH(k);
            d();
            this.Close();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
