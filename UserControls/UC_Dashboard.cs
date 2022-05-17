using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothShop.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            chartTron.Titles.Add("");
            chartTron.Series["s1"].Points.AddXY("Đầm", "10");
            chartTron.Series["s1"].Points.AddXY("Áo thun", "26");
            chartTron.Series["s1"].Points.AddXY("Chân váy", "70");
            chartTron.Series["s1"].Points.AddXY("Quần jeans", "68");
            chartTron.Series["s1"].Points.AddXY("Sơ mi", "45");

            chartCot.Series["s2"].Points.AddXY("1", 1000);
            chartCot.Series["s2"].Points.AddXY("2", 5000);
            chartCot.Series["s2"].Points.AddXY("3", 1500);
            chartCot.Series["s2"].Points.AddXY("4", 7000);
            chartCot.Series["s2"].Points.AddXY("5", 2000);
            chartCot.Series["s2"].Points.AddXY("6", 8500);
            chartCot.Series["s2"].Points.AddXY("7", 4000);
            chartCot.Series["s2"].Points.AddXY("8", 10000);
            chartCot.Series["s2"].Points.AddXY("9", 9000);
            chartCot.Series["s2"].Points.AddXY("10", 500);
            chartCot.Series["s2"].Points.AddXY("11", 6000);
            chartCot.Series["s2"].Points.AddXY("12", 5500);
        }
    }
}
