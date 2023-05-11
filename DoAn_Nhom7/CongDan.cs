using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * * Thuế:
- class thuế: loại thuế, mức thuế, trạng thái (đã đóng chưa)
- thêm list thuế vào class CongDan
- thêm lương vào congDan
- tra cứu thuế: theo mỗi nghề nghiệp thì có mức thuế bao nhiêu %, 
nhập cccd thì hiện ra các loại thuế, tính tổng thuế còn nợ.
 */
namespace DoAn_Nhom7
{
    public class CongDan
    {
        public string hoTen;
        public string ngayThangNamSinh;
        public string gioiTinh;
        public string cmnd;
        public string danToc;
        public string tinhTrangHonNhan;
        public string noiDangKiKhaiSinh;
        public string queQuan;
        public string noiThuongTru;
        public string trinhDoHocVan;
        public string ngheNghiep;
        public string luong;
        public string soLanKetHon;
        public string tamTru;
        public string noiCapCMND;
        public string ngayCap;
        public string quocTich;
        public List<Thue> listThue;       
        public string HoTen
        { 
            get { return hoTen; } 
            set { hoTen = value; } 
        }
        public string NgayThangNamSinh
        { 
            get { return this.ngayThangNamSinh; } 
            set { this.ngayThangNamSinh = value; }
        }
        public string GioiTinh
        { 
            get 
            { return this.gioiTinh; } 
            set { this.gioiTinh = value; } 
        }
        public string CMND
        { get 
            { return this.cmnd; } 
            set { this.cmnd = value; }
        }
        public string DanToc
        { 
            get { return this.danToc; }
            set { this.danToc = value; } 
        }
        public string TinhTrangHonNhan
        { 
            get { return this.tinhTrangHonNhan; }
            set { this.tinhTrangHonNhan = value; } 
        }
        public string NoiDangKiKhaiSinh
        { 
            get { return this.noiDangKiKhaiSinh; } 
            set { this.noiDangKiKhaiSinh = value; } 
        }
        public string QueQuan
        { 
            get { return this.queQuan; } 
            set { this.queQuan = value; } 
        }
        public string NoiThuongTru
        { 
            get { return this.noiThuongTru; } 
            set { this.noiThuongTru = value; } 
        }
        public string TrinhDoHocVan
        { 
            get { return this.trinhDoHocVan; } 
            set { this.trinhDoHocVan = value; } 
        }
        public string NgheNghiep
        { 
            get { return this.ngheNghiep; } 
            set { this.ngheNghiep = value; } 
        }

        public string Luong
        {
            get { return this.luong; }
            set { this.luong = value; }
        }
        public string SoLanKetHon
        {
            get { return this.soLanKetHon; }
            set { this.soLanKetHon = value; }
        }
        public string TamTru
        { 
            get { return this.tamTru; } 
            set { this.tamTru = value; } 
        }
        public string NoiCapCMND
        {
            get { return this.noiCapCMND; }
            set { this.noiCapCMND = value; }
        }
        public string NgayCap
        {
            get { return this.ngayCap; }
            set { this.ngayCap = value; }
        }
        public string QuocTich
        {
            get { return this.quocTich; }
            set { this.quocTich = value; }
        }
        public List<Thue> ListThue
        {
            get { return this.listThue; }
            set { this.listThue = value; }
        }

        public CongDan()
        {

        }
        public CongDan(string hoTen, string ngayThangNamSinh, string gioiTinh, string Cmnd, string danToc, string tinhTrangHonNhan, string noiDangKiKhaiSinh, string queQuan, string noiThuongTru, string trinhDoHocVan, string ngheNghiep, string luong,string soLanKetHon,string tamTru, string noiCapCMND, string ngayCap,string quocTich)
        {
            this.HoTen = hoTen;
            this.NgayThangNamSinh = ngayThangNamSinh;
            this.GioiTinh = gioiTinh;
            this.cmnd = Cmnd;
            this.DanToc = danToc;
            this.TinhTrangHonNhan = tinhTrangHonNhan;
            this.NoiDangKiKhaiSinh = noiDangKiKhaiSinh;
            this.QueQuan = queQuan;
            this.NoiThuongTru = noiThuongTru;
            this.TrinhDoHocVan = trinhDoHocVan;
            this.NgheNghiep = ngheNghiep;
            this.Luong = luong;
            this.SoLanKetHon = soLanKetHon;
            this.TamTru = tamTru;
            this.NoiCapCMND = noiCapCMND;
            this.NgayCap = ngayCap;
            this.QuocTich = quocTich;
        }
        public CongDan(string Cmnd, string hoTen, string ngayThangNamSinh, string gioiTinh, string danToc, string queQuan, string noiDangKiKhaiSinh)
        {
            this.HoTen = hoTen;
            this.NgayThangNamSinh = ngayThangNamSinh;
            this.GioiTinh = gioiTinh;
            this.cmnd = Cmnd;
            this.DanToc = danToc;
            this.NoiDangKiKhaiSinh = noiDangKiKhaiSinh;
            this.QueQuan = queQuan;

        }
        public CongDan(string Cmnd,string HoTen) 
        {            
            this.cmnd = Cmnd;
            this.hoTen=HoTen;
        }
        public CongDan(string Cmnd)
        {
            this.cmnd = Cmnd;
        }
        public CongDan(string cccd, string hoTen, string ngayThangNamSinh, string gioiTinh, string danToc, string tinhTrangHonNhan, string queQuan, string noiThuongTru, string ngheNghiep)
        {
            this.CMND = cccd;
            this.HoTen = hoTen;
            this.NgayThangNamSinh = ngayThangNamSinh;
            this.GioiTinh = gioiTinh;
            this.DanToc = danToc;
            this.TinhTrangHonNhan = tinhTrangHonNhan;
            this.QueQuan = queQuan;
            this.NoiThuongTru = noiThuongTru;
            this.NgheNghiep = ngheNghiep;
        }

        public CongDan(string HoTen,string ngayThangNamSinh, string gioiTinh, string danToc) 
        {
            this.danToc = danToc;
            this.HoTen = HoTen;
            this.gioiTinh=gioiTinh;
            this.ngayThangNamSinh=ngayThangNamSinh;

        }
        public CongDan(string TamTru,string Cmnd,string NgayCap)
        {
            this.tamTru=TamTru;
            this.cmnd = Cmnd;
            this.ngayCap = NgayCap;
        }
        public CongDan(string hoTen, string ngayThangNamSinh, string gioiTinh, string Cmnd, string danToc, string tinhTrangHonNhan, string noiDangKiKhaiSinh, string queQuan, string noiThuongTru,string quocTich)
        {
            this.HoTen = hoTen;
            this.NgayThangNamSinh = ngayThangNamSinh;
            this.GioiTinh = gioiTinh;
            this.cmnd = Cmnd;
            this.DanToc = danToc;
            this.TinhTrangHonNhan = tinhTrangHonNhan;
            this.NoiDangKiKhaiSinh = noiDangKiKhaiSinh;
            this.QueQuan = queQuan;
            this.NoiThuongTru = noiThuongTru;
            this.QuocTich = quocTich;
        }
        ~CongDan()
        {

        }
    }
}