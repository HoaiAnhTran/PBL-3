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

namespace ClothShop.View.MyForms
{
    public partial class Form_DetailNK : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaNK, MaNV;
        string MaNguoiTao = null, MaNCC = null , MaSP = null;
        public Form_DetailNK(string nk, string nv)
        {
            InitializeComponent();
            MaNK = nk;
            MaNV = nv;
            GUI();
            BLLClothShop.Instance.CopyNK(MaNK);
            ReLoad();
        }
        public void ReLoad()
        {
            Random rd = new Random();
            string rand;
            do
            {
                rand = "";
                rand = rd.Next(0, 99999999).ToString();
                for (int i = 0; i < (8 - rand.Length); i++)
                    rand = "0" + rand;
                rand = "CN" + rand;
            }
            while (BLLClothShop.Instance.GetCTNKByMaCTNK(rand) != null);
            lbMaCTNK.Text = rand;
            dataGridView1.DataSource = BLLClothShop.Instance.GetCTNKByMaNK("NK00000000");
            dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView();
            dataGridView2.Rows[0].Selected = true;
            cbbSearchNCC.SelectedIndex = 0;
            MaSP = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
            lbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).TenSP;
            cbbSize.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(MaSP))
            {
                cbbSize.Items.Add(i.ToString());
            }
            cbbSize.SelectedIndex = 0;
            cbbMauSac.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(MaSP))
            {
                cbbMauSac.Items.Add(i.ToString());
            }
            cbbMauSac.SelectedIndex = 0;
            tbGiaNhap.Text = "";
            tbSoLuong.Text = "";
            lbTongSL.Text = BLLClothShop.Instance.GetSoLuongNK("NK00000000").ToString();
            lbTong.Text = BLLClothShop.Instance.GetTongNK("NK00000000").ToString();
        }
        public void GUI()
        {
            if (MaNK != null)
            {
                lbMaNK.Text = BLLClothShop.Instance.GetNKByMaNK(MaNK).MaNK;
                MaNCC = BLLClothShop.Instance.GetNKByMaNK(MaNK).MaNCC;
                lbNgayTao.Text = BLLClothShop.Instance.GetNKByMaNK(MaNK).NgayTao.ToString();
                MaNguoiTao = BLLClothShop.Instance.GetNKByMaNK(MaNK).ID_NguoiTao;
                lbTenNV.Text = BLLClothShop.Instance.GetNKByMaNK(MaNK).NguoiTao.TenNV;
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
                    rand = "NK" + rand;
                }
                while (BLLClothShop.Instance.GetNKByMaNK(rand) != null);
                lbMaNK.Text = rand;
                lbNgayTao.Text = DateTime.Now.ToString();
                MaNguoiTao = BLLClothShop.Instance.GetNVByMaNV(MaNV).MaNV;
                lbTenNV.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
            }    
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaCTNK = dataGridView1.SelectedRows[0].Cells["MaCTNK"].Value.ToString();
                if (MaCTNK != null)
                {
                    MaSP = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).MaCTSP).MaSP;
                    //lbMaSP.Text = BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).CTSanPham.MaSP;
                    lbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).TenSP;
                    lbMaCTNK.Text = BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).MaCTNK;
                    cbbSize.Items.Clear();
                    foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(MaSP))
                    {
                        cbbSize.Items.Add(i.ToString());
                    }
                    cbbSize.SelectedItem = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).MaCTSP).Size;
                    cbbMauSac.Items.Clear();
                    foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(MaSP))
                    {
                        cbbMauSac.Items.Add(i.ToString());
                    }
                    cbbMauSac.SelectedItem = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).MaCTSP).MauSac;
                    tbGiaNhap.Text = BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).GiaNhap.ToString();
                    tbSoLuong.Text = BLLClothShop.Instance.GetCTNKByMaCTNK(MaCTNK).SoLuong.ToString();
                }
            }
                    
        }

        private void btMoi_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            string rand;
            do
            {
                rand = "";
                rand = rd.Next(0, 99999999).ToString();
                for (int i = 0; i < (8 - rand.Length); i++)
                    rand = "0" + rand;
                rand = "CN" + rand;
            }
            while (BLLClothShop.Instance.GetCTNKByMaCTNK(rand) != null);
            lbMaCTNK.Text = rand;
            dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView();
            dataGridView2.Rows[0].Selected = true;
            MaSP = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
            cbbSize.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(MaSP))
            {
                cbbSize.Items.Add(i.ToString());
            }
            cbbSize.SelectedIndex = 0;
            cbbMauSac.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(MaSP))
            {
                cbbMauSac.Items.Add(i.ToString());
            }
            cbbMauSac.SelectedIndex = 0;
            tbSoLuong.Text = "";
            tbGiaNhap.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string MaCTNK= i.Cells["MaCTNK"].Value.ToString();
                    BLLClothShop.Instance.DelCTNK(MaCTNK);
                }
                ReLoad();
            }
        }

        private void buttonThem_Click(object sender, EventArgs e) // xem lại xóa
        {
            string txt = null;
            if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == -1) txt = "Số lượng không thể rỗng";
            else if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == 0) txt = "Số lượng không thể bằng không";
            else if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == -1) txt = "Số lượng không không thể chứa các ký tự khác ngoài số";
            if (txt == null)
            {
                string MaCTSP = BLLClothShop.Instance.GetCTSPByMaSP(MaSP, cbbSize.SelectedItem.ToString(), cbbMauSac.SelectedItem.ToString())[0].MaCTSP;
                CTNhapKho s = null;
                foreach (var i in BLLClothShop.Instance.GetCTNKByMaNK("NK00000000"))
                {
                    if (BLLClothShop.Instance.GetCTNKByMaCTNK(i.MaCTNK).MaCTSP == MaCTSP)
                    {
                        //MessageBox.Show("helo");
                        s = new CTNhapKho
                        {
                            MaCTNK = i.MaCTNK,
                            MaNK = "NK00000000",
                            MaCTSP = BLLClothShop.Instance.GetCTSPByMaSP(MaSP, cbbSize.SelectedItem.ToString(), cbbMauSac.SelectedItem.ToString())[0].MaCTSP,
                            GiaNhap = Convert.ToInt32(tbGiaNhap.Text),
                            SoLuong = (i.MaCTNK != "AO" + lbMaCTNK.Text.Substring(2)) ? BLLClothShop.Instance.GetCTNKByMaCTNK(i.MaCTNK).SoLuong + Convert.ToInt32(tbSoLuong.Text) : Convert.ToInt32(tbSoLuong.Text),
                        };
                    }
                }
                if (s == null)
                    s = new CTNhapKho
                    {
                        MaCTNK = "AO" + lbMaCTNK.Text.Substring(2),
                        MaNK = "NK00000000",
                        MaCTSP = MaCTSP,
                        GiaNhap = Convert.ToInt32(tbGiaNhap.Text),
                        SoLuong = Convert.ToInt32(tbSoLuong.Text),
                    };
                BLLClothShop.Instance.AddUpdateCTNK(s);
                ReLoad();
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

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (MaNCC == null)
            {
                MessageBox.Show("Không thể để trống nhà cung cấp");
                return;
            }
            NhapKho s = new NhapKho
            {
                MaNK =  lbMaNK.Text,
                MaNCC = (MaNCC != "") ? MaNCC : "NCC0000000",
                NgayTao = Convert.ToDateTime(lbNgayTao.Text),
                ID_NguoiTao = MaNguoiTao,
                NgaySua = DateTime.Now,
                ID_NguoiSua = MaNV,
            };
            BLLClothShop.Instance.AddUpdateNK(s);
            BLLClothShop.Instance.PasteNK(lbMaNK.Text);
            d();
            this.Close();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                MaSP = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
                lbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(MaSP).TenSP;
                cbbSize.Items.Clear();
                foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(MaSP))
                {
                    cbbSize.Items.Add(i.ToString());
                }
                cbbSize.SelectedIndex = 0;
                cbbMauSac.Items.Clear();
                foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(MaSP))
                {
                    cbbMauSac.Items.Add(i.ToString());
                }
                cbbMauSac.SelectedIndex = 0;
            }    
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView(tbSearchSP.Text);
        }

        private void btAddSize_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (MyForms.Form_DetailSP f = new MyForms.Form_DetailSP(null, MaNV))
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
                    f.d = new MyForms.Form_DetailSP.MyDel(ReLoad);
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
            //Form_DetailSP f = new Form_DetailSP(null, MaNV);
            //f.d = new Form_DetailSP.MyDel(ReLoad);
            //f.Show();
        }

        private void btSearchNCC_Click(object sender, EventArgs e)
        {
            if (cbbSearchNCC.SelectedIndex == 0)
            {
                if (BLLClothShop.Instance.GetNCCBySDT(tbSearchNCC.Text) == null)
                {
                    MessageBox.Show("Không tồn tại nhà cung cấp có SDT này!");
                }
                else
                {
                    MaNCC = BLLClothShop.Instance.GetNCCBySDT(tbSearchNCC.Text);
                    lbTenNCC.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).TenNCC;
                }

            }
            else
            {
                if (BLLClothShop.Instance.GetNCCByMaNCC(tbSearchNCC.Text) == null)
                {
                    MessageBox.Show("Không tồn tại nhà cung cấp có mã này!");
                }
                else
                {
                    MaNCC = tbSearchNCC.Text;
                    lbTenNCC.Text = BLLClothShop.Instance.GetNCCByMaNCC(MaNCC).TenNCC;
                }
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                BLLClothShop.Instance.DelCTNK(i.Cells["MaCTNK"].Value.ToString());
            }    
            this.Close();
        }
    }
}
