using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothShop.DTO
{
    [Table("NhanVien")]
    public class NhanVien
    {
        public NhanVien()
        {
            this.NhapKhosTaos = new HashSet<NhapKho>();
            this.NhapKhoSuas = new HashSet<NhapKho>();
            this.HoaDonTaos = new HashSet<HoaDon>();
            this.HoaDonSuas = new HashSet<HoaDon>();
        }
        [Key]
        [StringLength(10)]
        [Required]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        [Required]
        public string ChucVu { get; set; }
        public string Sdt { get; set; }
        [Required][StringLength(10)]
        public string MaKhau { get; set; }
        public byte[] Anh { get; set; }
        public virtual ICollection<NhapKho> NhapKhosTaos { get; set; }
        public virtual ICollection<NhapKho> NhapKhoSuas { get; set; }
        public virtual ICollection<HoaDon> HoaDonTaos { get; set; }
        public virtual ICollection<HoaDon> HoaDonSuas { get; set; }
    }
}
