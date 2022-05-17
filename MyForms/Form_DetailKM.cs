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
    public partial class Form_DetailKM : Form
    {
        string MaKM;
        public Form_DetailKM(string s)
        {
            InitializeComponent();
            MaKM = s;
            GUI();
        }
        public void GUI()
        {
            if (MaKM != null)
            {
                lbTitle.Text = "Cập nhật mã khuyến mãi";
            } 
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
