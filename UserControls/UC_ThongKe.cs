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
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();

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

            chart1.Series["sds"].Points.AddXY("Áo nữ tay ngắn buộc eo", 9500);
            chart1.Series["sds"].Points.AddXY("Chân váy Midi đuôi cá", 20000);
            chart1.Series["sds"].Points.AddXY("Váy sơ mi thắt eo", 26000);
            chart1.Series["sds"].Points.AddXY("Áo khoác cardigan cổ tim", 42000);
            chart1.Series["sds"].Points.AddXY("Set đâm sơ mi + áo ghile", 50000);
            chart1.Series["sds"].Points.AddXY("Áo thun ngắn tay kẻ sọc ngang", 64000);

            chart3.Series["ssl"].Points.AddXY("Chân váy xếp ly", 10000);
            chart3.Series["ssl"].Points.AddXY("Quần short denim", 16000);
            chart3.Series["ssl"].Points.AddXY("Váy sơ mi thắt eo", 44000);
            chart3.Series["ssl"].Points.AddXY("Áo Croptop trễ vai", 59000);
            chart3.Series["ssl"].Points.AddXY("Áo thun ngắn tay kẻ sọc ngang", 64000);
            chart3.Series["ssl"].Points.AddXY("Chân váy lưng cao xẻ tà", 75000);


            chart4.Series["skh"].Points.AddXY("Nguyễn Thị A", 20000);
            chart4.Series["skh"].Points.AddXY("Trần Lê B", 27000);
            chart4.Series["skh"].Points.AddXY("Nguyễn Như C", 51000);
            chart4.Series["skh"].Points.AddXY("Lê Thị D", 62000);
            chart4.Series["skh"].Points.AddXY("Phạm Kiều E", 69000);
            chart4.Series["skh"].Points.AddXY("Vũ Văn F", 78000);

            chart5.Series["snv"].Points.AddXY("Vũ Ngọc Hải", 5000);
            chart5.Series["snv"].Points.AddXY("Cao Nhật Hạ", 12000);
            chart5.Series["snv"].Points.AddXY("Phạm Vĩ Thanh", 23000);
            chart5.Series["snv"].Points.AddXY("Nguyễn Dương Quang", 34000);
            chart5.Series["snv"].Points.AddXY("Lê An Vũ", 45000);
            chart5.Series["snv"].Points.AddXY("Trần Bích Ngạn", 56000);
        }

    }
}
