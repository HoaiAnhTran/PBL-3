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
    public partial class Form_DetailNV : Form
    {
        String MaNV;
        public Form_DetailNV(string s)
        {
            InitializeComponent();
            MaNV = s;
            GUI();
        }
        public void GUI()
        {
            if (MaNV != null)
            {
                llbTitle.Text = "Cập nhật nhân viên";
            }    
        }    
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
