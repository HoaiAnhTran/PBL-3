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
    public partial class Form_XacNhanDX : Form
    {
        public Form_XacNhanDX()
        {
            InitializeComponent();
        }

        private void butYes_Click(object sender, EventArgs e)
        {
            MyForms.Form_Login f = new MyForms.Form_Login();
            f.Show();
        }
        private void butNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
