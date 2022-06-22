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
                ChucVu = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu
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
    }
}
