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
                if (BLLClothShop.Instance.GetNVByMaNV(MaNV).Anh != null)
                {
                    pictureBox1.Image = BLLClothShop.Instance.ByteToImg(BLLClothShop.Instance.GetNVByMaNV(MaNV).Anh);
                }
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
            foreach (char i in tbSDT.Text)
            {
                if ((i < '0' || i > '9') && i != '+')
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    return;
                }
            }
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
                    Anh = (pictureBox1.Image != null) ? BLLClothShop.Instance.ImageToByteArray(pictureBox1.Image) : null,
                };
                BLLClothShop.Instance.AddUpdateNV(s);
                d();
                this.Close();
            }
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
    }
}
