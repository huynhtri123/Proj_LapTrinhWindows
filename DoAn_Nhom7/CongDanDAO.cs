using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class CongDanDAO
    {
        DBConnection db = new DBConnection();
        public void Them(CongDan cd)
        {
            string sqlStr = string.Format("INSERT INTO CongDan( hoTen , ngayThangNamSinh , gioiTinh , cmnd , danToc , tinhTrangHonNhan , noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,tamTru,noiCapCMND,ngayCap,soLanKetHon,quocTich)  VALUES (N'{0}', N'{1}',N'{2}', '{3}',N'{4}', N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}', N'{11}', N'{12}', N'{13}', N'{14}', N'{15}',N'{16}')", cd.HoTen,cd.NgayThangNamSinh,cd.GioiTinh,cd.CMND,cd.DanToc,cd.TinhTrangHonNhan,cd.NoiDangKiKhaiSinh,cd.QueQuan,cd.NoiThuongTru,cd.TrinhDoHocVan,cd.NgheNghiep, cd.Luong,cd.tamTru,cd.noiCapCMND,cd.NgayCap,cd.soLanKetHon,cd.QuocTich);
            db.XuLy1(sqlStr);
        }
        public void Sua(CongDan cd)
        {
            string sqlStr = string.Format("UPDATE CongDan SET hoTen =N'{12}',  ngayThangNamSinh = N'{0}', gioiTinh= N'{1}' , cmnd = '{2}', danToc= N'{3}', tinhTrangHonNhan=N'{4}', noiDangKiKhaiSinh= N'{5}', queQuan=N'{6}', noiThuongTru= N'{7}', trinhDoHocVan= N'{8}', luong = N'{9}', ngheNghiep=N'{10}', tamTru = N'{13}', noiCapCMND = N'{14}', ngayCap = '{15}', soLanKetHon = N'{16}',quocTich = N'{17}' WHERE cmnd = '{11}'",  cd.NgayThangNamSinh, cd.GioiTinh, cd.CMND, cd.DanToc, cd.TinhTrangHonNhan, cd.NoiDangKiKhaiSinh, cd.QueQuan, cd.NoiThuongTru, cd.TrinhDoHocVan, cd.Luong, cd.NgheNghiep,cd.CMND,cd.HoTen,cd.tamTru,cd.noiCapCMND,cd.NgayCap,cd.soLanKetHon,cd.QuocTich);
            db.XuLy1(sqlStr);
        }
        public void Xoa(CongDan cd)
        {
            string mashk = TimMaSHK(cd.CMND);
            string sqlStr1 = string.Format("delete from ThanhVienSoHoKhau where CMNDThanhVien ='{0}'", cd.CMND);
            string sqlStr2 = string.Format("delete from QuanHe where CMND1 = '{0}' or CMND2 = '{1}'",cd.CMND,cd.CMND);
            string sqlStr = string.Format("DELETE FROM CongDan WHERE cmnd = '{0}'", cd.CMND);
            string sqlStr3 = string.Format("delete from ThanhVienSoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            string sqlStr4 = string.Format("delete from SoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            db.XuLy(sqlStr1);
            db.XuLy(sqlStr3);
            db.XuLy(sqlStr4);
            db.XuLy(sqlStr2);
            db.XuLy1(sqlStr);
        }
        public void Xoa1(CongDan cd)
        {
            string mashk = TimMaSHK(cd.CMND);
            string sqlStr1 = string.Format("delete from ThanhVienSoHoKhau where CMNDThanhVien ='{0}'", cd.CMND);
            string sqlStr2 = string.Format("delete from QuanHe where CMND1 = '{0}' or CMND2 = '{1}'", cd.CMND, cd.CMND);
            //string sqlStr = string.Format("DELETE FROM CongDan WHERE cmnd = '{0}'", cd.CMND);
            string sqlStr3 = string.Format("delete from ThanhVienSoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            string sqlStr4 = string.Format("delete from SoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            db.XuLy(sqlStr1);
            db.XuLy(sqlStr3);
            db.XuLy(sqlStr4);
            db.XuLy1(sqlStr2);
            //db.XuLy1(sqlStr);
        }
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return db.TimMaSHK(cmnd, sqlStr);
        }
        public DataTable DanhSach()
        {
            string sqlStr ="select * from CongDan";
            return db.DanhSach(sqlStr);
        }
        public void CapNhatLyHon(CongDan cd)
        {
            string sqlStr = string.Format("UPDATE CongDan SET  tinhTrangHonNhan=N'Độc Thân' WHERE CMND = '{0}'", cd.CMND);
            db.XuLy(sqlStr);
        }
        public void CapNhatQuanHeLyHon(CongDan a,CongDan b)
        {
            string sqlStr = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'",a.CMND, b.CMND);
            db.XuLy(sqlStr);
        }
        public void CapNhatTamTru(CongDan cd)
        {
            string n = "";
            string sqlStr = string.Format("Select * from CongDan where cmnd = '" + cd.cmnd + "'");
            n = db.CapNhatTamTru(sqlStr, n);
            string sqlStr2 = string.Format("UPDATE CongDan SET tamTru = N'{0} {1}\n{2}' WHERE CMND ='{3}'", cd.tamTru, cd.ngayCap, n, cd.CMND);
            db.XuLy1(sqlStr2);
        }
        public void CapNhatKetHon(CongDan nam,CongDan nu)
        {
            string sqlStr = string.Format("UPDATE CongDan SET  tinhTrangHonNhan=N'Đã kết hôn với người có cmnd là " + nu.CMND + "' WHERE CMND = '{0}'", nam.CMND);
            db.XuLy(sqlStr);
            string sqlStr1 = string.Format("UPDATE CongDan SET  tinhTrangHonNhan=N'Đã kết hôn với người có cmnd là " + nam.CMND + "' WHERE CMND = '{0}'", nu.CMND);
            db.XuLy(sqlStr1);
            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", nam.cmnd, nu.cmnd, "Vợ", "Chồng");
            db.XuLy(sqlStr2);
            string sqlStr3 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')",  nu.cmnd, nam.cmnd, "Chồng", "Vợ");
            db.XuLy(sqlStr3);
        }
        public void CapNhatKhaiSinh(string cmndbo,string cmndme,string cmndcon,string quanhe)
        {
            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", cmndbo, cmndcon, quanhe, "Bố");
            db.XuLy(sqlStr2);
            string sqlStr3 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", cmndcon, cmndbo, "Bố", quanhe);
            db.XuLy(sqlStr3);
            string sqlStr4 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", cmndme, cmndcon, quanhe, "Mẹ");
            db.XuLy(sqlStr4);
            string sqlStr5 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", cmndcon, cmndme, "Mẹ", quanhe);
            db.XuLy(sqlStr5);
        }
        public DataSet TimCongDanDaKetHon(DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE tinhTrangHonNhan != 'Doc Than'";
            return db.TimCongDanDaKetHon(sqlStr, dtgv);
        }
        public DataSet TimCongDanDocThan(DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE tinhTrangHonNhan = 'Doc Than'";
            return db.TimCongDanDaKetHon(sqlStr, dtgv);
        }
        public DataSet TimCongDanTheoCCCD(string cccd, DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE cmnd = '" + cccd + "'";
            return db.TimCongDanTheoCCCD(sqlStr, dtgv);
        }
        public DataSet TimCongDanTheoTen(string name, DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE hoTen LIKE N'%" + name + "%'";
            return db.TimCongDanTheoTen(sqlStr, dtgv);
        }
    }
}
