using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn_Nhom7
{
    public class ThongKeDAO
    {
        DBConnection dbC = new DBConnection();
        public void XuLy(Chart chart)
        {
            string sqlStr = string.Format("Select gioiTinh, count(*) as soLuong from CongDan group by gioiTinh");
            dbC.XuLyThongKeDanSo(sqlStr, chart);
        }
    }
}
