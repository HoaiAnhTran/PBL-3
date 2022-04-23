﻿using System;
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
    public partial class UC_HoaDon : UserControl
    {
        public UC_HoaDon()
        {
            InitializeComponent();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(null))
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(""))
            {
                f.ShowDialog();
                this.OnLoad(e);
            }
        }
    }
}
