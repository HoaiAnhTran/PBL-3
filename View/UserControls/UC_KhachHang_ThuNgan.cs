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
    public partial class UC_KhachHang_ThuNgan : UserControl
    {
        string MaNV;
        public UC_KhachHang_ThuNgan(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoadKH();
        }
        public void ReLoadKH()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH();
        }
        private void buttonThem_Click(object sender, EventArgs e)
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

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailKH f = new MyForms.Form_DetailKH(dataGridView1.SelectedRows[0].Cells["MaKH"].Value.ToString(), MaNV))
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

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKH(tbSearch.Text);
        }
    }
}
