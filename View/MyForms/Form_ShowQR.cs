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
    public partial class Form_ShowQR : Form
    {
        public Form_ShowQR(string MaCTSP)
        {
            InitializeComponent();
            pictureBox2.Image = BLLClothShop.Instance.ByteToImg(BLLClothShop.Instance.GetCTSPByMaCTSP(MaCTSP).MaQR);
            lbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(MaCTSP).MaSP).TenSP + " - "
                                + BLLClothShop.Instance.GetCTSPByMaCTSP(MaCTSP).MauSac + " - " + BLLClothShop.Instance.GetCTSPByMaCTSP(MaCTSP).Size;
        }

        private void butNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
