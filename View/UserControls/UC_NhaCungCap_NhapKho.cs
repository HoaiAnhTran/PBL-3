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
    public partial class UC_NhaCungCap_NhapKho : UserControl
    {
        string MaNV;
        public UC_NhaCungCap_NhapKho(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoadNCC();
        }
        public void ReLoadNCC()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNCC();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailNCC f = new MyForms.Form_DetailNCC(null))
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
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (MyForms.Form_DetailNCC f = new MyForms.Form_DetailNCC(dataGridView1.SelectedRows[0].Cells["MaNCC"].Value.ToString()))
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

        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNCC(tbSearch.Text);
        }
    }
}
