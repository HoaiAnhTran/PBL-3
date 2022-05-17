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
    public partial class Form_DetailNCC : Form
    {
        string MaNCC;
        public Form_DetailNCC(string s)
        {
            InitializeComponent();
            MaNCC = s;
            GUI();
        }
        public void GUI()
        {
            if (MaNCC != null)
            {
                lbTitle.Text = "Cập nhật nhà cung cấp";
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
