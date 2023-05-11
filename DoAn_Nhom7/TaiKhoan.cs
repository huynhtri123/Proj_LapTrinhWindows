using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class TaiKhoan
    {
        public string taiKhoan;
        public string matKhau;

        public string Taikhoan
        {
            get { return this.taiKhoan; }
            set { this.taiKhoan = value; }
        }
        public string MatKhau
        {
            get { return this.matKhau; }
            set { this.matKhau = value; }
        }
        public TaiKhoan()
        {

        }
        public TaiKhoan(string Taikhoan,string MatKhau)
        {
            this.taiKhoan = Taikhoan;
            this.matKhau = MatKhau;
        }
        ~TaiKhoan()
        {

        }
    }
}
