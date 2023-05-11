using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class DangKyKetHonDAO
    {
        DBConnection db = new DBConnection();
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return db.TimMaSHK(cmnd, sqlStr);
        }
        public string TimChuHoSHK(string mashk)
        {
            string sqlStr = "SELECT CMNDChuHo FROM SoHoKhau WHERE maSoHoKhau = '" + mashk + "'";
            return db.TimChuHoSHK(mashk, sqlStr);
        }
    }
}
