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

namespace ClothShop.View.MyForms
{
    public partial class Form_DetailHD : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaHD,MaNV;
        public Form_DetailHD(string hd, string nv)
        {
            InitializeComponent();
            MaHD = hd;
            MaNV = nv;
            GUI();
            BLLClothShop.Instance.CopyHD(MaHD);
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
                rand = "CH" + rand;
            }
            while (BLLClothShop.Instance.GetCTHDByMaCTHD(rand) != null);
            tbMaCTHD.Text = rand;
            dataGridView1.DataSource = BLLClothShop.Instance.GetCTHDByMaHD("HD00000000");
            dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView();
            dataGridView2.Rows[0].Selected = true;
            cbbSearchKH.SelectedIndex = 0;
            lbMaSP.Text = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
            tbSoLuong.Text = "0";
            lbSoLuong.Text = BLLClothShop.Instance.GetSoLuongHD("HD00000000").ToString();
            lbTong.Text = BLLClothShop.Instance.GetTongHD("HD00000000").ToString();
            lbThanhTien.Text = (Convert.ToInt32(lbTong.Text)*(1 - Convert.ToDouble(lbGiaTriKM.Text)/100)).ToString();
        }
        public void GUI()
        {
            if (MaHD != null)
            {
                lbTitle.Text = "Cập nhật hóa đơn";
                lbMaHD.Text = MaHD;
                lbMaNV.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).ID_NguoiTao;
                lbTenNV.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).NguoiTao.TenNV;
                lbNgayTao.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).NgayTao.ToString();
                lbTenKH.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).KhachHang.TenKH;
                lbMaKH.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).MaKH;
                tbMaKM.Text = BLLClothShop.Instance.GetHDByMaHD(MaHD).MaKM; 
                lbTenKM.Text = (tbMaKM.Text != "") ? BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).TenKM : "";
                lbGiaTriKM.Text = (tbMaKM.Text != "") ? (BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).GiaTri*100).ToString() : "0";
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
                    rand = "HD" + rand;
                }
                while (BLLClothShop.Instance.GetHDByMaHD(rand) != null);
                lbMaHD.Text = rand;
                lbMaKH.Text = "KH00000000";
                lbTenKH.Text = BLLClothShop.Instance.GetKHByMaKH(lbMaKH.Text).TenKH;
                lbMaNV.Text = MaNV;
                lbTenNV.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
                lbNgayTao.Text = DateTime.Now.ToString();
                tbMaKM.Text = "";
                lbTenKM.Text = "";
                lbGiaTriKM.Text = "0";
            }    
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaCTHD = dataGridView1.SelectedRows[0].Cells["MaCTHD"].Value.ToString();
                tbMaCTHD.Text = MaCTHD;
                lbMaSP.Text = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTHDByMaCTHD(MaCTHD).MaCTSP).MaSP; 
                cbbSize.Items.Clear();
                foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(lbMaSP.Text))
                {
                    cbbSize.Items.Add(i.ToString());
                }
                cbbSize.SelectedItem = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTHDByMaCTHD(MaCTHD).MaCTSP).Size;
                cbbMauSac.Items.Clear();
                foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(lbMaSP.Text))
                {
                    cbbMauSac.Items.Add(i.ToString());
                }
                cbbMauSac.SelectedItem = BLLClothShop.Instance.GetCTSPByMaCTSP(BLLClothShop.Instance.GetCTHDByMaCTHD(MaCTHD).MaCTSP).MauSac;
                tbSoLuong.Text = BLLClothShop.Instance.GetCTHDByMaCTHD(MaCTHD).SoLuong.ToString();
            }    
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            { 
                string MaSP = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
                lbMaSP.Text = MaSP;
                cbbSize.Items.Clear();
                //cbbSize.Items.AddRange(BLLClothShop.Instance.GetSizeByMaSP(MaSP).ToArray());
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
                //cbbMauSac.Items.AddRange(BLLClothShop.Instance.GetMauByMaSP(MaSP).ToArray());
                cbbMauSac.SelectedIndex = 0;
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
                rand = "CH" + rand;
            }
            while (BLLClothShop.Instance.GetCTHDByMaCTHD(rand) != null);
            tbMaCTHD.Text = rand;
            tbSoLuong.Text = "";
            dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView();
            dataGridView2.Rows[0].Selected = true; 
            lbMaSP.Text = dataGridView2.SelectedRows[0].Cells["MaSP"].Value.ToString();
            cbbSize.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBSizeByMaSP(lbMaSP.Text))
            {
                cbbSize.Items.Add(i.ToString());
            }
            cbbSize.SelectedIndex = 0;
            cbbMauSac.Items.Clear();
            foreach (var i in BLLClothShop.Instance.GetCBBMauByMaSP(lbMaSP.Text))
            {
                cbbMauSac.Items.Add(i.ToString());
            }
            cbbMauSac.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Form formBackground = new Form();
                try
                {
                    using (Form_XacNhanDX f = new Form_XacNhanDX())
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
                        f.d = new Form_XacNhanDX.MyDel(DelCTHD);
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
        public void DelCTHD()
        {
            foreach (DataGridViewRow i in dataGridView1.SelectedRows)
            {
                BLLClothShop.Instance.DelCTHD(i.Cells["MaCTHD"].Value.ToString());
            }
            ReLoad();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            string txt = null;
            if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == -1) txt = "Số lượng không thể rỗng";
            else if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == 0) txt = "Số lượng không thể bằng không";
            else if (BLLClothShop.Instance.CheckNum(tbSoLuong.Text) == -1) txt = "Số lượng không không thể chứa các ký tự khác ngoài số";
            if (txt == null)
            {
                foreach (char i in tbSoLuong.Text)
                {
                    if ((i < '0') || (i > '9'))
                    {
                        MessageBox.Show("Số lượng không hợp lệ");
                        tbSoLuong.Text = "";
                        return;
                    }
                }
                string MaCTSP = BLLClothShop.Instance.GetCTSPByMaSP(lbMaSP.Text, cbbSize.SelectedItem.ToString(), cbbMauSac.SelectedItem.ToString())[0].MaCTSP;
                CTHoaDon s = null;
                foreach (var i in BLLClothShop.Instance.GetCTHDByMaHD("HD00000000"))
                {
                    if (BLLClothShop.Instance.GetCTHDByMaCTHD(i.MaCTHD).MaCTSP == MaCTSP)
                    {
                        s = new CTHoaDon
                        {
                            MaCTHD = i.MaCTHD,
                            MaHD = "HD00000000",
                            MaCTSP = BLLClothShop.Instance.GetCTSPByMaSP(lbMaSP.Text, cbbSize.SelectedItem.ToString(), cbbMauSac.SelectedItem.ToString())[0].MaCTSP,
                            GiaBan = BLLClothShop.Instance.GetSPByMaSP(lbMaSP.Text).GiaBan,
                            SoLuong = (i.MaCTHD != "AO" + tbMaCTHD.Text.Substring(2)) ? BLLClothShop.Instance.GetCTHDByMaCTHD(i.MaCTHD).SoLuong + Convert.ToInt32(tbSoLuong.Text) : Convert.ToInt32(tbSoLuong.Text),
                        };
                    }
                }
                if (s == null)
                    s = new CTHoaDon
                    {
                        MaCTHD = "AO" + tbMaCTHD.Text.Substring(2),
                        MaHD = "HD00000000",
                        MaCTSP = MaCTSP,
                        GiaBan = BLLClothShop.Instance.GetSPByMaSP(lbMaSP.Text).GiaBan,
                        SoLuong = Convert.ToInt32(tbSoLuong.Text),
                    };
                if (BLLClothShop.Instance.GetCTSPByMaCTSP(s.MaCTSP).SoLuong < s.SoLuong)
                    MessageBox.Show("Không đủ số lượng. Số lượng còn lại trong kho: " + BLLClothShop.Instance.GetCTSPByMaCTSP(s.MaCTSP).SoLuong);
                else
                    BLLClothShop.Instance.AddUpdateCTHD(s);
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
            HoaDon s = new HoaDon
            {
                MaHD = lbMaHD.Text,
                MaKH = (lbMaKH.Text != "")?lbMaKH.Text:"KH00000000",
                MaKM = (tbMaKM.Text != "")?tbMaKM.Text:null,
                GiaTriKM = (tbMaKM.Text != "") ? Convert.ToDouble(lbGiaTriKM.Text)/100 : 0,
                ID_NguoiTao = lbMaNV.Text,
                NgayTao = Convert.ToDateTime(lbNgayTao.Text),
                ID_NguoiSua = MaNV,
                NgaySua = DateTime.Now,
            };
            BLLClothShop.Instance.AddUpdateHD(s);
            BLLClothShop.Instance.PasteHD(lbMaHD.Text);
            d();
            this.Close();
        }

        private void btSearchSP_Click(object sender, EventArgs e)
        {
             dataGridView2.DataSource = BLLClothShop.Instance.GetAllSPView(tbSearchSP.Text);
        }

        private void btSearchKH_Click(object sender, EventArgs e)
        {
            if (cbbSearchKH.SelectedIndex == 0)
            { 
                if (BLLClothShop.Instance.GetKHBySDT(tbSearchKH.Text) == null)
                {
                    MessageBox.Show("Không tồn tại khách hàng có SDT này!");
                }
                else
                {
                    lbMaKH.Text = BLLClothShop.Instance.GetKHBySDT(tbSearchKH.Text);
                    lbTenKH.Text = BLLClothShop.Instance.GetKHByMaKH(lbMaKH.Text).TenKH;
                } 
                    
            }
            else
            {
                if (BLLClothShop.Instance.GetKHByMaKH(tbSearchKH.Text) == null)
                {
                    MessageBox.Show("Không tồn tại khách hàng có SDT này!");
                }
                else
                {
                    lbMaKH.Text = BLLClothShop.Instance.GetKHByMaKH(tbSearchKH.Text).MaKH;
                    lbTenKH.Text = BLLClothShop.Instance.GetKHByMaKH(lbMaKH.Text).TenKH;
                }
            } 
                
        }

        private void btCheckKM_Click(object sender, EventArgs e)
        {
            if (BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text) == null )
            {
                MessageBox.Show("Mã Khuyến mãi không hợp lệ");
                tbMaKM.Text = "";
                lbTenKM.Text = "";
                lbGiaTriKM.Text = "0";
            }
            else if (DateTime.Now < BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).NgayApDung || BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).NgayApDung.AddDays(BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).HanSuDung) < DateTime.Now)
            {
                MessageBox.Show("Mã đã hết hạn sử dụng");
                tbMaKM.Text = "";
                lbTenKM.Text = "";
                lbGiaTriKM.Text = "0";
            }
            else
            {
                lbTenKM.Text = BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).TenKM;
                lbGiaTriKM.Text = (BLLClothShop.Instance.GetKMByMaKM(tbMaKM.Text).GiaTri*100).ToString();
            }
            ReLoad();
        }

        private void btnScanQR_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (Form_ScanQRCode f = new Form_ScanQRCode())
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
                    f.d = new Form_ScanQRCode.MyDel(ReLoad);
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
            //Form_ScanQRCode f = new Form_ScanQRCode(); 
            //f.d = new Form_ScanQRCode.MyDel(ReLoad);
            //f.Show();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                BLLClothShop.Instance.DelCTHD(i.Cells["MaCTHD"].Value.ToString());
            }
            this.Close();
        }
    }
}
