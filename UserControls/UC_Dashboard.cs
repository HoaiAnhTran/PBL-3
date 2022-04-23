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
            chart1.Titles.Add("");
            chart1.Series["s1"].Points.AddXY("Đầm", "10");
            chart1.Series["s1"].Points.AddXY("Áo thun", "26");
            chart1.Series["s1"].Points.AddXY("Chân váy", "70");
            chart1.Series["s1"].Points.AddXY("Quần jean", "68");
            chart1.Series["s1"].Points.AddXY("Sơ mi", "45");

            chart2.Series["s2"].Points.AddXY("1", 1000);
            chart2.Series["s2"].Points.AddXY("2", 5000);
            chart2.Series["s2"].Points.AddXY("3", 1500);
            chart2.Series["s2"].Points.AddXY("4", 7000);
            chart2.Series["s2"].Points.AddXY("5", 2000);
            chart2.Series["s2"].Points.AddXY("6", 8500);
            chart2.Series["s2"].Points.AddXY("7", 4000);
            chart2.Series["s2"].Points.AddXY("8", 10000);
            chart2.Series["s2"].Points.AddXY("9", 9000);
            chart2.Series["s2"].Points.AddXY("10", 500);
            chart2.Series["s2"].Points.AddXY("11", 6000);
            chart2.Series["s2"].Points.AddXY("12", 5500);

        }

    }
}
