using System;
using System.Data.Entity;
using System.Linq;
using ClothShop.DTO;

namespace ClothShop
{
    public class QLCH : DbContext
    {
        // Your context has been configured to use a 'QLCH' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ClothShop.QLCH' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLCH' 
        // connection string in the application configuration file.
        public QLCH()
            : base("name=QLCH")
        {
            Database.SetInitializer<QLCH>(new CreateDB());
        }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomSP> NhomSPs { get; set; }
        public virtual DbSet<NhapKho> NhapKhos { get; set; }
        public virtual DbSet<CTSanPham> CTSanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<CTNhapKho> CTNhapKhos { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}