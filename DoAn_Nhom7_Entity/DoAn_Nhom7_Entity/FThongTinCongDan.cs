using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class FThongTinCongDan : Form
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public string cmnd;
        public FThongTinCongDan(string Cmnd)
        {
            InitializeComponent();
            this.cmnd = TimMaSHK(Cmnd);
            MessageBox.Show(Cmnd);
        }
        public string TimMaSHK(string cmnd)
        {
                var soHoKhau = db.SoHoKhaus.SingleOrDefault(shk => shk.CMNDChuHo == cmnd);
                if (soHoKhau != null)
                    return soHoKhau.maSoHoKhau;
                else
                    return null;            
        }
        public void LapDayThongTinKhaiSinhBoMe(string cmnd, Label a1, Label a2, Label a3, Label a4, Label a5)
        {
            var congDan = db.CongDans.SingleOrDefault(cd => cd.cmnd == cmnd);
            if (congDan != null)
            {
                a1.Text = congDan.hoTen;
                a2.Text = congDan.ngayThangNamSinh;
                a3.Text = congDan.danToc;
                a4.Text = congDan.queQuan;
                a5.Text = congDan.noiThuongTru;
            }
        }
        public string TimCMNDBo(string maSHK)
        {
            var query = from cd in db.CongDans
                        join shk in db.SoHoKhaus on cd.cmnd equals shk.CMNDChuHo
                        where shk.maSoHoKhau == maSHK
                        select cd.cmnd;

            return query.FirstOrDefault();
        }
        private void FThongTinCongDan_Load(object sender, EventArgs e)
        {
            string cmndBo = TimCMNDBo(cmnd);
            LapDayThongTinKhaiSinhBoMe(cmndBo, lblHoTenBo, lblNamSinhBo, lblDanTocBo, lblQuocTichBo, lblQueQuanBo);
            LapDayThongTinKhaiSinhBoMe("2", lblHoTenMe, lblNamSinhMe, lblDanTocMe, lblQuocTichMe, lblQueQuanMe);
        }
    }
}
