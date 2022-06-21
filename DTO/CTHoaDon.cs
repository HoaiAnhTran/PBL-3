using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothShop.DTO
{
    [Table("CTHoaDon")]
    public class CTHoaDon
    {
        [Key]
        [StringLength(20)]
        [Required]
        public String MaCTHD { get; set; }
        [StringLength(10)]
        public string MaHD { get; set; }
        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }
        [StringLength(10)]
        public string MaCTSP { get; set; }
        [ForeignKey("MaCTSP")]
        public virtual CTSanPham CTSanPham { get; set; }
        public int GiaBan { get; set; }
        public double KhuyenMai { get; set; }
        public int SoLuong { get; set; }

    }
}
