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
    public partial class Form_DetailSP : Form
    {
        string MaSP;
        public Form_DetailSP(string s)
        {
            InitializeComponent();
            MaSP = s;
            GUI();
        }
        public void GUI()
        {
            if (MaSP != null)
            {
                lbTitle.Text = "Cập nhật sản phẩm";
            }    
        }
        private void butThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
