using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class HonNhanDAO
    {
        DBConnection dbc = new DBConnection();
        public bool KiemTraHonNhan(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return dbc.KiemTraHonNhan(sqlStr);
        }
        public bool ThoaDieuKienKetHon(string cmndNam, string cmndNu)
        {
            if (Tuoi(cmndNam) >= 20 && Tuoi(cmndNu) >= 18 && KiemTraHonNhan(cmndNam) == true && KiemTraHonNhan(cmndNu) == true && CungGiaDinh(cmndNam, cmndNu))
                return true;
            else return false;
        }
        public bool CungGiaDinh(string cmndNam, string cmndNu)
        {
            if (TimMaSHK(cmndNam) != null && TimMaSHK(cmndNu) != null)
                if (TimMaSHK(cmndNam) == TimMaSHK(cmndNu))
                    return false;
            return true;

        }
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return dbc.TimMaSHK(cmnd, sqlStr);
        }
        public string GioiTinh(string cmnd)
        {
            string sqlStr = string.Format("SELECT gioiTinh from CongDan Where cmnd = '" + cmnd + "'");
            return dbc.GioiTinh(sqlStr);
        }
        public int Tuoi(string cmnd)
        {
            //string sqlStr = string.Format("SELECT DATEDIFF(year, cast(ngayThangNamSinh as datetime), getdate()) AS  Tuoi from CongDan Where cmnd = '" + cmnd + "'");
            string sqlStr = string.Format("SELECT DATEDIFF(year, CONVERT(datetime, ngayThangNamSinh, 103), GETDATE()) AS Tuoi FROM CongDan WHERE cmnd = '"+cmnd+"'");
            return dbc.TinhTuoi(sqlStr);
        }
        public bool ThoaDieuKienLyHon(string cmndNam, string cmndNu)
        {
            if (KiemTraHonNhan(cmndNam) == false && KiemTraHonNhan(cmndNu) == false)
                return true;
            else return false;
        }
        public void LapDayThongTin_KetHon(TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox danToc, TextBox queQuan, TextBox thuongTru)
        {
            string sqlStr = String.Format("Select * from CongDan where cmnd = '" + cmnd.Text + "'");
            dbc.LapDayThongTin(sqlStr, cmnd, hoTen, ngaySinh, danToc, queQuan, thuongTru);
        }
        public void LapDayThongTin_LyHon( string cmnd, TextBox hoTen, TextBox ngaySinh, TextBox thuongTru)
        {
            string sqlStr = String.Format("Select * from CongDan where cmnd = '" + cmnd + "'");
            dbc.LapDayThongTinLyHon(sqlStr, cmnd, hoTen, ngaySinh, thuongTru);
        }
    }
}
