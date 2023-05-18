using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    internal class SoHoKhauDAO
    {
        DBConnection dbconnection = new DBConnection();
        public DataTable DanhSach()
        {
            string sqlStr = string.Format("SELECT *FROM SoHoKhau ");
            return dbconnection.DanhSach(sqlStr);
        }
        public DataTable DanhSachThanhVien(string maShk)
        {
            string sqlStr = string.Format("SELECT maSoHoKhau,CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + maShk + "'");
            return dbconnection.DanhSach(sqlStr);
        }
        public void ThemSoHoKhau(SoHoKhau hk)
        {
            string sqlStr = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi,ngayLap)  VALUES ('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", hk.MaSoHoKhau, hk.CMND, hk.MaKV, hk.XaPhuong, hk.QuanHuyen, hk.TinhThanhPho
            , hk.DiaChi, hk.NgayLap);
            dbconnection.XuLy1(sqlStr);
        }
        public void SuaSoHoKhau(SoHoKhau hk)
        {
            string a = string.Format("UPDATE SoHoKhau SET maKV=N'{0}', xaPhuong=N'{1}', quanHuyen=N'{2}' ,tinhTP=N'{3}', diaChi=N'{4}',ngayLap='{5}' WHERE maSoHoKhau = '" + hk.MaSoHoKhau + "'", hk.MaKV, hk.XaPhuong, hk.QuanHuyen, hk.TinhThanhPho, hk.DiaChi, hk.NgayLap);
            //Tạo bảng ảo
            string maSHKMoi = hk.MaSoHoKhau + "*";
            string sqlStr = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '"+maSHKMoi+"', '"+hk.CMND+"', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '"+hk.MaSoHoKhau+"'");
            string sqlStr1 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '"+maSHKMoi+"', '"+hk.CMND+ "', CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '"+hk.MaSoHoKhau+"' AND QuanHe.CMND1 = '"+hk.CMND+"'");
            string sqlStr5 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '"+maSHKMoi+"', '" + hk.CMND + "', CMNDChuHo, quanHeVoiCMND1 FROM SoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = SoHoKhau.CMNDChuHo WHERE SoHoKhau.maSoHoKhau = '" + hk.MaSoHoKhau + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
           // Cập nhật
            string sqlStr2 = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'",hk.MaSoHoKhau);
            string sqlStr7 = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '" + maSHKMoi + "'");
            string sqlStr8 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '" + maSHKMoi + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr9 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', CMNDChuHo, quanHeVoiCMND1 FROM SoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = SoHoKhau.CMNDChuHo WHERE SoHoKhau.maSoHoKhau = '" + maSHKMoi + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr10 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", maSHKMoi);
            string sqlStr11 = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'", maSHKMoi);
            dbconnection.XuLy(a);

            dbconnection.XuLy(sqlStr);
            dbconnection.XuLy(sqlStr1);
            dbconnection.XuLy(sqlStr5);
            dbconnection.XuLy(sqlStr3);
            dbconnection.XuLy(sqlStr2);
//
            dbconnection.XuLy(sqlStr7);
            dbconnection.XuLy(sqlStr8);
            dbconnection.XuLy(sqlStr9);
            dbconnection.XuLy(sqlStr10);
            dbconnection.XuLy1(sqlStr11);
        }
        public void XoaSoHoKhau(SoHoKhau hk)
        {
            string sqlStr1 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
            string sqlStr = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
            dbconnection.XuLy(sqlStr1);
            dbconnection.XuLy1(sqlStr);
        }
        public void LapSoHoKhau(TextBox txtMaSoHoKhau,TextBox txtCMND, TextBox txtMaKhuVuc,ComboBox txtXaPhuong,ComboBox txtQuanHuyen,ComboBox txtTinhThanhPho,TextBox txtDiaChi,DateTimePicker dtpNgayLap)
        {
            string sqlStr = string.Format("SELECT * FROM SoHoKhau WHERE maSoHoKhau = '" + txtMaSoHoKhau.Text + "'");
            dbconnection.LapSoHoKhau(sqlStr, txtMaSoHoKhau, txtCMND, txtMaKhuVuc, txtXaPhuong, txtQuanHuyen, txtTinhThanhPho, txtDiaChi, dtpNgayLap);
        }
        public void LapTVSoHoKhau(TextBox txtCMND,TextBox txtCmnd_tv,TextBox txtMaShk_tv,TextBox txtMaSoHoKhau,TextBox txtHoTen_tv,TextBox txtGioiTinh_tv,ComboBox txtQuanHe)
        {
            string sqlStr = string.Format("SELECT CongDan.hoTen, CongDan.gioiTinh , QuanHe.quanHeVoiCMND1 FROM QuanHe JOIN CongDan ON CongDan.CMND = QuanHe.CMND2 WHERE QuanHe.CMND1 = '" + txtCMND.Text + "' AND QuanHe.CMND2 = '" + txtCmnd_tv.Text + "' ");
            dbconnection.LapTVSoHoKhau(sqlStr, txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
            
            if (KiemTraSHK(txtCmnd_tv.Text) == false)
                txtMaShk_tv.Text = TimMaSHK(txtCmnd_tv.Text);
            else
                txtMaShk_tv.Text = "";
        }
        public void TraCuuSoHoKhau_Click(object sender, EventArgs e, DataGridView dtgvSoHoKhau, DataGridView dtgvThanhVienShk, TextBox maShk, TextBox cmndTv, TextBox traCuu, TextBox cmnd, TextBox maKv, ComboBox xaPhuong, ComboBox quanHuyen, ComboBox tinhTp, TextBox diaChi, DateTimePicker ngayLap, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, ComboBox quanHe)
        {
            string sqlStr = string.Format("SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '" + traCuu.Text + "' OR CMNDChuHo = '" + traCuu.Text + "'");
            
            string timShk = dbconnection.TimTheoThanhTraCuu(sqlStr);
            if (timShk != "")
            {
                maShk.Text = timShk;
                LapSoHoKhau(maShk, cmnd, maKv, xaPhuong, quanHuyen, tinhTp, diaChi, ngayLap);
                LapTVSoHoKhau(cmnd, cmndTv, maShkTv, maShk, hoTenTv, gioiTinhTv, quanHe);

                foreach (DataGridViewRow row in dtgvSoHoKhau.Rows)
                {
                    object value = row.Cells[1].Value;
                    if (value != null && value.ToString() == cmnd.Text)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
                string dsTv = string.Format("SELECT maSoHoKhau,CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + timShk + "'");
                dtgvThanhVienShk.DataSource = dbconnection.DanhSach(dsTv);
                foreach (DataGridViewRow row in dtgvThanhVienShk.Rows)
                {
                    object value = row.Cells[1].Value;
                    if (value != null && value.ToString() == cmndTv.Text)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
            else MessageBox.Show("Không tìm thấy sổ hộ khẩu!");
        }
        public void LapThongTin(TextBox txtCmnd_tv, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv)
        {
            string sqlStr = string.Format("SELECT hoTen,gioiTinh FROM CongDan WHERE cmnd = '" + txtCmnd_tv.Text + "' ");
            dbconnection.LapThongTin_Shk(sqlStr,txtCmnd_tv, txtHoTen_tv, txtGioiTinh_tv);
        }
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return dbconnection.TimMaSHK(sqlStr);
        }
        public bool KiemTraTVSHK(string cmnd)
        {
            string sqlStr = " SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= '" + cmnd + "'";
            return dbconnection.KiemTraTVSHK(sqlStr);
        }
        public bool KiemTraSHK(string cmnd)
        {
            string sqlStr1 = " SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= '" + cmnd + "'";
            string sqlStr2 = " SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo= '" + cmnd + "'";
            string sqlStr = sqlStr2 + "UNION" + sqlStr1;
            return dbconnection.KiemTraSHK(sqlStr);
        }
    }
}
