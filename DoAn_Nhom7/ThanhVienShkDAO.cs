using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class ThanhVienShkDAO
    {
        DBConnection dbc = new DBConnection();
        public void ThietLapMoiQuanHeBoCon(ThanhVienShk tv,string quanhe)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, quanhe, "Bố");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bố", quanhe);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienShk tv)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Vợ", "Chồng");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Chồng", "Vợ");
                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Vo', quanHeVoiCMND2 = 'Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
        }
        public void ThietLapMoiQuanHeBoConDau(ThanhVienShk tv)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))

            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bố Chồng", "Con Dâu");
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }

            //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);

        }
        public void ThietLapMoiQuanHeOngChau(ThanhVienShk tv,string quanhe)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))

            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, quanhe, "Ông");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Ông", quanhe);

                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
            
        }
        public void ThietLapQuanHeGiaDinh(ThanhVienShk tv)
        {
            string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.MaShk + "'");
            dbc.ThietLapQuanHeGiaDinh(tv, sqlStr);
        }
        public void ThietLapQuanHe(ThanhVienShk tv)
        {
            if (tv.QuanHe == "Con Trai" || tv.QuanHe == "Con Gái")
                ThietLapMoiQuanHeBoCon(tv,tv.QuanHe);
            else if(tv.QuanHe=="Vợ")
                ThietLapMoiQuanHeVoChong(tv);
            else if(tv.QuanHe == "Con Dâu")
                ThietLapMoiQuanHeBoConDau(tv);
            else if (tv.QuanHe == "Cháu Trai" || tv.QuanHe == "Cháu Gái")
                ThietLapMoiQuanHeOngChau(tv,tv.QuanHe);
            ThietLapQuanHeGiaDinh(tv);
        }
        public void ThemThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '{0}', '{1}', '{2}', quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}'", tv.MaShk, tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy1(sqlStr);
        }
        public void XoaTamThanhVien(ThanhVienShk tv)
        {
            string sqlStr4 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            string sqlStr5 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndThanhVien, tv.CmndChuHo); 
            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy1(sqlStr3);
            dbc.XuLy(sqlStr4);
            dbc.XuLy(sqlStr5);
        }
        public void XoaThanhVien(ThanhVienShk tv)
        {
            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy1(sqlStr3);
        }
        public void DienThanhVienSHK(string cmnd, TextBox mashk, TextBox hoten, TextBox gioitinh, TextBox quanhe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd == '{0}'",cmnd);
            dbc.DienThanhVienSHK(sqlStr, mashk, hoten, gioitinh, quanhe);
        }
        public void ThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e, DataGridView dtgvThanhVienShk, TextBox cmndTv, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, ComboBox quanHe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd = '{0}'", cmndTv.Text);
            dbc.ThanhVienShk_CellClick(sender, e, sqlStr, dtgvThanhVienShk, cmndTv, maShkTv, hoTenTv, gioiTinhTv, quanHe);
        }
    }
}
