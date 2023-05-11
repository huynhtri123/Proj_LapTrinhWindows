using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                    /*MessageBox.Show("thanh cong");*/
            
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
                if(cmd.ExecuteNonQuery()>0)
                    MessageBox.Show("thanh cong");

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
        public void LapDayThongTinTamTru(string sqlStr, TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox queQuan, TextBox thuongTru)
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
        public void LapDayThongTinCD(TextBox cmnd, TextBox a, DateTimePicker dt, RadioButton b,RadioButton b1, TextBox d, TextBox f, TextBox g, TextBox j, TextBox k, TextBox x, TextBox y, TextBox z, TextBox i, TextBox t, TextBox n, DateTimePicker m,TextBox p)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text = Convert.ToString(dta["hoTen"]);
                dt.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                if (Convert.ToString(dta["gioiTinh"]) == "nu")
                    b.Checked=true;
                else
                    b1.Checked=true;
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
                m.Text = Convert.ToString(dta["ngayCap"]);
                p.Text = Convert.ToString(dta["QuocTich"]);
            }
            conn.Close();
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
                if (a != "Doc Than")
                    a = a.Substring(32);
                else a = "";
            }
            conn.Close();
            return a;
        }
        public bool KiemTraHonNhan(string sqlStr)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["tinhTrangHonNhan"]);
                if (a == "Doc Than")
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
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
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
        public int SoLuongThanhVien(string cmnd, string sqlStr)
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
        public int TinhTuoi(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int tuoi = 0;
            if (dr.Read())
            {
                tuoi = Convert.ToInt32(dr["Tuoi"].ToString());
                MessageBox.Show("Tinh tuoi thanh cong");
            }
            conn.Close();
            return tuoi;
        }
        public bool ChuaCoQuanHe(string cmnda,string cmndb)
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
        public string GioiTinh(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string gioiTinh="";
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
        public void KhaiSinh_KeyDown(string sqlStr, TextBox cmnd, TextBox ten, TextBox danToc,TextBox quocTich)
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
        public string TimMaSHK(string cmnd, string sqlStr)
        {
            conn.Open();
            //string sqlStr2 = "Select maSoHoKhau From ThanhVienSoHoKhau where CMNDThanhVien= '" + cmnd + "'";
            //string sqlStr = sqlStr1 + " UNION " + sqlStr2;
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
        public string TimChuHoSHK(string mashk, string sqlStr)
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

        public bool KiemTraTaiKhoanTonTai(string input)
        {
            conn.Open();
            string sqlStr = string.Format("SELECT * FROM TaiKhoan WHERE TaiKhoan = '{0}'", input);
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
        public bool KiemTraSHK(string cmnd)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            string sqlStr1 = " SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= '" + cmnd + "'";
            string sqlStr2 = " SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo= '" + cmnd + "'";
            string sqlStr = sqlStr2 + "UNION" + sqlStr1;
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
        public bool KiemTraTVSHK(string cmnd, string sqlStr)
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
        public void ThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e, string sqlStr, DataGridView dtgvThanhVienShk, TextBox cmndTv, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, TextBox quanHe)
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
        public void LapSoHoKhau(string sqlStr, TextBox txtMaSoHoKhau, TextBox txtCMND, TextBox txtMaKhuVuc, TextBox txtXaPhuong, TextBox txtQuanHuyen, TextBox txtTinhThanhPho, TextBox txtDiaChi, DateTimePicker dtpNgayLap)
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
                    dtpNgayLap.Text = Convert.ToString(dta["ngayLap"]);
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
        public void LapTVSoHoKhau(string sqlStr, TextBox txtCMND, TextBox txtCmnd_tv, TextBox txtMaShk_tv, TextBox txtMaSoHoKhau, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv, TextBox txtQuanHe)
        {            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    txtMaShk_tv.Text = txtMaSoHoKhau.Text;
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
        public void TraCuu_Click(object sender, EventArgs e, string sqlStr, string sqlStr_lapShk, string sqlStr_lapTvShk, DataGridView dtgvSoHoKhau, DataGridView dtgvThanhVienShk, TextBox maShk, TextBox cmndTv, TextBox traCuu, TextBox cmnd, TextBox maKv, TextBox xaPhuong, TextBox quanHuyen, TextBox tinhTp, TextBox diaChi, DateTimePicker ngayLap, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, TextBox quanHe)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    maShk.Text = Convert.ToString(dta["maSoHoKhau"]);
                    cmndTv.Text = traCuu.Text;
                    LapSoHoKhau(sqlStr_lapShk, maShk,cmnd,maKv, xaPhuong, quanHuyen, tinhTp, diaChi, ngayLap);
                    LapTVSoHoKhau(sqlStr_lapTvShk, cmnd, cmndTv, maShkTv, maShk, hoTenTv, gioiTinhTv, quanHe);
                    if (hoTenTv.Text == "")
                        cmndTv.Text = "";
                    foreach (DataGridViewRow row in dtgvSoHoKhau.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.ToString() == cmnd.Text)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                    foreach (DataGridViewRow row in dtgvThanhVienShk.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.ToString() == cmndTv.Text)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                }
                else
                    MessageBox.Show("Khong thuoc shk nao");
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
        public void LapDayThongTinKhaiSinh(string cmnd,Label a,Label b, Label a1,Label s, Label a2, Label a3, Label a4, Label a5)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text= Convert.ToString(dta["cmnd"]);
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
        public void LapDayThongTinKhaiSinhCon(string cmnd, Label a, Label a1, Label a2, Label a3, Label a4, Label a5,Label a6,Label a7)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
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
        public string timCMNDBo(string maSHK)
        {
            conn.Open();
            string sqlStr = string.Format("select shk.maSoHoKhau,cd.cmnd, cd.hoten ,cd.gioiTinh,'chu ho' AS QuanHe  FROM CongDan cd INNER JOIN SoHoKhau shk ON cd.cmnd = shk.CMNDChuHo where shk.maSoHoKhau = '" + maSHK + "'");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                string a = Convert.ToString(dta["cd.cmnd"]);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;
        }
            //thue
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
        
    }
}
