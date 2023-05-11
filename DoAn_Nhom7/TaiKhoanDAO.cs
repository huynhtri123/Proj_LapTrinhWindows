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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbC = new DBConnection();
        public bool KiemTraTonTai(string tk)
        {
            return dbC.KiemTraTaiKhoanTonTai(tk);
        }
        public void DangKy(TaiKhoan tk)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("INSERT INTO TaiKhoan( TaiKhoan,MatKhau)  VALUES ('{0}', '{1}')",tk.taiKhoan,tk.matKhau);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DangNhap(TaiKhoan tk)
        {
            try
            {
                conn.Open();
                string sqlStr = "Select * from TaiKhoan where TaiKhoan = '" + tk.taiKhoan + "' and MatKhau = '" + tk.matKhau + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {

                }
                else
                    MessageBox.Show("Tai khoan ban dang nhap sai");

            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
