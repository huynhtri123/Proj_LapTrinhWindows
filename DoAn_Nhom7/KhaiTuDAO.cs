using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class KhaiTuDAO
    {
        DBConnection dbC = new DBConnection();
        public void KhaiTu_KeyDown(TextBox cmnd, TextBox ten, TextBox ngsinh, TextBox honNhan, TextBox noiThuongTru, TextBox gioiTinh, TextBox danToc, TextBox quocTich, TextBox queQuan, TextBox ngheNghiep)
        {
            string sqlStr = string.Format("Select * from CongDan where cmnd = '" + cmnd.Text + "'");
            dbC.KhaiTu_KeyDown(sqlStr, cmnd, ten, ngsinh, honNhan, noiThuongTru, gioiTinh, danToc, quocTich, queQuan, ngheNghiep);
        }
    }
}
