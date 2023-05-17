using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    internal class ThueDAO
    {
        DBConnection dbconnection = new DBConnection();
        public DataTable DanhSach()
        {
            string sqlStr = string.Format("SELECT *FROM Thue");
            return dbconnection.DanhSach(sqlStr);
        }
        public DataSet timCongDanTheoCCCD(Thue thue)
        {
            string sqlStr = "SELECT * from CongDan WHERE cmnd = '" + thue.CCCD + "' ";
            DataSet dts = dbconnection.timCongDanTheoCCCD(sqlStr, thue);
            return dts;
        }
        public void DongTien(Thue thue)
        {
            string sqlStr = string.Format("UPDATE Thue SET TinhTrang = N'{0}' WHERE CCCD = '{1}'",thue.TinhTrang,thue.CCCD);
            dbconnection.XuLy(sqlStr);
        }
        public void ThemDoiTuong(Thue thue)
        {
            string sqlStr = string.Format("INSERT INTO Thue( CCCD, LoaiThue, MucThue, TinhTrang)  VALUES ('{0}', N'{1}','{2}', N'{3}')", thue.CCCD, thue.LoaiThue, thue.MucThue, thue.TinhTrang);
            dbconnection.XuLy1(sqlStr);
        }
        public void SuaDoiTuong(Thue thue)
        {
            string sqlStr = string.Format("UPDATE Thue SET LoaiThue = N'{0}' , MucThue = '{1}', TinhTrang = N'{2}' WHERE CCCD = '{3}'", thue.LoaiThue, thue.MucThue, thue.TinhTrang, thue.CCCD);
            dbconnection.XuLy1(sqlStr);
        }
        public void XoaDoiTuong(Thue thue)
        {
            string sqlStr = string.Format("DELETE FROM Thue WHERE CCCD = '{0}'", thue.CCCD);
            dbconnection.XuLy1(sqlStr);
        }
        public void LayThongTinCongDan(string cccd, DataGridView dtgv, TextBox luong, TextBox ten, TextBox nghe)
        {
            string sqlStr = string.Format("SELECT * FROM CongDan WHERE cmnd = '" + cccd + "'");
            dbconnection.LayThongTinCongDan_Thue(sqlStr, dtgv, luong, ten, nghe);
        }
    }
}
