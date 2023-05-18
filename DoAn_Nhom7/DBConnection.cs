using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn_Nhom7
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        public void XuLy(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
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
        public void XuLy1(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thành công");

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
        public DataTable DanhSach(string sqlStr)
        {
            DataTable dtds = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dtds);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtds;
        }
        public DataSet timCongDanTheoCCCD(string sqlStr, Thue thue)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataSet dts = new DataSet();
            adapter.Fill(dts, "CCCD");
            conn.Close();
            return dts;
        }
        public void LapDayThongTin(string sqlStr, TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox danToc, TextBox queQuan, TextBox thuongTru)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                hoTen.Text = Convert.ToString(dta["hoTen"]);
                ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                danToc.Text = Convert.ToString(dta["danToc"]);
                queQuan.Text = Convert.ToString(dta["queQuan"]);
                thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
            }
            conn.Close();
        }
        public void LapDayThongTinTamTru(string sqlStr, TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox queQuan, TextBox thuongTru, TextBox ngayCap)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    hoTen.Text = Convert.ToString(dta["hoTen"]);
                    ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                    queQuan.Text = Convert.ToString(dta["queQuan"]);
                    thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
                    ngayCap.Text = Convert.ToString(dta["ngayCap"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public string CapNhatTamTru(string sqlStr, string n)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    n = n + Convert.ToString(dta["tamTru"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return n;
        }
       
        public string CMNDVoChong(string cmnd, string sqlStr)
        {
            conn.Open();
            string a = "";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read())
            {
                a = Convert.ToString(dta["tinhTrangHonNhan"]);
                if (a != "Độc Thân")
                {
                    a = a.Substring(32);
                }
                else a = "";
            }
            conn.Close();
            return a;
        }
        public bool KiemTraHonNhan(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["tinhTrangHonNhan"]);
                if (a == "Độc Thân")
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public bool KiemTraVoChong(string sqlStr, string a, string b)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToString(dr["tinhTrangHonNhan"]);
                string cmnd = a.Substring(32);
                if (cmnd == b)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public int SoLuongThanhVien(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            int k = (int)cmd.ExecuteScalar();
            conn.Close();
            return k;
        }
        public void LapDayThongTinLyHon(string sqlStr, string cmnd, TextBox hoTen, TextBox ngaySinh, TextBox thuongTru)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    hoTen.Text = Convert.ToString(dta["hoTen"]);
                    ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                    thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataSet TimCongDanDaKetHon(string sqlStr, DataGridView dtgv)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "tinhTrangHonNhan");
            if (ds.Tables["tinhTrangHonNhan"].Rows.Count > 0)
            {
                dtgv.DataSource = ds.Tables["hoTen"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
            conn.Close();
            return ds;
        }
        public DataSet TimCongDanTheoCCCD(string sqlStr, DataGridView dtgv)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "cmnd");
            if (ds.Tables["cmnd"].Rows.Count > 0)
            {
                dtgv.DataSource = ds.Tables["cmnd"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy ai có CMND này!");
            }
            conn.Close();
            return ds;
        }
        public DataSet TimCongDanTheoTen(string sqlStr, DataGridView dtgv)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "hoTen");
            if (ds.Tables["hoTen"].Rows.Count > 0)
            {
                dtgv.DataSource = ds.Tables["hoTen"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy ai có tên này!");
            }
            conn.Close();
            return ds;
        }
        public int TinhTuoi(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int tuoi = 0;
            if (dr.Read())
            {
                tuoi = Convert.ToInt32(dr["Tuoi"].ToString());
            }
            conn.Close();
            return tuoi;
        }
        public string GioiTinh(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string gioiTinh = "";
            if (dr.Read())
            {
                gioiTinh = Convert.ToString(dr["gioiTinh"].ToString());
            }
            conn.Close();
            return gioiTinh;
        }

        public void KhaiTu_KeyDown(string sqlStr, TextBox cmnd, TextBox ten, TextBox ngsinh, TextBox honNhan, TextBox noiThuongTru, TextBox gioiTinh, TextBox danToc, TextBox quocTich, TextBox queQuan, TextBox ngheNghiep)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                ten.Text = Convert.ToString(dta["hoTen"]);
                ngsinh.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                gioiTinh.Text = Convert.ToString(dta["gioiTinh"]);
                danToc.Text = Convert.ToString(dta["danToc"]);
                honNhan.Text = Convert.ToString(dta["tinhTrangHonNhan"]);
                quocTich.Text = "hhh";
                queQuan.Text = Convert.ToString(dta["queQuan"]);
                noiThuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
                ngheNghiep.Text = Convert.ToString(dta["ngheNghiep"]);
            }
            conn.Close();
        }
        public void KhaiSinh_KeyDown(string sqlStr, TextBox cmnd, TextBox ten, TextBox danToc, TextBox quocTich)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                ten.Text = Convert.ToString(dta["hoTen"]);
                danToc.Text = Convert.ToString(dta["danToc"]);
                quocTich.Text = Convert.ToString(dta["quocTich"]);
            }
            conn.Close();
        }
        public string TimMaSHK(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {

                string a = Convert.ToString(dta["maSoHoKhau"]);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;
        }
        public string TimChuHoSHK(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {

                string a = Convert.ToString(dta["CMNDChuHo"]);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;
        }

        public bool KiemTraTaiKhoanTonTai(string input, string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["TaiKhoan"].ToString() == input)
                    return true;
            }
            conn.Close();
            return false;
        }
        public bool KiemTraSHK(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["maSoHoKhau"]);
                if (a != null)
                {
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return true;
        }

        public bool KiemTraTVSHK(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["maSoHoKhau"]);
                if (a != null)
                {
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return true;
        }
        public void ThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e, string sqlStr, DataGridView dtgvThanhVienShk, TextBox cmndTv, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, ComboBox quanHe)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dtgvThanhVienShk.Rows[e.RowIndex];
            cmndTv.Text = row.Cells[1].Value.ToString();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    maShkTv.Text = Convert.ToString(dta["maSoHoKhau"]);
                    hoTenTv.Text = Convert.ToString(dta["hoTen"]); ;
                    gioiTinhTv.Text = Convert.ToString(dta["gioiTinh"]);
                    quanHe.Text = Convert.ToString(dta["quanHeVoiChuHo"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void LapSoHoKhau(string sqlStr, TextBox txtMaSoHoKhau, TextBox txtCMND, TextBox txtMaKhuVuc, ComboBox txtXaPhuong, ComboBox txtQuanHuyen, ComboBox txtTinhThanhPho, TextBox txtDiaChi, DateTimePicker dtpNgayLap)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    txtCMND.Text = Convert.ToString(dta["CMNDChuHo"]);
                    txtMaKhuVuc.Text = Convert.ToString(dta["maKV"]);
                    txtXaPhuong.Text = Convert.ToString(dta["xaPhuong"]);
                    txtQuanHuyen.Text = Convert.ToString(dta["quanHuyen"]);
                    txtTinhThanhPho.Text = Convert.ToString(dta["tinhTP"]);
                    txtDiaChi.Text = Convert.ToString(dta["diaChi"]);
                    DateTime ngayLap = DateTime.ParseExact(Convert.ToString(dta["ngayLap"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dtpNgayLap.Value = ngayLap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void LapTVSoHoKhau(string sqlStr, TextBox txtCMND, TextBox txtCmnd_tv, TextBox txtMaShk_tv, TextBox txtMaSoHoKhau, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv, ComboBox txtQuanHe)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    txtHoTen_tv.Text = Convert.ToString(dta["hoTen"]); ;
                    txtGioiTinh_tv.Text = Convert.ToString(dta["gioiTinh"]);
                    txtQuanHe.Text = Convert.ToString(dta["quanHeVoiCMND1"]);
                }
                else
                {
                    txtMaShk_tv.Text = "";
                    txtHoTen_tv.Text = "";
                    txtGioiTinh_tv.Text = "";
                    txtQuanHe.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DangKyTaiKhoan(string sqlStr)
        {
            try
            {
                conn.Open();
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
        public int DangNhap(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    return 1;
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
            return 0;
        }
        public string TimTheoThanhTraCuu(string sqlStr)
        {
            string x = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    x = Convert.ToString(dta["maSoHoKhau"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("That bai");
            }
            finally
            {
                conn.Close();
            }
            return x;
        }       
        public void LapDayThongTinKhaiSinh(string sqlStr, Label a, Label b, Label a1, Label s, Label a2, Label a3, Label a4, Label a5)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text = Convert.ToString(dta["cmnd"]);
                b.Text = Convert.ToString(dta["hoTen"]);
                a1.Text = Convert.ToString(dta["hoTen"]);
                a2.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                s.Text = Convert.ToString(dta["hoTen"]);
                a3.Text = Convert.ToString(dta["danToc"]);
                a5.Text = Convert.ToString(dta["queQuan"]);
                a4.Text = Convert.ToString(dta["quocTich"]);
            }
            conn.Close();
        }
        public void LapDayThongTinKhaiSinhCon(string sqlStr, Label a, Label a1, Label a2, Label a3, Label a4, Label a5, Label a6, Label a7)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text = Convert.ToString(dta["cmnd"]);
                a1.Text = Convert.ToString(dta["hoTen"]);
                a2.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                a3.Text = Convert.ToString(dta["danToc"]);
                a5.Text = Convert.ToString(dta["queQuan"]);
                a4.Text = Convert.ToString(dta["quocTich"]);
                a6.Text = Convert.ToString(dta["noiDangKiKhaiSinh"]);
                a7.Text = Convert.ToString(dta["queQuan"]);

            }
            conn.Close();
        }
        public void LayThongTinCongDan_Thue(string sqlStr, DataGridView dtgv, TextBox luong, TextBox ten, TextBox nghe)
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CCCD");
                if (ds.Tables["CCCD"].Rows.Count > 0)
                    dtgv.DataSource = ds.Tables["CCCD"];

                luong.Text = ds.Tables["CCCD"].Rows[0][11].ToString();
                ten.Text = ds.Tables["CCCD"].Rows[0][0].ToString();
                nghe.Text = ds.Tables["CCCD"].Rows[0][10].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void XuLyThongKeDanSo(string sqlStr, Chart chartTyLeNamNu)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                chartTyLeNamNu.DataSource = ds;
                chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].XValueMember = "gioiTinh";
                chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].YValueMembers = "soLuong";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void LapDayThongTinCD(string sqlStr, TextBox cmnd, TextBox a, DateTimePicker dt, RadioButton b, RadioButton b1, ComboBox d, TextBox f, TextBox g, ComboBox j, TextBox k, ComboBox x, TextBox y, TextBox z, TextBox i, TextBox t, ComboBox n, DateTimePicker m, ComboBox p)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text = Convert.ToString(dta["hoTen"]);
                DateTime ngaySinh = DateTime.ParseExact(Convert.ToString(dta["ngayThangNamSinh"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt.Value = ngaySinh;
                if (Convert.ToString(dta["gioiTinh"]) == "Nữ")
                    b.Checked = true;
                else
                    b1.Checked = true;
                d.Text = Convert.ToString(dta["danToc"]);
                f.Text = Convert.ToString(dta["tinhTrangHonNhan"]);
                g.Text = Convert.ToString(dta["noiDangKiKhaiSinh"]);
                j.Text = Convert.ToString(dta["queQuan"]);
                k.Text = Convert.ToString(dta["noiThuongTru"]);
                x.Text = Convert.ToString(dta["trinhDoHocVan"]);
                y.Text = Convert.ToString(dta["ngheNghiep"]);
                z.Text = Convert.ToString(dta["luong"]);
                i.Text = Convert.ToString(dta["soLanKetHon"]);
                t.Text = Convert.ToString(dta["tamTru"]);
                n.Text = Convert.ToString(dta["noiCapCMND"]);
                if (Convert.ToString(dta["ngayCap"]) != "")
                {
                    DateTime ngaycap = DateTime.ParseExact(Convert.ToString(dta["ngayCap"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    m.Value = ngaycap;
                }
                p.Text = Convert.ToString(dta["QuocTich"]);

            }
            conn.Close();
        }

        public void PhucVuKhaiTu(string sqlStr, ref string maSoHoKhau, ref string maKhuVuc, ref string xaPhuong, ref string quanHuyen, ref string tinhThanhPho, ref string diaChi, ref string ngayLap)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    maSoHoKhau = Convert.ToString(dta["maSoHoKhau"]);
                    maKhuVuc = Convert.ToString(dta["maKV"]);
                    xaPhuong = Convert.ToString(dta["xaPhuong"]);
                    quanHuyen = Convert.ToString(dta["quanHuyen"]);
                    tinhThanhPho = Convert.ToString(dta["tinhTP"]);
                    diaChi = Convert.ToString(dta["diaChi"]);
                    ngayLap = Convert.ToString(dta["ngayLap"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void LapThongTin_Shk(string sqlStr, TextBox txtCmnd_tv, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv)
        {            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    txtHoTen_tv.Text = Convert.ToString(dta["hoTen"]); ;
                    txtGioiTinh_tv.Text = Convert.ToString(dta["gioiTinh"]);
                }
                else
                {
                    txtHoTen_tv.Text = "";
                    txtGioiTinh_tv.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }         
        }
        public void DienThanhVienSHK(string sqlStr, TextBox mashk, TextBox hoten, TextBox gioitinh, TextBox quanhe)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    mashk.Text = Convert.ToString(dta["maSoHoKhau"]);
                    hoten.Text = Convert.ToString(dta["hoTen"]); ;
                    gioitinh.Text = Convert.ToString(dta["gioiTinh"]);
                    quanhe.Text = Convert.ToString(dta["quanHeVoiChuHo"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// ////////////////////////Doan nay chua lam ADO duoc////////////////////////////
        public bool ChuaCoQuanHe(string cmnda, string cmndb)
        {
            conn.Open();
            string sqlStr = "Select * from QuanHe where CMND1 = '" + cmnda + "' and CMND2  = '" + cmndb + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read())
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }
        public void ThietLapQuanHeGiaDinh(ThanhVienShk tv, string sqlStr)
        {           
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    string a = Convert.ToString(dta["CMNDThanhVien"]);
                    string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                    if (tv.QuanHe == "Con Dâu")
                    {
                        if (ChuaCoQuanHe(a, tv.CmndThanhVien) && ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Con Trai" || b == "Con Gái"))
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Chị Dâu", "Em Rể");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Em Rể", "Chị Dâu");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }

                            else if (b == "Vợ")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Me Chồng");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ Chồng", "Con Dâu");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Cháu")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Mự", "Cháu");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Cháu", "Mự");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }

                        }
                    }
                    else if (tv.QuanHe == "Cháu Trai" || tv.QuanHe == "Cháu Gái")
                    {
                        if (ChuaCoQuanHe(a, tv.CmndThanhVien) && ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", tv.QuanHe);
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Con Gái")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Dì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Dì", tv.QuanHe);
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Vợ")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", tv.QuanHe);
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Con Dâu")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Mự");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mự", tv.QuanHe);
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Cháu Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Cháu Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em ", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                        }
                    }
                    else if (tv.QuanHe == "Con Trai")
                    {
                        if (ChuaCoQuanHe(a, tv.CmndThanhVien) && ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Bố"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Ông");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Ông", "Cháu Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Mẹ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Em Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Gì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Gì", "Cháu Trai");
                                XuLy1(sqlStr1);
                                XuLy1(sqlStr2);
                            }
                            else if ((b == "Vợ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Trai", "Mẹ");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ", "Con Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Trai", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Con Gái"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Trai", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em Trai");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Con Dâu")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Rể", "Chị Dâu");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Dâu", "Em Rể");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                        }
                    }
                    else if (tv.QuanHe == "Con Gái")
                    {
                        if (ChuaCoQuanHe(a, tv.CmndThanhVien) && ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Bố"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Ông");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Ông", "Cháu Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Mẹ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Em Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Gì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Gì", "Cháu Gái");
                                XuLy1(sqlStr1);
                                XuLy1(sqlStr2);
                            }
                            else if ((b == "Vợ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Gái", "Mẹ");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ", "Con Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Gái", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if ((b == "Con Gái"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Gái", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em Gái");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Con Dâu")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Rể", "Chị Dâu");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Dâu", "Em Rể");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                        }
                    }
                    else if (tv.QuanHe == "Vợ")
                    {
                        if (ChuaCoQuanHe(a, tv.CmndThanhVien) && ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if (b == "Bố")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bố Chồng", "Con Dâu");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Mẹ")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Mẹ Chồng");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ Chồng", "Con Dâu");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai" || b == "Em Gái" || b == "Chị Gái" || b == "Em Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Chị Dâu", "Em Rể");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Em Rể", "Chị Dâu");
                                XuLy(sqlStr1);
                                XuLy(sqlStr2);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// /////////////////////////////////////////////////////////////////////////////
    }

} 

