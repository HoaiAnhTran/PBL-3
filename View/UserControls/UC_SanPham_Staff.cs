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
using ClothShop.View.MyForms;

namespace ClothShop.View.UserControls
{
    public partial class UC_SanPham_Staff : UserControl
    {
        public UC_SanPham_Staff()
        {
            InitializeComponent();
            ReLoad();
        }
        public void ReLoad()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllSP();
            dataGridView2.DataSource = null;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                tbMaSP.Text = dataGridView1.SelectedRows[0].Cells["MaSP"].Value.ToString();
                cbbSize.Items.Clear();
                cbbSize.Items.Add("All");
                cbbSize.SelectedIndex = 0;
                foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(tbMaSP.Text))
                {
                    cbbSize.Items.Add(i.ToString());
                }
                cbbMau.Items.Clear();
                cbbMau.Items.Add("All");
                cbbMau.SelectedIndex = 0;
                foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(tbMaSP.Text))
                {
                    cbbMau.Items.Add(i.ToString());
                }
                dataGridView2.DataSource = BLLClothShop.Instance.GetCTSPByMaSP(tbMaSP.Text, cbbSize.Text, cbbMau.Text);
            }
        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = BLLClothShop.Instance.GetCTSPByMaSP(tbMaSP.Text, cbbSize.Text, cbbMau.Text);
        }

        private void cbbMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = BLLClothShop.Instance.GetCTSPByMaSP(tbMaSP.Text, cbbSize.Text, cbbMau.Text);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (Form_ShowQR f = new Form_ShowQR(dataGridView2.SelectedRows[0].Cells["MaCTSP"].Value.ToString()))
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
            }


            //Form formBackground = new Form();
            //try
            //{
            //    using (Form_ShowQR f = new Form_ShowQR(dataGridView2.SelectedRows[0].Cells["MaCTSP"].Value.ToString()))
            //    {
            //        formBackground.StartPosition = FormStartPosition.Manual;
            //        formBackground.FormBorderStyle = FormBorderStyle.None;
            //        formBackground.Opacity = .70d;
            //        formBackground.BackColor = Color.Black;
            //        formBackground.WindowState = FormWindowState.Maximized;
            //        formBackground.TopMost = true;
            //        formBackground.Location = this.Location;
            //        formBackground.ShowInTaskbar = false;
            //        formBackground.Show();

            //        f.Owner = formBackground;
            //        f.ShowDialog();
            //        this.OnLoad(e);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    formBackground.Dispose();
            //}
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllSP(tbSearch.Text);
        }
    }
}
