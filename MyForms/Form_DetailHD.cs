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
    public partial class Form_DetailHD : Form
    {
        string MaHD;
        public Form_DetailHD(string s)
        {
            InitializeComponent();
            MaHD = s;
            GUI();
        }
        public void GUI()
        {
            if (MaHD != null)
            {
                lbTitle.Text = "Cập nhật hóa đơn";
            }    
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
