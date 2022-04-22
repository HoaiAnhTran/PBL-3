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
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (Form_AddSP f = new Form_AddSP())
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (Form_EditSP f = new Form_EditSP())
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }
    }
}
