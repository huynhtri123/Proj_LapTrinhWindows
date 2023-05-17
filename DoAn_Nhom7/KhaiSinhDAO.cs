using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class KhaiSinhDAO
    {
        DBConnection db = new DBConnection();
        public bool KiemTraHonNhan(string cmnd, string cmndCha, string cmndMe)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return db.KiemTraVoChong(sqlStr, cmndCha, cmndMe);
        }
        public int SoLuongThanhVien(string cmnd)
        {
            string a = TimMaSHK(cmnd);

            string sqlStr = "SELECT COUNT(*) FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + a + "'";
            return db.SoLuongThanhVien(sqlStr);
        }
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return db.TimMaSHK(sqlStr);
        }
        public string TimChuHoSHK(string mashk)
        {
            string sqlStr = "SELECT CMNDChuHo FROM SoHoKhau WHERE maSoHoKhau = '" + mashk + "'";
            return db.TimChuHoSHK(sqlStr);
        }
        public void KhaiSinh_KeyDown(TextBox cmnd, TextBox ten, TextBox danToc, TextBox quocTich)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd.Text + "'";
            db.KhaiSinh_KeyDown(sqlStr, cmnd, ten, danToc, quocTich);
        }
        public string CMNDVoChong(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return db.CMNDVoChong(cmnd, sqlStr);
        }
    }
}
