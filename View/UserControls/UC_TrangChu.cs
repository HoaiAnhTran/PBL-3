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
    public partial class UC_TrangChu : UserControl
    {
        public UC_TrangChu()
        {
            InitializeComponent();
            ReLoad();
            chartTron.Titles.Add("");
        }
        public void ReLoad()
        {
            lbSoLuong.Text = BLLClothShop.Instance.GetSLSPBan(DateTime.Now.AddDays(-30), DateTime.Now).ToString();
            lbDoanhSo.Text = BLLClothShop.Instance.GetDoanhSo(DateTime.Now.AddDays(-30), DateTime.Now).ToString();
            lbLoiNhuan.Text = BLLClothShop.Instance.GetLoiNhuan(DateTime.Now.AddDays(-30), DateTime.Now).ToString();
            chartCot.Series["s2"].Points.Clear(); 
            chartCot.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            int now = DateTime.Now.Month;
            List<int> s = BLLClothShop.Instance.GetDS12m();
            string[] m = { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            for (int i = 11; i >= 0; i--)
            {
                if (now <= i)
                    chartCot.Series["s2"].Points.AddXY(m[now + 12 - i - 1], s[11 - i]);
                else
                    chartCot.Series["s2"].Points.AddXY(m[now - i - 1], s[11 - i]);
            }

            chartTron.Series["s1"].Points.Clear();
            double[] p = BLLClothShop.Instance.GetDSTheoNhomSP();
            foreach (var i in BLLClothShop.Instance.GetAllNhomSP())
            {
                chartTron.Series["s1"].Points.AddXY(i.Text, p[i.Value-1]);
            }    
        }
    }
}
