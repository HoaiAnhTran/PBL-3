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
    public partial class UC_NhanVien : UserControl
    {
        string MaNV;
        public UC_NhanVien(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            ReLoad();
        }
        public void ReLoad()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNV();
        }
        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllNV(tbSearch.Text);
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailNV f = new MyForms.Form_DetailNV(null))
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
                    f.d = new MyForms.Form_DetailNV.MyDel(ReLoad);
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
                    using (MyForms.Form_DetailNV f = new MyForms.Form_DetailNV(dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString()))
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
                        f.d = new MyForms.Form_DetailNV.MyDel(ReLoad);
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
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string MaNV = i.Cells["MaNV"].Value.ToString();
                    if (BLLClothShop.Instance.CheckDelNV(MaNV))
                    {
                        BLLClothShop.Instance.DelNV(MaNV);
                    }
                    else
                        MessageBox.Show("Không thể xóa nhân viên này");
                }
                ReLoad();
            }
        }
        private void buttonResetMK_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaNV = dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString();
                BLLClothShop.Instance.ResetMKNV(MaNV);
                MessageBox.Show("Reset mật khẩu cho tài khoản nhân viên thành công!");
            }
        }
    }
}
