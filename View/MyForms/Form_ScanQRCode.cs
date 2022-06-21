using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ClothShop.BLL;
using ClothShop.DTO;

namespace ClothShop.View.MyForms
{
    public partial class Form_ScanQRCode : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice VideoCaptureDevice;
        public Form_ScanQRCode()
        {
            InitializeComponent();
            lbMaCTSP.Text = "";
        }
        private void butNo_Click(object sender, EventArgs e)
        {
            if (VideoCaptureDevice != null && VideoCaptureDevice.IsRunning)
                VideoCaptureDevice.Stop();
            this.Close();
        }
        public bool CheckTBNum()
        {
            if (tbSoLuong.Text == "" || tbSoLuong.Text == null) return false;
            foreach (char i in tbSoLuong.Text)
            {
                if ((i < '0') || (i > '9'))
                {
                    MessageBox.Show("Số lượng không hợp lệ");
                    tbSoLuong.Text = "";
                    return false;
                }
            }    
            return true;
        }
        private void Form_ScanORCode_Load(object sender, EventArgs e)
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void butYes_Click(object sender, EventArgs e)
        {
            lbMaCTSP.Text = "";
            tbSoLuong.Text = "";
            lbTenSP.Text = "Trống";
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[0].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            VideoCaptureDevice.Start();
            timer1.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox2.Image);
                if (result != null)
                {
                    if (BLLClothShop.Instance.GetCTSPByMaCTSP(result.ToString()) == null)
                    {
                        MessageBox.Show("Mã không hợp lệ");
                        lbMaCTSP.Text = "";
                        tbSoLuong.Text = "";
                        lbTenSP.Text = "Trống";
                        return;
                    }
                    lbMaCTSP.Text = result.ToString();
                    lbTenSP.Text = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(result.ToString()).MaSP).TenSP + " - " 
                                +  BLLClothShop.Instance.GetCTSPByMaCTSP(result.ToString()).MauSac + " - " + BLLClothShop.Instance.GetCTSPByMaCTSP(result.ToString()).Size;
                    timer1.Stop();
                    if (VideoCaptureDevice.IsRunning)
                        VideoCaptureDevice.Stop();
                }    
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbMaCTSP.Text != "" && CheckTBNum())
            {
                string MaCTHD;
                do
                {
                    MaCTHD = "CH" + BLLClothShop.Instance.GetRandom();
                }
                while (BLLClothShop.Instance.GetCTHDByMaCTHD(MaCTHD) != null);
                CTHoaDon s = null;
                foreach (var i in BLLClothShop.Instance.GetCTHDByMaHD("HD00000000"))
                {
                    if (BLLClothShop.Instance.GetCTHDByMaCTHD(i.MaCTHD).MaCTSP == lbMaCTSP.Text)
                    {
                        s = new CTHoaDon
                        {
                            MaCTHD = i.MaCTHD,
                            MaHD = "HD00000000",
                            MaCTSP = lbMaCTSP.Text,
                            GiaBan = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(lbMaCTSP.Text).MaSP).GiaBan,
                            KhuyenMai = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(lbMaCTSP.Text).MaSP).KhuyenMai,
                            SoLuong = BLLClothShop.Instance.GetCTHDByMaCTHD(i.MaCTHD).SoLuong + Convert.ToInt32(tbSoLuong.Text),
                        };
                    }
                }
                if (s == null)
                    s = new CTHoaDon
                    {
                        MaCTHD = "AO" + MaCTHD.Substring(2),
                        MaHD = "HD00000000",
                        MaCTSP = lbMaCTSP.Text,
                        GiaBan = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(lbMaCTSP.Text).MaSP).GiaBan,
                        KhuyenMai = BLLClothShop.Instance.GetSPByMaSP(BLLClothShop.Instance.GetCTSPByMaCTSP(lbMaCTSP.Text).MaSP).KhuyenMai,
                        SoLuong = Convert.ToInt32(tbSoLuong.Text),
                    };
                if (BLLClothShop.Instance.GetCTSPByMaCTSP(s.MaCTSP).SoLuong < s.SoLuong)
                    MessageBox.Show("Không đủ số lượng. Số lượng còn lại trong kho: " + BLLClothShop.Instance.GetCTSPByMaCTSP(s.MaCTSP).SoLuong);
                else
                {
                    BLLClothShop.Instance.AddUpdateCTHD(s);
                    d();
                    this.Close();
                }
            } 
            else if (lbMaCTSP.Text == "" || lbMaCTSP.Text == null)
            {
                MessageBox.Show("Vui lòng scan sản phẩm");
            }    
            else if (CheckTBNum() == false)
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }    
        }
    }
}
