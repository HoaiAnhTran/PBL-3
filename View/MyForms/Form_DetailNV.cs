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
    public partial class Form_DetailNV : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        string MaNV;
        public Form_DetailNV(string nv)
        {
            InitializeComponent();
            MaNV = nv;
            GUI();
        }
        public void GUI()
        {
            if (MaNV != null)
            {
                lbTitle.Text = "Cập nhật nhân viên";
                tbMaNV.Text = MaNV;
                tbTenNV.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).TenNV;
                if (BLLClothShop.Instance.GetNVByMaNV(MaNV).GioiTinh)
                    rbNam.Checked = true;
                else rbNu.Checked = true;
                cbbChucVu.SelectedItem = BLLClothShop.Instance.GetNVByMaNV(MaNV).ChucVu;
                tbDiaChi.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).DiaChi;
                tbSDT.Text = BLLClothShop.Instance.GetNVByMaNV(MaNV).Sdt;
            }
            else
            {
                string rand;
                do
                {
                    rand = "NV" + BLLClothShop.Instance.GetRandom();
                }
                while (BLLClothShop.Instance.GetNVByMaNV(rand) != null);    //lặp lại nếu đã tồn tại mã nv
                tbMaNV.Text = rand;
                cbbChucVu.SelectedIndex = 0;
            }
        }    
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (tbTenNV.Text == null || tbTenNV.Text == "") 
                MessageBox.Show("Tên nhân viên không thể rỗng");
            else
            {
                NhanVien s = new NhanVien
                {
                    MaNV = tbMaNV.Text,
                    TenNV = tbTenNV.Text,
                    DiaChi = (tbDiaChi.Text != "") ? tbDiaChi.Text : "",
                    Sdt = (tbSDT.Text != "") ? tbSDT.Text : "",
                    GioiTinh = rbNam.Checked,
                    ChucVu = cbbChucVu.SelectedItem.ToString(),
                    MatKhau = (BLLClothShop.Instance.GetNVByMaNV(MaNV) == null) ? "123" : BLLClothShop.Instance.GetNVByMaNV(MaNV).MatKhau,
                };
                BLLClothShop.Instance.AddUpdateNV(s);
                d();
                this.Close();
            }
        }
    }
}
