using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    internal class TaiKhoanDAO
    {
        DBConnection dbC = new DBConnection();
        public bool KiemTraTonTai(string tk)
        {
            string sqlStr = string.Format("SELECT * FROM TaiKhoan WHERE TaiKhoan = '{0}'", tk);
            return dbC.KiemTraTaiKhoanTonTai(tk, sqlStr);
        }
        public void DangKy(TaiKhoan tk)
        {
            string sqlStr = string.Format("INSERT INTO TaiKhoan( TaiKhoan,MatKhau)  VALUES ('{0}', '{1}')", tk.taiKhoan, tk.matKhau);
            dbC.DangKyTaiKhoan(sqlStr);
        }
        public void DangNhap(TaiKhoan tk)
        {
            string sqlStr = "Select * from TaiKhoan where TaiKhoan = '" + tk.taiKhoan + "' and MatKhau = '" + tk.matKhau + "'";
            dbC.DangNhap(sqlStr);
        }
    }
}
