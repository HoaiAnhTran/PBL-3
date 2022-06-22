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
using ClothShop.View.MyForms;

namespace ClothShop.View.UserControls
{
    public partial class UC_KhuyenMai : UserControl
    {
        string MaNV;
        public UC_KhuyenMai(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            tbTgLuuKho.Text = "90";
            tbTileBan.Text = "50";
            ReLoadKM();
            ReLoadGoiY(90,50);
        }
        public void ReLoadKM()
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKM(); 
        }
        public void ReLoadGoiY(int tg, double tile)
        {
            dataGridView2.DataSource = BLLClothShop.Instance.GetSPTonKho(tg,tile);
        }    
        private void buttonThemKM_Click(object sender, EventArgs e)
        {

            Form formBackground = new Form();
            try
            {
                using (Form_DetailKM f = new Form_DetailKM(null,MaNV))
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
                    f.d = new Form_DetailKM.MyDel(ReLoadKM);
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

        private void buttonSuaKM_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form formBackground = new Form();
                try
                {
                    using (Form_DetailKM f = new Form_DetailKM(dataGridView1.SelectedRows[0].Cells["MaKM"].Value.ToString(), MaNV))
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
                        f.d = new Form_DetailKM.MyDel(ReLoadKM);
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
                    string MaKM = i.Cells["MaKM"].Value.ToString();
                    if (BLLClothShop.Instance.CheckDelKM(MaKM))
                    {
                        BLLClothShop.Instance.DelKM(MaKM);
                    }
                    else
                        MessageBox.Show("Không thể xóa khuyến mãi này");
                }
                ReLoadKM();
            }
        }
        private void buttonTK_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLClothShop.Instance.GetAllKM(tbSearch.Text);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string txt = null;
            if (BLLClothShop.Instance.CheckNum(tbTgLuuKho.Text) == -1 || BLLClothShop.Instance.CheckNum(tbTileBan.Text) == -1) 
                txt = "Không thể rỗng";
            else if (BLLClothShop.Instance.CheckNum(tbTgLuuKho.Text) == 1 || BLLClothShop.Instance.CheckNum(tbTileBan.Text) == 1) 
                txt = "Không thể chứa các ký tự khác ngoài số";
            if (txt == null)
            {
                ReLoadGoiY(Convert.ToInt32(tbTgLuuKho.Text), Convert.ToDouble(tbTileBan.Text));
            }
            else
            {
                Form formBackground = new Form();
                try
                {
                    using (Form_Message f = new Form_Message(txt))
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
    }
}
