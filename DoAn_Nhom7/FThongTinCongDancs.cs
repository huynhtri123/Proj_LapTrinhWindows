using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class FThongTinCongDancs : Form
    {
        public string cmnd { get; set; }
        public string cmndbo { get; set; }
        public string cmndme { get; set; }
        public string noidk { get; set; }
        public string ngaydk { get; set; }

        DBConnection db = new DBConnection();
        public FThongTinCongDancs()
        {
            InitializeComponent();
            /*db.LapDayThongTinKhaiSinhCon(cmnd, lblCCCD, lblHoTen, lblNamSinh, lblDanToc, lblQuocTich, lblQueQuan, lblNoiSinh, lblNoiKhaiSinh);
            db.LapDayThongTinKhaiSinh(cmndme, lblCCCDNguoiKhaiSinh, lblHoTenNguoiKhaiSinh, lblHoTenMe, lblNamSinhMe, lblDanTocMe, lblQuocTichMe, lblQueQuanMe);
            db.LapDayThongTinKhaiSinh(cmndbo, lblCCCDNguoiKhaiSinh, lblHoTenNguoiKhaiSinh, lblHoTenBo, lblNamSinhBo, lblDanTocBo, lblQuocTichBo, lblQueQuanBo);
            lblNoiKhaiSinh.Text = noidk;
            lblNgayDangKy.Text = ngaydk;*/
        }

        private void FThongTinCongDancs_Load(object sender, EventArgs e)

        {
            db.LapDayThongTinKhaiSinhCon(cmnd,lblCCCD, lblHoTen, lblNamSinh, lblDanToc, lblQuocTich, lblQueQuan,lblNoiSinh,lblNoiKhaiSinh);
            db.LapDayThongTinKhaiSinh(cmndme,lblHoTenNguoiKhaiSinh, lblCCCDNguoiKhaiSinh,lblHoTenNguoiKhaiSinh, lblHoTenMe, lblNamSinhMe, lblDanTocMe, lblQuocTichMe, lblQueQuanMe);
            db.LapDayThongTinKhaiSinh(cmndbo, lblHoTenNguoiKhaiSinh, lblCCCDNguoiKhaiSinh, lblHoTenNguoiKhaiSinh, lblHoTenBo, lblNamSinhBo, lblDanTocBo, lblQuocTichBo, lblQueQuanBo);
            lblNoiKhaiSinh.Text = noidk;
            lblNgayDangKy.Text = ngaydk;
            lblKyTen.Text = lblHoTenBo.Text;
        }

        private void FThongTinCongDancs_Scroll(object sender, ScrollEventArgs e)
        {
        }
    }
}
