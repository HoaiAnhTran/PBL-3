using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothShop.BLL;
using ClothShop.DTO;

namespace ClothShop.View.UserControls
{
    public partial class UC_HoaDon : UserControl
    {
        string MaNV;
        public UC_HoaDon(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoad();
        }
        public void ReLoad()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllHD();
            dataGridView2.DataSource = null;    
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(null, MaNV))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .70d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    f.Owner = formBackground;
                    f.d = new MyForms.Form_DetailHD.MyDel(ReLoad);
                    f.ShowDialog();
                    this.OnLoad(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
            //MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(null, MaNV);
            //f.d = new MyForms.Form_DetailHD.MyDel(ReLoad);
            //f.Show();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(dataGridView1.SelectedRows[0].Cells["MaHD"].Value.ToString(), MaNV))
                    {
                        formBackground.StartPosition = FormStartPosition.Manual;
                        formBackground.FormBorderStyle = FormBorderStyle.None;
                        formBackground.Opacity = .70d;
                        formBackground.BackColor = Color.Black;
                        formBackground.WindowState = FormWindowState.Maximized;
                        formBackground.TopMost = true;
                        formBackground.Location = this.Location;
                        formBackground.ShowInTaskbar = false;
                        formBackground.Show();

                        f.Owner = formBackground;
                        f.d = new MyForms.Form_DetailHD.MyDel(ReLoad);
                        f.ShowDialog();
                        this.OnLoad(e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    formBackground.Dispose();
                }
                //MyForms.Form_DetailHD f = new MyForms.Form_DetailHD(dataGridView1.SelectedRows[0].Cells["MaHD"].Value.ToString(), MaNV);
                //f.d = new MyForms.Form_DetailHD.MyDel(ReLoad);
                //f.Show();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                dataGridView2.DataSource = BLLClothShop.Instance.GetCTHDByMaHD(dataGridView1.SelectedRows[0].Cells["MaHD"].Value.ToString());
            }    
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string MaHD = i.Cells["MaHD"].Value.ToString();
                    BLLClothShop.Instance.DelHD(MaHD);
                }
                ReLoad();
            }
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllHD(tbSearch.Text);
            dataGridView2.DataSource = null;
        }
    }
}
