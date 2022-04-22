using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothShop
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MoveSidePannel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        //private void ButtonClick(object o, EventArgs e)
        //{
        //    MoveSidePannel((Button)o);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM");
        }
        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }
        private void buttonHome_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_Dashboard uc = new UserControls.UC_Dashboard();
            addControls(uc);
        }
        private void buttonHD_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_HoaDon uc = new UserControls.UC_HoaDon(); 
            addControls(uc);
        }
        private void buttonSP_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_SanPham uc = new UserControls.UC_SanPham();
            addControls(uc);
        }
        private void buttonNK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
        }
        private void buttonNV_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_NhanVien uc = new UserControls.UC_NhanVien();
            addControls(uc);
        }

        private void buttonDT_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
            UserControls.UC_DoiTac uc = new UserControls.UC_DoiTac();
            addControls(uc);
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
        }

        private void buttonKM_Click(object sender, EventArgs e)
        {
            MoveSidePannel((Button)sender);
        }
    }
}
