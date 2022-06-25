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

namespace ClothShop.View.UserControls
{
    public partial class UC_Account : UserControl
    {
        string MaNV;
        public UC_Account(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            GUI();
        }
        public void GUI()
        {
            tbHoTen.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
            tbDiaChi.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).DiaChi;
            tbSDT.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).Sdt;
            if (BLLClothShop.Instance.GetNVByMaNV(MaNV).GioiTinh)
                rbNam.Checked = true;
            else rbNữ.Checked = true;
            if (BLLClothShop.Instance.GetNVByMaNV(MaNV).Anh != null)
            {
                pictureBox2.Image = BLLClothShop.Instance.ByteToImg(BLLClothShop.Instance.GetNVByMaNV(MaNV).Anh);
            }
        }

        private void buttonLuu1_Click(object sender, EventArgs e)       //Cập nhật thông tin TK
        {
            NhanVien s = new NhanVien
            {
                MaNV = MaNV,
                TenNV = tbHoTen.Text,
                DiaChi = tbDiaChi.Text,
                Sdt = tbSDT.Text,
                GioiTinh = rbNam.Checked,
                ChucVu = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu,
                MatKhau = BLLClothShop.Instance.GetNVByMaNV(MaNV).MatKhau,
                Anh = (pictureBox2.Image != null) ? BLLClothShop.Instance.ImageToByteArray(pictureBox2.Image) : null,
            };
            BLLClothShop.Instance.AddUpdateNV(s);
            MessageBox.Show("Cập nhật thông tin cá nhân thành công");
        }

        private void buttonLuu2_Click(object sender, EventArgs e)       //Đổi MK
        {
            if (tbMKCu.Text == BLLClothShop.Instance.GetNVByMaNV(MaNV).MatKhau)
            {
                if (tbMKMoi.Text == tbMKMoi2.Text)
                {
                    NhanVien s = new NhanVien
                    {
                        MaNV = MaNV,
                        TenNV = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV,
                        DiaChi = BLLClothShop.Instance.GetNVByMaNV(MaNV).DiaChi,
                        Sdt = BLLClothShop.Instance.GetNVByMaNV(MaNV).Sdt,
                        GioiTinh = BLLClothShop.Instance.GetNVByMaNV(MaNV).GioiTinh,
                        ChucVu = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu,
                        MatKhau = tbMKMoi.Text
                    };
                    BLLClothShop.Instance.AddUpdateNV(s);
                    MessageBox.Show("Đổi mật khẩu thành công");
                    tbMKCu.Text = "";
                    tbMKMoi.Text = "";
                    tbMKMoi2.Text = "";
                }
                else 
                    MessageBox.Show("Mật khẩu mới nhập lại không trùng khớp");
            }
            else 
                MessageBox.Show("Nhập sai mật khẩu cũ");
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
                pictureBox2.Image = BLLClothShop.Instance.ByteToImg(picbyte);
                fs.Close();
                //pictureBox1.Image = ByteToImg(Convert.ToBase64String(converImgToByte(openFile.FileName)));
            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }
    }
}
