using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_Nhom7
{

    public partial class UCKhaiTu : UserControl

    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cdDao = new CongDanDAO();
        ThueDAO thueDao = new ThueDAO();
        KhaiTuDAO ktDao = new KhaiTuDAO();
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        public UCKhaiTu()
        {
            InitializeComponent();
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            if (cbToiDongY.Checked)
            {
                Thue thue = new Thue(txtCCCD.Text);
                thueDao.XoaDoiTuong(thue);
                string sqlStr = string.Format("Select * from SoHoKhau where CMNDChuHo = '"+txtCCCD.Text+"'");
                string sqlStr1 = string.Format("Select * from ThanhVienSoHoKhau where CMNDChuHo ='"+txtCCCD.Text+"'");
                string maSoHoKhau , CMND="", maKhuVuc, xaPhuong, quanHuyen,tinhThanhPho, diaChi, ngayLap;
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr1, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        CMND = Convert.ToString(dta["CMNDThanhVien"]);
                        break;
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
                        quanHuyen = Convert.ToString(dta["quanHuyen"]); ;
                        tinhThanhPho = Convert.ToString(dta["tinhTP"]);
                        diaChi = Convert.ToString(dta["diaChi"]);
                        ngayLap = Convert.ToString(dta["ngayLap"]);
                        if (CMND != "")
                        {
                            SoHoKhau hk = new SoHoKhau(maSoHoKhau, CMND, maKhuVuc, xaPhuong, quanHuyen, tinhThanhPho, diaChi, ngayLap);
                            hkdao.SuaSoHoKhau(hk);
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

                CongDan cd = new CongDan(txtCCCD.Text);
                cdDao.Xoa(cd);
            }
            else
                MessageBox.Show("Vui long xac nhan!");
        }
        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            ktDao.KhaiTu_KeyDown(txtCCCD, txtTen, txtNgaySinh, txtHonNhan, txtThuongTru, txtGioiTinh, txtDanToc, txtQuocTich, txtQueQuan, txtNgheNghiep);
        }

        private void UCKhaiTu_Load(object sender, EventArgs e)
        {

        }
    }
}
