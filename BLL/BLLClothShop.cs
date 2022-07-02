using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothShop.DTO;
using QRCoder;

namespace ClothShop.BLL
{
    internal class BLLClothShop
    {
        QLCH db = new QLCH();
        private static BLLClothShop _Instance;
        public static BLLClothShop Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLClothShop();
                }
                return _Instance;
            }
            private set { }
        }
        private BLLClothShop()
        {
        }
        public dynamic GetAllNV(string txt = "")
        {
            return (from p in db.NhanViens
                    where p.MaNV != "admin" && (p.MaNV.Contains(txt) || p.TenNV.Contains(txt) || p.DiaChi.Contains(txt) || p.Sdt.Contains(txt) || p.ChucVu.Contains(txt))
                    let GioiTinh = (p.GioiTinh == true) ? "Nam" : "Nữ"
                    select new { p.MaNV, p.TenNV, p.ChucVu, GioiTinh, p.DiaChi,  p.Sdt }).ToList(); 
        }
        public dynamic GetAllCTNK()
        {
            return (from p in db.CTNhapKhos
                    select p).ToList();
        }
        public dynamic GetAllCTHD()
        {
            return (from p in db.CTHoaDons
                    select p).ToList();
        }
        public dynamic GetAllNCC(string txt = "")
        {
            return (from p in db. NhaCungCaps
                    where p.MaNCC != "NCC0000000" && (p.MaNCC.Contains(txt) || p.TenNCC.Contains(txt) || p.SDT.Contains(txt) || p.DiaChi.Contains(txt) || p.Mail.Contains(txt))
                    select new { p.MaNCC, p.TenNCC, p.Mail, p.DiaChi, p.SDT }).ToList();
        }
        public dynamic GetAllKH(string txt = "")
        {
            return (from p in db.KhachHangs
                    where p.MaKH != "KH00000000" && (p.MaKH.Contains(txt) || p.TenKH.Contains(txt) || p.SDT.Contains(txt) || p.DiaChi.Contains(txt))
                    let GioiTinh = (p.GioiTinh == true) ? "Nam" : "Nữ"
                    select new { p.MaKH, p.TenKH, GioiTinh, p.DiaChi, p.SDT, }).ToList();
        }
        public dynamic GetAllSPView(string txt = "")
        {
            return (from p in db.SanPhams
                    where p.MaSP != "SP00000000" && (p.MaSP.Contains(txt) || p.TenSP.Contains(txt) || p.NhomSP.Ten_NhomSP.Contains(txt))
                    select new { p.MaSP, p.TenSP }).ToList();
        }
        public dynamic GetAllKM(string txt = "")
        {
            return (from p in db.KhuyenMais
                    where p.MaKM.Contains(txt) || p.TenKM.Contains(txt) || p.MoTa.Contains(txt)
                    let NgayBatDau = p.NgayApDung
                    let NgayKetThuc = DbFunctions.AddDays(p.NgayApDung, p.HanSuDung-1)
                    select new { p.MaKM, p.TenKM, p.MoTa, p.GiaTri, NgayBatDau, NgayKetThuc }).ToList();
        }
        public dynamic GetAllHD(string txt = "")
        {
            return (from p in db.HoaDons
                    where p.MaHD != "HD00000000" && (p.MaHD.Contains(txt) || p.MaKH.Contains(txt) || p.KhachHang.TenKH.Contains(txt) || p.ID_NguoiTao.Contains(txt) 
                                                                        || p.NguoiTao.TenNV.Contains(txt) || p.MaKM.Contains(txt) || p.KhuyenMai.TenKM.Contains(txt))
                    let SoLuong =
                    (
                        from q in db.CTHoaDons
                        where q.MaHD == p.MaHD
                        select (int?) q.SoLuong
                    ).Sum() ?? 0

                    let TongTien =
                    (
                        from q in db.CTHoaDons
                        where q.MaHD == p.MaHD
                        select (int?) q.SoLuong * (q.GiaBan * (1 - q.KhuyenMai))
                    ).Sum() ?? 0
                    let KM = (p.GiaTriKM*100).ToString() + "%"
                    let ThanhTien = TongTien * (1 - p.GiaTriKM)
                    select new { p.MaHD, p.KhachHang.TenKH,p.NguoiTao.TenNV, p.NgayTao, p.KhuyenMai.TenKM, KM, SoLuong, TongTien, ThanhTien }).ToList();
        }
        public string GetKHBySDT(string SDT)
        {
            foreach (var i in (from p in db.KhachHangs where p.SDT == SDT select p).ToList())
            {
                return i.MaKH;
            }
            return null;
        }
        public string GetNCCBySDT(string SDT)
        {
            foreach (var i in (from p in db.NhaCungCaps where p.SDT == SDT select p).ToList())
            {
                return i.MaNCC;
            }
            return null;
        }
        public dynamic GetAllNK(string txt = "")
        {
            return (from p in db.NhapKhos
                    where p.MaNK != "NK00000000" && (p.MaNK.Contains(txt) || p.MaNCC.Contains(txt) || p.NhaCungCap.TenNCC.Contains(txt) || p.NguoiTao.TenNV.Contains(txt) || p.ID_NguoiTao.Contains(txt))
                    select new { p.MaNK, p.NhaCungCap.TenNCC, p.NguoiTao.TenNV, p.NgayTao }).ToList();
        }
        public dynamic GetAllSP(string txt = "")
        {
            return (from p in db.SanPhams
                    where p.MaSP != "SP00000000" && (p.MaSP.Contains(txt) || p.TenSP.Contains(txt) || p.NhomSP.Ten_NhomSP.Contains(txt))
                    let SoLuong =
                    (
                        from q in db.CTSanPhams
                        where q.MaSP == p.MaSP
                        select (int?)q.SoLuong
                    ).Sum() ?? 0
                    select new { p.MaSP, p.TenSP, p.NhomSP.Ten_NhomSP, p.GiaBan, p.KhuyenMai, SoLuong }).ToList();
        }
        public NhanVien GetNVByMaNV(string MaNV)
        {
            NhanVien s = db.NhanViens.Find(MaNV);
            return s;
        }
        public KhuyenMai GetKMByMaKM(string MaKM)
        {
            KhuyenMai s = db.KhuyenMais.Find(MaKM);
            return s;
        }
        public NhaCungCap GetNCCByMaNCC(string MaNCC)
        {
            NhaCungCap s = db.NhaCungCaps.Find(MaNCC);
            return s;
        }
        public NhapKho GetNKByMaNK(string MaNK)
        {
            NhapKho s = db.NhapKhos.Find(MaNK);
            return s;
        }
        public CTSanPham GetCTSPByMaCTSP(string MaCTSP)
        {
            CTSanPham s = db.CTSanPhams.Find(MaCTSP);
            return s;
        }
        public HoaDon GetHDByMaHD(string MaHD)
        {
            HoaDon s = db.HoaDons.Find(MaHD);
            return s;
        }
        public CTNhapKho GetCTNKByMaCTNK(string MaCTNK)
        {
            CTNhapKho s = db.CTNhapKhos.Find(MaCTNK);
            return s;
        }
        public SanPham GetSPByMaSP(string MaSP)
        {
            SanPham s = db.SanPhams.Find(MaSP);
            return s;
        }
        public CTHoaDon GetCTHDByMaCTHD(string MaCTHD)
        {
            CTHoaDon s = db.CTHoaDons.Find(MaCTHD);
            return s;
        }    
        public KhachHang GetKHByMaKH(string MaKH)
        {
            KhachHang s = db.KhachHangs.Find(MaKH);
            return s;
        }
        public NhomSP GetNhomSPByID(int id)
        {
            NhomSP s = db.NhomSPs.Find(id);
            return s;
        }
        public NhomSP GetNhomSPByName(string name)
        {
            foreach (NhomSP i in db.NhomSPs)
                if (i.Ten_NhomSP == name) return i;
            return null;
        }
        public bool CheckDN(string MaNV, string MK)
        {
            NhanVien s = GetNVByMaNV(MaNV);
            return s != null && s.MatKhau == MK;
        }
        public int CheckChucVu(string MaNV)
        {
            if (GetNVByMaNV(MaNV) != null)
            {
                if (GetNVByMaNV(MaNV).ChucVu == "Admin") return 0;
                else if (GetNVByMaNV(MaNV).ChucVu == "Thu Ngân") return 1;
                else if (GetNVByMaNV(MaNV).ChucVu == "Bán Hàng") return 2;
                else if (GetNVByMaNV(MaNV).ChucVu == "Nhập Kho") return 3;
                else return -1;
            }
            else return -1;
        }
        public dynamic GetCTSPByMaSP(string MaSP,string size, string mau)
        {
            if (size == "All" && mau == "All")
            {
                return (from p in db.CTSanPhams
                        where p.MaSP == MaSP
                        let SoLuongNhap =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.SoLuong
                        ).Sum() ?? 0
                        let GiaNhapTB =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.GiaNhap*q.SoLuong
                        ).Sum() / SoLuongNhap ?? 0
                        select new { p.MaCTSP, p.Size, p.MauSac, p.SoLuong, GiaNhapTB, p.MaQR }).ToList();
            }    
            else if (size == "All" && mau != "All")
            {
                return (from p in db.CTSanPhams
                        where p.MaSP == MaSP && p.MauSac == mau
                        let SoLuongNhap =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.SoLuong
                        ).Sum() ?? 0
                        let GiaNhapTB =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.GiaNhap * q.SoLuong
                        ).Sum() / SoLuongNhap ?? 0
                        select new { p.MaCTSP, p.Size, p.MauSac, p.SoLuong, GiaNhapTB, p.MaQR }).ToList();
            }
            else if (size != "All" && mau == "All")
            {
                return (from p in db.CTSanPhams
                        where p.MaSP == MaSP  && p.Size == size
                        let SoLuongNhap =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.SoLuong
                        ).Sum() ?? 0
                        let GiaNhapTB =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.GiaNhap * q.SoLuong
                        ).Sum() / SoLuongNhap ?? 0
                        select new { p.MaCTSP, p.Size, p.MauSac, p.SoLuong, GiaNhapTB, p.MaQR }).ToList();
            }
            else 
                return (from p in db.CTSanPhams
                        where p.MaSP == MaSP && p.MauSac == mau && p.Size == size
                        let SoLuongNhap =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.SoLuong
                        ).Sum() ?? 0
                        let GiaNhapTB =
                        (
                            from q in db.CTNhapKhos
                            where q.MaCTSP == p.MaCTSP
                            select (int?)q.GiaNhap * q.SoLuong
                        ).Sum() / SoLuongNhap ?? 0
                        select new { p.MaCTSP, p.Size, p.MauSac, p.SoLuong, GiaNhapTB, p.MaQR }).ToList();
        }
        public dynamic GetCTHDByMaHD(string MaHD)
        {
            return (from p in db.CTHoaDons
                    where p.MaHD == MaHD
                    select new { p.MaCTHD, p.CTSanPham.SanPham.TenSP, p.CTSanPham.Size, p.CTSanPham.MauSac, p.GiaBan, p.SoLuong, p.KhuyenMai, ThanhTien = p.SoLuong * (p.GiaBan * (1 - p.KhuyenMai)) }).ToList();
        }
        public List<string> GetCBBSizeByMaSP(string MaSP)
        {
            List<string> size = new List<string>();
            foreach (var p in db.CTSanPhams)
            {
                if (p.MaSP == MaSP)
                {
                    bool check = false;
                    foreach (string i in size)
                    {
                        if (i == p.Size) check = true;
                    }    
                    if (check == false) size.Add(p.Size);
                }
            }    
            return size;
        }
        public List<string> GetCBBMauByMaSP(string MaSP)
        {
            List<string> mau = new List<string>();
            foreach (var p in db.CTSanPhams)
            {
                if (p.MaSP == MaSP)
                {
                    bool check = false;
                    foreach (string i in mau)
                    {
                        if (i == p.MauSac) check = true;
                    }
                    if (check == false) mau.Add(p.MauSac);
                }
            }
            return mau;
        }
        public dynamic GetCTNKByMaNK(string MaNK)
        { 
            return (from p in db.CTNhapKhos
                    where p.MaNK == MaNK
                    select new {p.MaCTNK , p.CTSanPham.SanPham.TenSP, p.CTSanPham.Size, p.CTSanPham.MauSac, p.GiaNhap, p.SoLuong }).ToList();
        }
        public List<CBBNhomSP> GetAllNhomSP()
        {
            List<CBBNhomSP> s = new List<CBBNhomSP>();
            foreach (NhomSP i in db.NhomSPs)
            {
                s.Add(new CBBNhomSP
                {
                    Value = i.ID_NhomSP,
                    Text = i.Ten_NhomSP,
                });
            }
            return s;
        }
        public void CopyNK(string MaNK)
        {
            foreach (var i in GetCTNKByMaNK(MaNK))
            {
                CTNhapKho s = db.CTNhapKhos.Find(i.MaCTNK);
                db.CTNhapKhos.Add(new CTNhapKho
                {
                    MaCTNK = "AO" + s.MaCTNK.Substring(2),
                    MaCTSP = s.MaCTSP,
                    GiaNhap = s.GiaNhap,
                    MaNK = "NK00000000",
                    SoLuong = s.SoLuong,
                });
                db.SaveChanges();
            }    
        }

        public void PasteNK(string MaNK)
        {
            foreach (var i in GetCTNKByMaNK(MaNK))
            {
                CTNhapKho s = db.CTNhapKhos.Find(i.MaCTNK);
                if (db.CTNhapKhos.Find("AO" + s.MaCTNK.Substring(2)) == null)
                {
                    CTSanPham p = db.CTSanPhams.Find(s.MaCTSP);
                    p.SoLuong -= s.SoLuong;
                    db.CTNhapKhos.Remove(s);
                    db.SaveChanges();
                }
            }
            foreach (var i in GetCTNKByMaNK("NK00000000"))
            {
                CTNhapKho s = db.CTNhapKhos.Find(i.MaCTNK);
                CTNhapKho x = db.CTNhapKhos.Find("CN" + i.MaCTNK.Substring(2));
                CTSanPham p = db.CTSanPhams.Find(s.MaCTSP);
                p.SoLuong += s.SoLuong;
                db.SaveChanges();
                if (x == null)
                {
                    x = new CTNhapKho
                    {
                        MaCTNK = "CN" + i.MaCTNK.Substring(2),
                        MaCTSP = s.MaCTSP,
                        MaNK = MaNK,
                        SoLuong = s.SoLuong,
                        GiaNhap = s.GiaNhap,
                    };
                    db.CTNhapKhos.Add(x);
                }
                else
                {
                    p = db.CTSanPhams.Find(s.MaCTSP);
                    p.SoLuong -= x.SoLuong;
                    db.SaveChanges();
                    x.MaCTSP = s.MaCTSP;
                    x.SoLuong = s.SoLuong;
                    x.GiaNhap = s.GiaNhap;
                }
                db.CTNhapKhos.Remove(s);
                db.SaveChanges();
            }
        }
        public void CopySP(string MaSP)
        {
            foreach (var i in GetCTSPByMaSP(MaSP,"All","All"))
            {
                CTSanPham s = db.CTSanPhams.Find(i.MaCTSP);
                db.CTSanPhams.Add(new CTSanPham
                {
                    MaCTSP = "AO" + s.MaCTSP.Substring(2),
                    MaSP = "SP00000000",
                    Size = s.Size,
                    MauSac = s.MauSac,
                    SoLuong = s.SoLuong,
                });
                db.SaveChanges();
            }
        }
        public void PasteSP(string MaSP)
        {
            foreach (var i in GetCTSPByMaSP(MaSP, "All", "All"))
            {
                CTSanPham s = db.CTSanPhams.Find(i.MaCTSP);
                if (db.CTSanPhams.Find("AO" + s.MaCTSP.Substring(2)) == null)
                {
                    db.CTSanPhams.Remove(s);
                }
                db.SaveChanges();
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            foreach (var i in GetCTSPByMaSP("SP00000000","All", "All"))
            {
                CTSanPham s = db.CTSanPhams.Find(i.MaCTSP);
                CTSanPham x = db.CTSanPhams.Find("CS" + i.MaCTSP.Substring(2));
                if (x == null)
                {
                    x = new CTSanPham
                    {
                        MaCTSP = "CS" + i.MaCTSP.Substring(2),
                        MaSP = MaSP,
                        Size = s.Size,
                        SoLuong = 0,
                        MauSac = s.MauSac,
                        MaQR = ImageToByteArray(new QRCode(qrGenerator.CreateQrCode("CS" + i.MaCTSP.Substring(2), QRCodeGenerator.ECCLevel.Q)).GetGraphic(2, Color.Black, Color.White, false)),
                    };
                    db.CTSanPhams.Add(x);
                }
                else
                {
                    x.Size = s.Size;
                    x.MauSac = s.MauSac;
                }
                db.CTSanPhams.Remove(s);
                db.SaveChanges();
            }
            qrGenerator.Dispose();
        }
        public void PasteHD(string MaHD)
        {
            foreach (var i in GetCTHDByMaHD(MaHD))
            {
                CTHoaDon s = db.CTHoaDons.Find(i.MaCTHD);
                if (db.CTHoaDons.Find("AO" + s.MaCTHD.Substring(2)) == null)
                {
                    db.CTHoaDons.Remove(s);
                }
                db.SaveChanges();
            }
            foreach (var i in GetCTHDByMaHD("HD00000000"))
            {
                CTHoaDon s = db.CTHoaDons.Find(i.MaCTHD);
                CTHoaDon x = db.CTHoaDons.Find("CH" + i.MaCTHD.Substring(2));
                CTSanPham p = db.CTSanPhams.Find(s.MaCTSP);
                p.SoLuong -= s.SoLuong;
                db.SaveChanges();
                if (x == null)
                {
                    x = new CTHoaDon
                    {
                        MaCTHD = "CH" + i.MaCTHD.Substring(2),
                        MaCTSP = s.MaCTSP,
                        MaHD = MaHD,
                        SoLuong = s.SoLuong,
                        GiaBan = s.GiaBan,
                        KhuyenMai = s.KhuyenMai,
                    };
                    db.CTHoaDons.Add(x);
                }
                else
                {
                    p = db.CTSanPhams.Find(s.MaCTSP);
                    p.SoLuong += x.SoLuong;
                    db.SaveChanges();
                    x.MaCTSP = s.MaCTSP;
                    x.SoLuong = s.SoLuong;
                    x.GiaBan = s.GiaBan;
                    x.KhuyenMai = s.KhuyenMai;
                }
                db.CTHoaDons.Remove(s);
                db.SaveChanges();
            }
        }
        public void CopyHD(string MaHD)
        {
            foreach (var i in GetCTHDByMaHD(MaHD))
            {
                CTHoaDon s = db.CTHoaDons.Find(i.MaCTHD);
                db.CTHoaDons.Add(new CTHoaDon
                {
                    MaCTHD = "AO" + s.MaCTHD.Substring(2),
                    MaHD = "HD00000000",
                    MaCTSP = s.MaCTSP,
                    GiaBan = s.GiaBan,
                    SoLuong = s.SoLuong,
                    KhuyenMai = s.KhuyenMai,
                });
                db.SaveChanges();
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                return ms.ToArray();
            }
        }
        public Image ByteToImg(byte[] imgBytes)
        {
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        public void AddUpdateSP(SanPham s)
        {
            SanPham x = db.SanPhams.Find(s.MaSP);
            if (x == null)
            {
                db.SanPhams.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.TenSP = s.TenSP;
                x.ID_NhomSP = s.ID_NhomSP;
                x.GiaBan = s.GiaBan;
                x.KhuyenMai = s.KhuyenMai;
                x.Anh = s.Anh;
                db.SaveChanges();
            }
        }
        public void AddUpdateNK(NhapKho s)
        {
            NhapKho x = db.NhapKhos.Find(s.MaNK);
            if (x == null)
            {
                db.NhapKhos.Add(s);
                db.SaveChanges();
            }    
            else
            {
                x.MaNCC = s.MaNCC;
                x.ID_NguoiTao = s.ID_NguoiTao;
                x.ID_NguoiSua = s.ID_NguoiSua;
                x.NgayTao = s.NgayTao;
                x.NgaySua = x.NgaySua;
                db.SaveChanges();
            }    
        }    
        public void AddUpdateNCC(NhaCungCap s)
        {
            NhaCungCap x = db.NhaCungCaps.Find(s.MaNCC);
            if (x == null)
            {
                db.NhaCungCaps.Add(s);
                db.SaveChanges();
            }    
            else
            {
                x.TenNCC = s.TenNCC;
                x.SDT = s.SDT;
                x.DiaChi = s.DiaChi;
                x.Mail = s.Mail;
                db.SaveChanges();
            }    
        }
        public void AddUpdateNV(NhanVien s)
        {
            NhanVien x = db.NhanViens.Find(s.MaNV);
            if (x == null)
            {
                db.NhanViens.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.TenNV = s.TenNV;
                x.Sdt = s.Sdt;
                x.DiaChi = s.DiaChi;
                x.ChucVu = s.ChucVu;
                x.GioiTinh = s.GioiTinh;
                x.MatKhau = s.MatKhau;
                x.Anh = s.Anh;
                db.SaveChanges();
            }
        }
        public void AddUpdateKM(KhuyenMai s)
        {
            KhuyenMai x = db.KhuyenMais.Find(s.MaKM);
            if (x == null)
            {
                db.KhuyenMais.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.TenKM= s.TenKM;
                x.GiaTri= s.GiaTri;
                x.HanSuDung = s.HanSuDung;
                x.MoTa = s.MoTa;
                db.SaveChanges();
            }
        }
        public void AddCTSP(string MaSP, string size, string Mau)
        {
            Random rd = new Random();
            string rand;
            do
            {
                rand = "";
                rand = rd.Next(0, 99999999).ToString();
                for (int i = 0; i < (8 - rand.Length); i++)
                    rand = "0" + rand;
                rand = "CS" + rand;
            }
            while (BLLClothShop.Instance.GetCTSPByMaCTSP(rand) != null);
            CTSanPham s = new CTSanPham
            {
                MaCTSP = "AO" + rand.Substring(2),
                Size = size,
                MauSac = Mau,
                MaSP = MaSP,
                SoLuong = 0,
            };
            AddUpdateCTSP(s);

        }
        public void AddUpdateCTSP(CTSanPham s)
        {
            CTSanPham x = db.CTSanPhams.Find(s.MaCTSP);
            if (x == null)
            {
                db.CTSanPhams.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.MaSP = s.MaSP;
                x.MauSac = s.MauSac;
                x.Size = s.Size;
                x.SoLuong = s.SoLuong;
                db.SaveChanges();
            };
        }
        public void AddUpdateCTHD(CTHoaDon s)
        {
            CTHoaDon x = db.CTHoaDons.Find(s.MaCTHD);
            if (x == null)
            {
                db.CTHoaDons.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.MaCTSP = s.MaCTSP;
                x.SoLuong = s.SoLuong;
                x.GiaBan = s.GiaBan;
                x.MaHD = s.MaHD;
                db.SaveChanges();
            };
        }
        public void AddUpdateCTNK(CTNhapKho s)
        {
            CTNhapKho x = db.CTNhapKhos.Find(s.MaCTNK);
            if (x == null)
            {
                db.CTNhapKhos.Add(s);
                db.SaveChanges();
            }    
            else
            {
                x.MaCTSP = s.MaCTSP;
                x.SoLuong = s.SoLuong;
                x.GiaNhap = s.GiaNhap;
                x.MaNK = s.MaNK;
                db.SaveChanges();
            }    
        }    
        public void AddUpdateKH(KhachHang s)
        {
            KhachHang x = db.KhachHangs.Find(s.MaKH);
            if(x == null)
            {
                db.KhachHangs.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.TenKH = s.TenKH;
                x.NgaySinh = s.NgaySinh;
                x.SDT = s.SDT;
                x.DiaChi = s.DiaChi;
                x.GioiTinh = s.GioiTinh;
                db.SaveChanges();
            }
        }    
        public void AddUpdateHD(HoaDon s)
        {
            HoaDon x = db.HoaDons.Find(s.MaHD);
            if (x == null)
            {
                db.HoaDons.Add(s);
                db.SaveChanges();
            }
            else
            {
                x.MaKM = s.MaKM;
                x.GiaTriKM = s.GiaTriKM;
                x.MaKH = s.MaKH;
                x.ID_NguoiTao = s.ID_NguoiTao;
                x.ID_NguoiSua = s.ID_NguoiSua;
                x.NgaySua = s.NgaySua;
                x.NgayTao = s.NgayTao;
            }
        }    
        public void AddNhomSP(NhomSP s)
        {
            NhomSP n = db.NhomSPs.Find(s.ID_NhomSP);
            if (n == null)
            {
                NhomSP m = new NhomSP { ID_NhomSP = 0, Ten_NhomSP = s.Ten_NhomSP };
                db.NhomSPs.Add(m);
                db.SaveChanges();
            }    
            else
            {
                n.Ten_NhomSP = s.Ten_NhomSP;
                db.SaveChanges();
            }    
        }
        public void DelSP(string MaSP)
        {
            foreach (CTSanPham i in db.CTSanPhams)
            {
                if (i.MaSP == MaSP)
                {
                    db.CTSanPhams.Remove(i);
                }
            }
            db.SaveChanges();
            SanPham s = db.SanPhams.Find(MaSP);
            db.SanPhams.Remove(s);
            db.SaveChanges();
        }
        public void DelKH(string MaKH)
        {
            foreach (HoaDon i in db.HoaDons)
            {
                if (i.MaKH == MaKH)
                {
                    i.MaKH = "KH00000000";
                    db.SaveChanges();
                }    
            }    
            KhachHang s = db.KhachHangs.Find(MaKH);
            db.KhachHangs.Remove(s);
            db.SaveChanges();
        }
        public void DelKM(string MaKM)
        {
            KhuyenMai s = db.KhuyenMais.Find(MaKM);
            db.KhuyenMais.Remove(s);
            db.SaveChanges();
        }
        public void DelNV(string MaNV)
        {
            NhanVien s = db.NhanViens.Find(MaNV);
            db.NhanViens.Remove(s);
            db.SaveChanges();
        }
        public void ResetMKNV(string MaNV)
        {
            NhanVien s = db.NhanViens.Find(MaNV);
            if (s != null)
            {
                s.MatKhau = "abc";
                db.SaveChanges();
            }
        }
        public void DelHD(string MaHD)
        {
            foreach (CTHoaDon i in db.CTHoaDons)
            {
                if (i.MaHD == MaHD)
                {
                    CTSanPham p = db.CTSanPhams.Find(i.MaCTSP);
                    p.SoLuong += i.SoLuong;
                    db.CTHoaDons.Remove(i);
                }
            }
            db.SaveChanges();
            HoaDon s = db.HoaDons.Find(MaHD);
            db.HoaDons.Remove(s);
            db.SaveChanges();
        }
        public void DelNCC(string MaNCC)
        {
            foreach (NhapKho i in db.NhapKhos)
            {
                if (i.MaNCC == MaNCC)
                {
                    i.MaNCC = "NCC0000000";
                    db.SaveChanges();
                }
            }
            NhaCungCap s = db.NhaCungCaps.Find(MaNCC);
            db.NhaCungCaps.Remove(s);
            db.SaveChanges();
        }
        public void DelNK(string MaNK)
        {
            foreach (CTNhapKho i in db.CTNhapKhos)
            {
                if (i.MaNK == MaNK)
                {
                    CTSanPham p = db.CTSanPhams.Find(i.MaCTSP);
                    p.SoLuong -= i.SoLuong;
                    db.CTNhapKhos.Remove(i);
                }
            }
            db.SaveChanges();
            NhapKho s = db.NhapKhos.Find(MaNK);
            db.NhapKhos.Remove(s);
            db.SaveChanges();
        }
        public void DelCTSP(string MaCTSP)
        {
            CTSanPham s = db.CTSanPhams.Find(MaCTSP);
            db.CTSanPhams.Remove(s);
            db.SaveChanges();
        }
        public void DelCTHD(string MaCTHD)
        {
            CTHoaDon s = db.CTHoaDons.Find(MaCTHD);
            db.CTHoaDons.Remove(s);
            db.SaveChanges();
        }    
        public void DelCTNK(string MaCTNK)
        {
            CTNhapKho s = db.CTNhapKhos.Find(MaCTNK);
            db.CTNhapKhos.Remove(s);
            db.SaveChanges();
        }
        public int GetSoLuongNK(string MaNK)
        {
            int SoLuong = 0;
            foreach (var i in GetCTNKByMaNK(MaNK))
            {
                SoLuong += i.SoLuong;
            }
            return SoLuong;
        }
        public int GetTongNK(string MaNK)
        {
            int Tong = 0;
            foreach (var i in GetCTNKByMaNK(MaNK))
            {
                Tong += i.SoLuong * i.GiaNhap;
            }
            return Tong;
        }
        public int GetSoLuongHD(string MaHD)
        {
            int SoLuong = 0;
            foreach (var i in GetCTHDByMaHD(MaHD))
            {
                SoLuong += i.SoLuong;
            }
            return SoLuong;
        }
        public int GetTongHD(string MaHD)
        {
            int Tong = 0;
            foreach (var i in GetCTHDByMaHD(MaHD))
            {
                Tong += i.ThanhTien;
            }
            return Tong;
        }
        public bool CheckDelKH(string MaKH) // Kiểm tra có thể xóa khách hàng: check MaKH chưa đc sử dụng
        {
            foreach (HoaDon i in db.HoaDons)
            {
                if (i.MaKH == MaKH) return false;
            }
            return true;
        }
        public bool CheckDelKM(string MaKM) // Kiểm tra có thể xóa Khuyến mãi: check MaKM chưa đc sử dụng
        {
            foreach (HoaDon i in db.HoaDons)
            {
                if (i.MaKM == MaKM) return false;
            }
            return true;
        }
        public bool CheckDelNCC(string MaNCC) // Kiểm tra có thể xóa nhà cung cấp: check MaNCC chưa đc sử dụng
        {
            foreach (NhapKho i in db.NhapKhos)
            {
                if (i.MaNCC == MaNCC) return false;
            }
            return true;
        }
        public bool CheckDelNV(string MaNV)
        {
            NhanVien s = db.NhanViens.Find(MaNV);
            foreach (HoaDon i in db.HoaDons)
            {
                if (i.ID_NguoiSua == MaNV || i.ID_NguoiTao == MaNV)
                    return false;
            }
            foreach (NhapKho i in db.NhapKhos)
            {
                if (i.ID_NguoiSua == MaNV || i.ID_NguoiTao == MaNV)
                    return false;
            }
            return true;
        }
        public bool CheckDelSize(string MaSP, string Size) // Kiểm tra có thể xóa size: check MaCTSP chưa đc sử dụng
        {
            foreach (var i in GetCTSPByMaSP(MaSP, Size, "All"))
            {
                foreach (var j in GetAllCTNK())
                    if (j.MaCTSP == "CS" + i.MaCTSP.Substring(2)) return false;
            }    
            return true;
        }
        public bool CheckDelSP(string MaSP) // Kiểm tra có thể xóa sản phẩm hay k: check MaSP chưa đc sử dụng
        {
            foreach (var i in GetCTSPByMaSP(MaSP, "All", "All"))
            {
                foreach (var j in GetAllCTNK())
                    if (j.MaCTSP == "CS" + i.MaCTSP.Substring(2)) return false;
            }
            return true;
        }
        public bool CheckDelMau(string MaSP, string Mau) // Kiểm tra có thể xóa màu: check MaCTSP chưa đc sử dụng
        {
            foreach (var i in GetCTSPByMaSP(MaSP, "All", Mau))
            {
                foreach (var j in GetAllCTHD())
                    if (j.MaCTSP == "CS" + i.MaCTSP.Substring(2)) return false;
                foreach (var j in GetAllCTNK())
                    if (j.MaCTSP == "CS" + i.MaCTSP.Substring(2)) return false;
            }
            return true;
        }
        public int GetSLSPBan(DateTime batdau, DateTime ket)
        {
            int Tong = 0;
            foreach (var i in GetAllHD())
            {
                if (i.NgayTao >= batdau && i.NgayTao <= ket)
                {
                    Tong += i.SoLuong;
                }    
            }   
            return Tong;
        }
        public int GetSLHoaDon(DateTime batdau, DateTime ket)
        {
            int Tong = 0;
            foreach (var i in GetAllHD())
            {
                if (i.NgayTao >= batdau && i.NgayTao <= ket)
                {
                    Tong++;
                }
            }
            return Tong;
        }
        public int GetDoanhSo(DateTime batdau, DateTime ket)
        {
            int Tong = 0;
            foreach (var i in GetAllHD())
            {
                if (i.NgayTao >= batdau && i.NgayTao <= ket)
                {
                    Tong += i.ThanhTien;
                }
            }
            return Tong;
        }
        public double GetLoiNhuan(DateTime batdau, DateTime ket)
        {
            double Tong = (double)GetDoanhSo(batdau,ket);
            foreach (CTHoaDon i in db.CTHoaDons)
            {
                if (i.HoaDon.NgayTao >= batdau && i.HoaDon.NgayTao <= ket)
                {
                    Tong -= i.SoLuong * GetCTSPByMaSP(i.CTSanPham.MaSP, i.CTSanPham.Size, i.CTSanPham.MauSac)[0].GiaNhapTB;
                }    
            }    
            return Tong;
        }
        public string GetRandom()
        {
            Random rd = new Random();
            string rand = "";
            rand = rd.Next(0, 99999999).ToString();
            for (int i = 0; i < (8 - rand.Length); i++)
                rand = "0" + rand;
            return rand;
        }
        public List<int> GetDS12m()
        {
            List<int> s = new List<int>();
            int now = DateTime.Now.Month;
            for(int i = 11; i >= 0; i--)
            {
                DateTime sd, ed;
                if (now <= i)
                    sd = new DateTime(DateTime.Now.Year - 1, now + 12 - i, 1);
                else
                    sd = new DateTime(DateTime.Now.Year, now - i, 1);
                if (now <= i-1)
                    ed = new DateTime(DateTime.Now.Year - 1, now + 13 - i, 1).AddDays(-1);
                else
                    ed = new DateTime(DateTime.Now.Year, now - i + 1, 1).AddDays(-1);
                s.Add(GetDoanhSo(sd, ed));
            }
            return s;
        }
        public double[] GetDSTheoNhomSP()
        {
            double[] s = new double[db.NhomSPs.Count()];
            int sum = 0;
            foreach (CTHoaDon x in db.CTHoaDons)
            {
                s[x.CTSanPham.SanPham.ID_NhomSP - 1] += x.GiaBan * x.SoLuong;   
                sum += x.GiaBan * x.SoLuong;    //tổng bán được của tất cả nhóm SP
            }    
            for (int i = 0; i < db.NhomSPs.Count(); i++)
            {
                s[i] = s[i] * 100 / sum;
            }    
            return s;
        }
        public dynamic GetTopSPDS(DateTime batdau, DateTime ket)
        {
            return (from p in db.SanPhams
                    let DoanhSo =
                    (
                        from q in db.CTHoaDons
                        where q.HoaDon.NgayTao >= batdau && q.HoaDon.NgayTao <= ket && q.CTSanPham.MaSP == p.MaSP
                        select (int?) q.GiaBan * q.SoLuong * (1 - q.KhuyenMai)
                    ).Sum() ?? 0
                    where DoanhSo != 0
                    orderby DoanhSo descending              
                    select new { p.TenSP, DoanhSo }).Take(5).ToList();
        }
        public dynamic GetTopSPSL(DateTime batdau, DateTime ket)
        {
            return (from p in db.SanPhams
                    let SoLuong =
                    (
                        from q in db.CTHoaDons
                        where q.HoaDon.NgayTao >= batdau && q.HoaDon.NgayTao <= ket && q.CTSanPham.MaSP == p.MaSP
                        select (int?) q.SoLuong
                    ).Sum() ?? 0
                    where SoLuong != 0
                    orderby SoLuong descending
                    select new { p.TenSP, SoLuong }).Take(5).ToList();
        }
        public dynamic GetTopKH(DateTime batdau, DateTime ket)
        {
            return (from p in db.KhachHangs
                    let TongMua =
                    (
                        from q in db.HoaDons
                        where q.NgayTao >= batdau && q.NgayTao <= ket && q.MaKH == p.MaKH
                        let TongTien =
                        (
                            from n in db.CTHoaDons
                            where n.MaHD == q.MaHD
                            select (int?) n.SoLuong * n.GiaBan * (1 - n.KhuyenMai)
                        ).Sum() ?? 0
                        let ThanhTien = TongTien * (1 - q.GiaTriKM)
                        select (int?) ThanhTien
                    ).Sum() ?? 0
                    where p.MaKH != "KH00000000" && TongMua != 0
                    orderby TongMua descending
                    select new { p.TenKH, TongMua }).Take(5).ToList();
        }
        public dynamic GetSPTonKho(int tg, double tile)
        {
            return (from p in db.SanPhams
                    let TGTonKho = 
                    (
                        from q in db.CTNhapKhos
                        where q.CTSanPham.MaSP == p.MaSP
                        select (int?) DbFunctions.DiffDays(q.NhapKho.NgayTao, DateTime.Now)
                    ).Min() ?? 0
                    let SLBan = 
                    ( 
                        from q in db.CTHoaDons
                        where q.CTSanPham.MaSP == p.MaSP && DbFunctions.DiffDays(q.HoaDon.NgayTao, DateTime.Now) <= TGTonKho
                        select (int?) q.SoLuong
                    ).Sum() ?? 0
                    let SLNhap = 
                    (
                        from q in db.CTNhapKhos
                        where q.CTSanPham.MaSP == p.MaSP
                        select (int?) q.SoLuong
                    ).Sum() ?? 0
                    let SLBanKyTruoc = 
                    (
                        from q in db.CTHoaDons
                        where q.CTSanPham.MaSP == p.MaSP && DbFunctions.DiffDays(q.HoaDon.NgayTao, DateTime.Now) > TGTonKho
                        select (int?) q.SoLuong
                    ).Sum() ?? 0
                    let TiLeBan = Math.Round((double)SLBan/(SLNhap - SLBanKyTruoc)*100,2)
                    where TGTonKho > tg && TiLeBan < tile
                    select new { p.MaSP, p.TenSP, p.KhuyenMai, TGTonKho, TiLeBan }).ToList();
        }
        public int CheckNum(string txt)
        // kiểm tra string nhập vào có phải số không? -1: xâu rỗng; 0: xâu = 0; 1: xâu không hợp lệ; 2: xâu hợp lệ
        {
            if (txt == "" || txt == null)
            {
                return -1;
            }
            if (Convert.ToInt32(txt) == 0)
                return 0;
            foreach (char i in txt)
            {
                if ((i < '0') || (i > '9'))
                {
                    return 1;
                }
            }
            return 2;
        }
    }
}
