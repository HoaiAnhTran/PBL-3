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


namespace ClothShop.View.UserControls
{
    public partial class UC_NhapKho : UserControl
    {
        string MaNV;
        public UC_NhapKho(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoad();
        }
        public void ReLoad()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNK();
            dataGridView2.DataSource = null;
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailNK f = new MyForms.Form_DetailNK(null, MaNV))
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
                    f.d = new MyForms.Form_DetailNK.MyDel(ReLoad);
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
            //MyForms.Form_DetailNK f = new MyForms.Form_DetailNK(null, MaNV);
            //f.d = new MyForms.Form_DetailNK.MyDel(ReLoad);
            //f.Show();
        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailNK f = new MyForms.Form_DetailNK(dataGridView1.SelectedRows[0].Cells["MaNK"].Value.ToString(), MaNV))
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
                        f.d = new MyForms.Form_DetailNK.MyDel(ReLoad);
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
                };
                //MyForms.Form_DetailNK f = new MyForms.Form_DetailNK(dataGridView1.SelectedRows[0].Cells["MaNK"].Value.ToString(), MaNV);
                //f.d = new MyForms.Form_DetailNK.MyDel(ReLoad);
                //f.Show();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                tbMaNK.Text = dataGridView1.SelectedRows[0].Cells["MaNK"].Value.ToString();
                dataGridView2.DataSource = BLLClothShop.Instance.GetCTNKByMaNK(tbMaNK.Text);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string MaNK = i.Cells["MaNK"].Value.ToString();
                    BLLClothShop.Instance.DelNK(MaNK);
                }
                ReLoad();
            }
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNK(tbSearch.Text);
        }
    }
}
