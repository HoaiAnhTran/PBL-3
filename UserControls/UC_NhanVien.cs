using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothShop.UserControls
{
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (Form_AddNV f = new Form_AddNV())
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (Form_EditNV f = new Form_EditNV())
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }
    }
}
