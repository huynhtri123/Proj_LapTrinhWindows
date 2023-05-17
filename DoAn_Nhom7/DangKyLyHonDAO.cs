using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    internal class DangKyLyHonDAO
    {
        DBConnection db = new DBConnection();
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
        public string CMNDVoChong(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return db.CMNDVoChong(cmnd, sqlStr);
        }
    }
}
