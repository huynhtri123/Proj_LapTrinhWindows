using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    internal class ToKhaiSinhDAO
    {
        DBConnection db = new DBConnection();
        public void LapDayThongTinKhaiSinh(string cmnd, Label a, Label b, Label a1, Label s, Label a2, Label a3, Label a4, Label a5)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            db.LapDayThongTinKhaiSinh(sqlStr, a, b, a1, s, a2, a3, a4, a5);
        }
        public void LapDayThongTinKhaiSinhCon(string cmnd, Label a, Label a1, Label a2, Label a3, Label a4, Label a5, Label a6, Label a7)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            db.LapDayThongTinKhaiSinhCon(sqlStr, a, a1, a2, a3, a4, a5, a6, a7);
        }
    }
}
