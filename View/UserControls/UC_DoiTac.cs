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
    public partial class UC_DoiTac : UserControl
    {
        string MaNV;
        public UC_DoiTac(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoadNCC();
            ReLoadKH();
        }
        public void ReLoadNCC()
        {
            dataGridView3.DataSource = BLLClothShop.Instance.GetAllNCC();
        }
        public void ReLoadKH()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH();
        }
        private void butThemKH_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailKH f = new MyForms.Form_DetailKH(null,MaNV))
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
                    f.d = new MyForms.Form_DetailKH.MyDel(ReLoadKH);
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

        private void butSuaKH_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailKH f = new MyForms.Form_DetailKH(dataGridView1.SelectedRows[0].Cells["MaKH"].Value.ToString(),MaNV))
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
                        f.d = new MyForms.Form_DetailKH.MyDel(ReLoadKH);
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
        }

        private void butThemNCC_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailNCC f = new MyForms.Form_DetailNCC(null,MaNV))
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
                    f.d = new MyForms.Form_DetailNCC.MyDel(ReLoadNCC);
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

        private void butSuaNCC_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailNCC f = new MyForms.Form_DetailNCC(dataGridView3.SelectedRows[0].Cells["MaNCC"].Value.ToString(),MaNV))
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
                        f.d = new MyForms.Form_DetailNCC.MyDel(ReLoadNCC);
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
        }

        private void butXoaKH_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string MaKH = i.Cells["MaKH"].Value.ToString();
                    if (BLLClothShop.Instance.CheckDelKH(MaKH))
                    {
                        BLLClothShop.Instance.DelKH(MaKH);
                    }
                    else
                        MessageBox.Show("Không thể xóa khách hàng này");
                }
                ReLoadKH();
            }
        }

        private void butXoaNCC_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView3.SelectedRows)
                {
                    string MaNCC = i.Cells["MaNCC"].Value.ToString();
                    if (BLLClothShop.Instance.CheckDelNCC(MaNCC))
                    {
                        BLLClothShop.Instance.DelNCC(MaNCC);
                    }
                    else
                        MessageBox.Show("Không thể xóa nhà cung cấp này");
                }
                ReLoadNCC();    
            }
        }

        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH(tbSearchKH.Text);
        }

        private void btnSearchNCC_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = BLLClothShop.Instance.GetAllNCC(tbSearchNCC.Text);
        }
    }
}
