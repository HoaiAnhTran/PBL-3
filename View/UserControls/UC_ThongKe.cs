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
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();
            Reload();
        }
        public void Reload()
        {
            int m = DateTime.Now.Month;
            lbDoanhThu.Text = BLLClothShop.Instance.GetDoanhSo(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now).ToString();
            lbDonHang.Text = BLLClothShop.Instance.GetSLHoaDon(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now).ToString();
            lbLoiNhuan.Text = BLLClothShop.Instance.GetLoiNhuan(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now).ToString();
            double x = BLLClothShop.Instance.GetLoiNhuan(new DateTime(DateTime.Now.Year, m, 1).AddDays(-30), DateTime.Now.AddDays(-30));
            if (x > Convert.ToDouble(lbLoiNhuan.Text))
                lbSoSanh.Text = "Giảm " +  (x - Convert.ToDouble(lbLoiNhuan.Text)).ToString();
            else lbSoSanh.Text = "Tăng " + (Convert.ToDouble(lbLoiNhuan.Text) - x).ToString();
            chartDoanhThu.Series["s2"].Points.Clear();
            chartDoanhThu.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            List<int> s = BLLClothShop.Instance.GetDS12m();
            string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            for (int i = 11; i >= 0; i--)
            {
                if (m <= i)
                    chartDoanhThu.Series["s2"].Points.AddXY(month[m + 12 - i - 1], s[11 - i]);
                else
                    chartDoanhThu.Series["s2"].Points.AddXY(month[m - i - 1], s[11 - i]);
            }
            chartSPDS.ChartAreas["ChartArea1"].AxisY.Interval = 0;
            chartSPDS.Series["sds"].Points.Clear();
            foreach (var i in BLLClothShop.Instance.GetTopSPDS(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now))
                chartSPDS.Series["sds"].Points.AddXY(i.TenSP, i.DoanhSo);
            chartSPSL.ChartAreas["ChartArea1"].AxisY.Interval = 0;
            chartSPSL.Series["ssl"].Points.Clear();
            foreach (var i in BLLClothShop.Instance.GetTopSPSL(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now))
                chartSPSL.Series["ssl"].Points.AddXY(i.TenSP, i.SoLuong);
            chartKH.ChartAreas["ChartArea1"].AxisY.Interval = 0;
            chartKH.Series["skh"].Points.Clear();
            foreach (var i in BLLClothShop.Instance.GetTopKH(new DateTime(DateTime.Now.Year, m, 1), DateTime.Now))
                chartKH.Series["skh"].Points.AddXY(i.TenKH, i.TongMua);
        }
    }
}
