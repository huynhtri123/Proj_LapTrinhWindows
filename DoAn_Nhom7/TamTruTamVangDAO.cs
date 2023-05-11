using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class TamTruTamVangDAO
    {
        DBConnection dbC = new DBConnection();
        public void LapDayThongTinTamTru(TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox queQuan, TextBox thuongTru)
        {
            string sqlStr = String.Format("Select * from CongDan where cmnd = '" + cmnd.Text + "'");
            dbC.LapDayThongTinTamTru(sqlStr,cmnd,hoTen, ngaySinh, queQuan, thuongTru);
        }       
    }
}
