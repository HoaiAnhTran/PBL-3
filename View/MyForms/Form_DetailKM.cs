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
    public partial class Form_DetailKM : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaKM;
        public Form_DetailKM(string km)
        {
            InitializeComponent();
            MaKM = km;
            GUI();
        }
        public void GUI()
        {
            if (MaKM != null)
            {
                lbTitle.Text = "Cập nhật mã khuyến mãi";
                tbMaKM.Text = MaKM;
                tbTenKM.Text = BLLClothShop.Instance.GetKMByMaKM(MaKM).TenKM;
                tbGiaTri.Text = BLLClothShop.Instance.GetKMByMaKM(MaKM).GiaTri.ToString();
                dateTimePicker1.Value = BLLClothShop.Instance.GetKMByMaKM(MaKM).NgayApDung;
                tbMoTa.Text = BLLClothShop.Instance.GetKMByMaKM(MaKM).MoTa;
                tbHSD.Text = BLLClothShop.Instance.GetKMByMaKM(MaKM).HanSuDung.ToString();
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
                    rand = "KM" + rand;
                }
                while (BLLClothShop.Instance.GetKMByMaKM(rand) != null);
                tbMaKM.Text = rand;
            }    
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (tbGiaTri.Text == "" || Convert.ToDouble(tbGiaTri.Text) <= 0)
            {
                MessageBox.Show("Giá trị khuyến mãi không hợp lệ");
                return;
            }    
            KhuyenMai s = new KhuyenMai
            {
                MaKM = tbMaKM.Text,
                TenKM = (tbTenKM.Text != "") ? tbTenKM.Text : "trống",
                NgayApDung = dateTimePicker1.Value,
                HanSuDung = (tbHSD.Text!="") ? Convert.ToInt32(tbHSD.Text) : 0,
                MoTa = (tbMoTa.Text != "") ? tbMoTa.Text : "",
                GiaTri = (tbGiaTri.Text != "") ? Convert.ToDouble(tbGiaTri.Text)/100 : 0,
            };
            BLLClothShop.Instance.AddUpdateKM(s);
            d();
            this.Close();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
