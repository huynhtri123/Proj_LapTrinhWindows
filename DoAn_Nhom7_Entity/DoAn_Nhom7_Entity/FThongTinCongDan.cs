using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class FThongTinCongDan : Form
    {
        public string cmnd { get; set; }
        public string cmndbo { get; set; }
        public string cmndme { get; set; }
        public string noidk { get; set; }
        public string ngaydk { get; set; }

        QuanLiCongDanEntities db = new QuanLiCongDanEntities();

        public FThongTinCongDan()
        {
            InitializeComponent();
        }
        //public string TimMaSHK(string cmnd)
        //{
        //        var soHoKhau = db.SoHoKhaus.SingleOrDefault(shk => shk.CMNDChuHo == cmnd);
        //        if (soHoKhau != null)
        //            return soHoKhau.maSoHoKhau;
        //        else
        //            return null;            
        //}
        //public void LapDayThongTinKhaiSinhBoMe(string cmnd, Label a1, Label a2, Label a3, Label a4, Label a5)
        //{
        //    var congDan = db.CongDans.SingleOrDefault(cd => cd.cmnd == cmnd);
        //    if (congDan != null)
        //    {
        //        a1.Text = congDan.hoTen;
        //        a2.Text = congDan.ngayThangNamSinh;
        //        a3.Text = congDan.danToc;
        //        a4.Text = congDan.queQuan;
        //        a5.Text = congDan.noiThuongTru;
        //    }
        //}
        //public string TimCMNDBo(string maSHK)
        //{
        //    var query = from cd in db.CongDans
        //                join shk in db.SoHoKhaus on cd.cmnd equals shk.CMNDChuHo
        //                where shk.maSoHoKhau == maSHK
        //                select cd.cmnd;

        //    return query.FirstOrDefault();
        //}
        private void FThongTinCongDan_Load(object sender, EventArgs e)
        {
            LapDayThongTinKhaiSinhCon(cmnd, lblCCCD, lblHoTen, lblNamSinh, lblDanToc, lblQuocTich, lblQueQuan, lblNoiSinh, lblNoiKhaiSinh);
            LapDayThongTinKhaiSinh(cmndme, lblHoTenNguoiKhaiSinh, lblCCCDNguoiKhaiSinh, lblHoTenNguoiKhaiSinh, lblHoTenMe, lblNamSinhMe, lblDanTocMe, lblQuocTichMe, lblQueQuanMe);
            LapDayThongTinKhaiSinh(cmndbo, lblHoTenNguoiKhaiSinh, lblCCCDNguoiKhaiSinh, lblHoTenNguoiKhaiSinh, lblHoTenBo, lblNamSinhBo, lblDanTocBo, lblQuocTichBo, lblQueQuanBo);
            lblNoiKhaiSinh.Text = noidk;
            lblNgayDangKy.Text = ngaydk;
        }
        public void LapDayThongTinKhaiSinhCon(string cmnd, Label a, Label a1, Label a2, Label a3, Label a4, Label a5, Label a6, Label a7)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                a.Text = congDan.cmnd;
                a1.Text = congDan.hoTen;
                a2.Text = congDan.ngayThangNamSinh;
                a3.Text = congDan.danToc;
                a4.Text = congDan.quocTich;
                a5.Text = congDan.queQuan;
                a6.Text = congDan.noiDangKiKhaiSinh;
                a7.Text = congDan.queQuan;
            }
        }
        public void LapDayThongTinKhaiSinh(string cmnd, Label a, Label b, Label a1, Label s, Label a2, Label a3, Label a4, Label a5)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                a.Text = congDan.cmnd;
                b.Text = congDan.hoTen;
                a1.Text = congDan.hoTen;
                a2.Text = congDan.ngayThangNamSinh;
                s.Text = congDan.hoTen;
                a3.Text = congDan.danToc;
                a4.Text = congDan.quocTich;
                a5.Text = congDan.queQuan;
            }
        }

    }
}
