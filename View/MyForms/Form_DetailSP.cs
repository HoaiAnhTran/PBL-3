using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothShop.BLL;
using ClothShop.DTO;
using QRCoder;

namespace ClothShop.View.MyForms
{
    public partial class Form_DetailSP : Form
    {
        List<string> size = new List<string>();
        List<string> mau = new List<string>();
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaSP, MaNV;
        public Form_DetailSP(string sp, string nv)
        {
            InitializeComponent();
            MaSP = sp;
            MaNV = nv;
            ReLoadCbb();
            BLLClothShop.Instance.CopySP(MaSP);
            GUI();
        }
        public void ReLoadCbb()
        {
            cbbNhomSP.Items.Clear();
            cbbNhomSP.Items.AddRange(BLLClothShop.Instance.GetAllNhomSP().ToArray());
            cbbNhomSP.SelectedIndex = 0;
            //cbbNhomSP.Items.RemoveAt(cbbNhomSP.SelectedIndex);
        }
        public void GUI()
        {
            if (MaSP != null)
            {
                lbTitle.Text = "Cập nhật sản phẩm";
                tbMaSP.Text = MaSP;
                tbMaSP.Enabled = false;
                tbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).TenSP;
                //cbbNhomSP.SelectedItem = BLLClothShop.Instance.GetSPByMaSP(MaSP).NhomSP;
                foreach (CBBNhomSP i in cbbNhomSP.Items)
                {
                    if (i.Value == BLLClothShop.Instance.GetSPByMaSP(MaSP).ID_NhomSP)
                        cbbNhomSP.SelectedItem = i;
                }
                tbGiaBan.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).GiaBan.ToString();
                tbKhuyenMai.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).KhuyenMai.ToString();
                if (BLLClothShop.Instance.GetSPByMaSP(MaSP).Anh != null)
                {
                    pictureBox1.Image = BLLClothShop.Instance.ByteToImg(BLLClothShop.Instance.GetSPByMaSP(MaSP).Anh);
                }
                size = BLLClothShop.Instance.GetCBBSizeByMaSP("SP00000000");
                mau = BLLClothShop.Instance.GetCBBMauByMaSP("SP00000000");
                dataGridView1.DataSource = size.Select( x=> new {Size = x}).ToList();
                dataGridView2.DataSource = mau.Select(x => new { Mau = x }).ToList();
            }
            else
            {
                Random rd = new Random();
                string rand;
                do
                {
                    rand = "";
                    rand = rd.Next(0, 99999999).ToString();
                    for (int i = 0; i < (8 - rand.Length); i++)
                        rand = "0" + rand;
                    rand = "SP" + rand;
                }
                while (BLLClothShop.Instance.GetSPByMaSP(rand) != null);
                tbMaSP.Text = rand;
                tbMaSP.Enabled = false;
                size.Add("Freesize");
                mau.Add("Mặc định");
                BLLClothShop.Instance.AddCTSP("SP00000000", "Freesize", "Mặc định");
                dataGridView1.DataSource = size.Select(x => new { Size = x }).ToList();
                dataGridView2.DataSource = mau.Select(x => new { Mau = x }).ToList();
            }
        }
        // thêm kiểm tra nhập đúng không?
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (tbGiaBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá bán");
                return;
            }
            if (Convert.ToInt32(tbGiaBan.Text) == 0)
            {
                MessageBox.Show("Giá bán không thể bằng 0");
                return;
            }
            foreach (char i in tbGiaBan.Text)
            {
                if ((i < '0') || (i > '9'))
                {
                    MessageBox.Show("Giá bán không hợp lệ");
                    tbGiaBan.Text = "0";
                    return;
                }
            }          
            SanPham sp = new SanPham
            {
                MaSP = tbMaSP.Text,
                TenSP = tbTenSP.Text,
                ID_NhomSP = ((CBBNhomSP)cbbNhomSP.SelectedItem).Value,
                GiaBan = (tbGiaBan.Text != "") ? Convert.ToInt32(tbGiaBan.Text) : 0,
                KhuyenMai = (tbKhuyenMai.Text != "") ? Convert.ToDouble(tbKhuyenMai.Text)/100 : 0,
                Anh = (pictureBox1.Image != null) ? BLLClothShop.Instance.ImageToByteArray(pictureBox1.Image) : null,
            };
            BLLClothShop.Instance.AddUpdateSP(sp);
            BLLClothShop.Instance.PasteSP(tbMaSP.Text);
            d();
            this.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_AddNhomSP f = new MyForms.Form_AddNhomSP())
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
                    f.d = new Form_AddNhomSP.MyDel(ReLoadCbb);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                tbSize.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                lbSizeIndex.Text = dataGridView1.SelectedRows[0].Index.ToString();
            }    
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                tbMau.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                lbMauIndex.Text = dataGridView2.SelectedRows[0].Index.ToString();
            }
        }

        private void btAddSize_Click(object sender, EventArgs e)
        {
            tbSize.Text = "";
            lbSizeIndex.Text = "";
        }

        private void btAddMau_Click(object sender, EventArgs e)
        {
            tbMau.Text = "";
            lbMauIndex.Text = "";
        }

        private void btSaveSize_Click(object sender, EventArgs e)
        {
            if (lbSizeIndex.Text == "")
            {
                size.Add(tbSize.Text);
                foreach (string i in mau)
                {
                    BLLClothShop.Instance.AddCTSP("SP00000000", tbSize.Text, i);
                }    
            }
            else
            {
                int index = Convert.ToInt32(lbSizeIndex.Text);
                foreach (var i in BLLClothShop.Instance.GetCTSPByMaSP("SP00000000",size[index],"All"))
                {
                    CTSanPham s = new CTSanPham
                    {
                        MaCTSP = i.MaCTSP,
                        MauSac = i.MauSac,
                        Size = tbSize.Text,
                        SoLuong = i.SoLuong,
                        MaSP = BLLClothShop.Instance.GetCTSPByMaCTSP(i.MaCTSP).MaSP,
                    };
                    BLLClothShop.Instance.AddUpdateCTSP(s);
                }
                size[index] = tbSize.Text;
            }
            dataGridView1.DataSource = size.Select(x => new { Size = x }).ToList();
        }

        private void btSaveMau_Click(object sender, EventArgs e)
        {
            if (lbMauIndex.Text == "")
            {
                mau.Add(tbMau.Text);
                //MessageBox.Show(size.ToString());
                foreach (string i in size)
                {
                    BLLClothShop.Instance.AddCTSP("SP00000000", i, tbMau.Text);
                }
            }
            else
            {
                int index = Convert.ToInt32(lbMauIndex.Text);
                foreach (var i in BLLClothShop.Instance.GetCTSPByMaSP("SP00000000", "All", mau[index]))
                {
                    CTSanPham s = new CTSanPham
                    {
                        MaCTSP = i.MaCTSP,
                        MauSac = tbMau.Text,
                        Size = i.Size,
                        SoLuong = i.SoLuong,
                        MaSP = BLLClothShop.Instance.GetCTSPByMaCTSP(i.MaCTSP).MaSP,
                    };
                    BLLClothShop.Instance.AddUpdateCTSP(s);
                }
                mau[index] = tbMau.Text;
            }
            dataGridView2.DataSource = mau.Select(x => new { Mau = x }).ToList();
        }

        private void btDeleteSize_Click(object sender, EventArgs e)
        {
            if (size.Count == 1)
                MessageBox.Show("Phải có ít nhất 1 Size");
            else if (lbSizeIndex.Text != "")
            {
                if (BLLClothShop.Instance.CheckDelSize("SP00000000", size[Convert.ToInt32(lbSizeIndex.Text)]))
                {
                    foreach (var i in BLLClothShop.Instance.GetCTSPByMaSP("SP00000000", size[Convert.ToInt32(lbSizeIndex.Text)],"All"))
                    {
                        BLLClothShop.Instance.DelCTSP(i.MaCTSP);
                    }
                    size.RemoveAt(Convert.ToInt32(lbSizeIndex.Text));
                }
                else
                    MessageBox.Show("Không thể xóa size đã được sử dụng");
            }
            dataGridView1.DataSource = size.Select(x => new { Size = x }).ToList();
        }

        private void btDeleteMau_Click(object sender, EventArgs e)
        {
            if (mau.Count == 1)
                MessageBox.Show("Phải có ít nhất 1 Màu");
            else if (lbMauIndex.Text != "")
            {
                if (BLLClothShop.Instance.CheckDelMau("SP00000000",mau[Convert.ToInt32(lbMauIndex.Text)]))
                {
                    foreach (var i in BLLClothShop.Instance.GetCTSPByMaSP("SP00000000", "All", mau[Convert.ToInt32(lbMauIndex.Text)]))
                    {
                        BLLClothShop.Instance.DelCTSP(i.MaCTSP);
                    }
                    mau.RemoveAt(Convert.ToInt32(lbMauIndex.Text));
                }
                else
                    MessageBox.Show("Không thể xóa màu đã được sử dụng");
            }   
            dataGridView2.DataSource = mau.Select(x => new { Mau = x }).ToList();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;
                fs = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
                byte[] picbyte = new byte[fs.Length];
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                pictureBox1.Image = BLLClothShop.Instance.ByteToImg(picbyte);
                fs.Close();
                //pictureBox1.Image = ByteToImg(Convert.ToBase64String(converImgToByte(openFile.FileName)));
            }
        }
        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            foreach (var i in BLLClothShop.Instance.GetCTSPByMaSP("SP00000000","All","All"))
            {
                BLLClothShop.Instance.DelCTSP(i.MaCTSP);
            }    
            this.Close();
        }
    }
}
