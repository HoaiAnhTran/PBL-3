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

namespace ClothShop.View.UserControls
{
    public partial class UC_KhachHang_BanHang : UserControl
    {
        public UC_KhachHang_BanHang()
        {
            InitializeComponent();
            ReLoadKH();
        }
        public void ReLoadKH()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH();
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH(tbSearch.Text);
        }
    }
}
