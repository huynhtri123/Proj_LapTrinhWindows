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
using static System.Net.Mime.MediaTypeNames;

namespace DoAn_Nhom7
{

    public partial class UCKhaiTu : UserControl

    {
        CongDanDAO cdDao = new CongDanDAO();
        ThueDAO thueDao = new ThueDAO();
        KhaiTuDAO ktDao = new KhaiTuDAO();
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        KhaiSinhDAO ksdao = new KhaiSinhDAO();
        public UCKhaiTu()
        {
            InitializeComponent();
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            string cmndbandau=txtCCCD.Text;
            string mashk = ksdao.TimMaSHK(cmndbandau);
            string cccdchuho = ksdao.TimChuHoSHK(mashk);
            if (cbToiDongY.Checked)
            {
                Thue thue = new Thue(txtCCCD.Text);
                thueDao.XoaDoiTuong(thue);
                string maSoHoKhau="" , CMND="", maKhuVuc="", xaPhuong="", quanHuyen="",tinhThanhPho="",diaChi = "", ngayLap = "";
                if (cccdchuho == cmndbandau)
                {
                    FChuyenChuHo chuho = new FChuyenChuHo();
                    chuho.cmnd = txtCCCD;
                    chuho.ShowDialog();
                    string[] words = txtCCCD.Text.Split(' ');
                    CMND = words[words.Length - 1];
                }
                ktDao.CungCapKhaiTu( cmndbandau, ref maSoHoKhau, ref maKhuVuc, ref xaPhuong, ref quanHuyen, ref tinhThanhPho, ref diaChi, ref ngayLap);
                if (CMND != "")
                {
                    SoHoKhau hk = new SoHoKhau(maSoHoKhau, CMND, maKhuVuc, xaPhuong, quanHuyen, tinhThanhPho, diaChi, ngayLap);
                    hkdao.SuaSoHoKhau(hk);
                }
                CongDan cd = new CongDan(cmndbandau);
                cdDao.Xoa(cd);
            }
            else
                MessageBox.Show("Vui lòng xác nhận!");
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
