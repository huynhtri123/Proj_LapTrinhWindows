using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class FDangKiKetHon : Form
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public FDangKiKetHon()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ThoaDieuKienKetHon(txtGiayToTuyThanNam.Text, txtGiayToTuyThanNu.Text))
            {
                ThucHienKetHon();
            }
            else
                MessageBox.Show("Co nguoi chua du dieu kien ket hon (1.chua du tuoi; 2.da ket hon)");
        }
        public void ThucHienKetHon()
        {
            CongDan A = new CongDan()
            {
                cmnd = txtGiayToTuyThanNam.Text,
                hoTen = txtHoTenNam.Text
            };
            CongDan B = new CongDan()
            {
                cmnd = txtGiayToTuyThanNu.Text,
                hoTen = txtHoTenNu.Text
            };
            string maShk = timMaSHK(txtGiayToTuyThanNam.Text);
            ThanhVienSoHoKhau tv = new ThanhVienSoHoKhau()
            {
                maSoHoKhau = maShk,
                CMNDChuHo = txtGiayToTuyThanNam.Text,
                CMNDThanhVien = txtGiayToTuyThanNu.Text,
                quanHeVoiChuHo = "Vo"
            };
            ThietLapMoiQuanHeVoChong(tv);
            CapNhatKetHon(A, B);
            ThemThanhVien(tv);
        }
        public string timMaSHK(string cmnd)
        {
            var shk = db.SoHoKhaus.FirstOrDefault(p => p.CMNDChuHo == cmnd);
            if (shk != null)
            {
                return shk.maSoHoKhau;
            }
            return null;
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienSoHoKhau tv)
        {
            //var quanhe = db.QuanHes.FirstOrDefault(qh => qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien);
            //if (quanhe != null)
            //{
            //    quanhe.quanHeVoiCMND1 = "Vo";
            //    quanhe.quanHeVoiCMND2 = "Chong";
            //    db.SaveChanges();
            //    MessageBox.Show("Thiet lap moi quan he vo chong thanh cong");
            //}
            //MessageBox.Show("Thiet lap moi quan he vo chong THAT BAI");
            QuanHe quanhe = new QuanHe()
            {
                CMND1 = tv.CMNDChuHo,
                CMND2 = tv.CMNDThanhVien,
                quanHeVoiCMND1 = "Vo",
                quanHeVoiCMND2 = "Chong",
            };
            db.QuanHes.Add(quanhe);
            db.SaveChanges();
            MessageBox.Show("Thiet lap moi quan he vo chong thanh cong");
        }
        public void ThietLapMoiQuanHeBoCon(ThanhVienSoHoKhau tv)
        {
            var quanHe = new QuanHe 
            {
                CMND1 = tv.CMNDChuHo,
                CMND2 = tv.CMNDThanhVien,
                quanHeVoiCMND1 = "Con",
                quanHeVoiCMND2 = "Bo"
            };
            db.QuanHes.Add(quanHe); 
            db.SaveChanges(); 
            MessageBox.Show("Thiet lap moi quan he bo con thanh cong");
        }
        public void CapNhatKetHon(CongDan A, CongDan B)
        {
            var nam = db.CongDans.FirstOrDefault(p => p.cmnd == A.cmnd);
            var nu = db.CongDans.FirstOrDefault(p => p.cmnd == B.cmnd);
            if (nam != null && nu != null)
            {
                nam.tinhTrangHonNhan = "Da Ket Hon Voi Nguoi Co CMND La " + nu.cmnd;
                nu.tinhTrangHonNhan = "Da Ket Hon Voi Nguoi Co CMND La " + nam.cmnd;
                db.SaveChanges();
            }
            else MessageBox.Show("Cap nhat ket hon khong thanh cong");
        }
        public void ThemThanhVien(ThanhVienSoHoKhau tv)
        {
            if (tv.quanHeVoiChuHo == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else
                ThietLapMoiQuanHeVoChong(tv);

            var quanHe = db.QuanHes.Where(qh => qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien).FirstOrDefault();
            
            if (quanHe != null)
            {
                var thanhVien = new ThanhVienSoHoKhau
                {
                    maSoHoKhau = tv.maSoHoKhau,
                    CMNDChuHo = tv.CMNDChuHo,
                    CMNDThanhVien = tv.CMNDThanhVien,
                    quanHeVoiChuHo = quanHe.quanHeVoiCMND1
                };
                db.ThanhVienSoHoKhaus.Add(thanhVien);
                db.SaveChanges();              
                MessageBox.Show("Them thanh vien vao so ho khau THANH CONG");
            }
            else MessageBox.Show("Them thanh vien vao so ho khau THAT BAI");
        }
        public bool ThoaDieuKienKetHon(string cmndNam, string cmndNu)
        {
            if (Tuoi(cmndNam) >= 20 && Tuoi(cmndNu) >= 18 && KiemTraHonNhan(cmndNam) == true && KiemTraHonNhan(cmndNu) == true)
                return true;
            else return false;
        }
        public int Tuoi(string cmnd)
        {
            var congDan = db.CongDans.FirstOrDefault(cd => cd.cmnd == cmnd);
            if (congDan == null)
                return 0;
            DateTime ngaySinh;
            //chuyen ngay sinh sang kieu Datetime
            if (!DateTime.TryParseExact(congDan.ngayThangNamSinh, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh)
                && !DateTime.TryParseExact(congDan.ngayThangNamSinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                return 0;

            var tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) //neu chua den ngay sinh nhat thi giam bot 1 tuoi
                tuoi--;

            return tuoi;
        }
        public bool KiemTraHonNhan(string cmnd)
        {
            var congDan = db.CongDans.FirstOrDefault(cd => cd.cmnd == cmnd);
            if (congDan != null)
                if (congDan.tinhTrangHonNhan == "Doc Than")
                    return true;
            return false;
        }

        private void txtGiayToTuyThanNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LapDayThongTin(txtGiayToTuyThanNam, txtHoTenNam, txtNgaySinhNam, txtDanTocNam, txtQueQuanNam, txtNoiCuTruNam);
            }
        }
        public void LapDayThongTin(TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox danToc, TextBox queQuan, TextBox thuongTru)
        {
            var congDan = db.CongDans.FirstOrDefault(cd => cd.cmnd == cmnd.Text);

            if (congDan != null)
            {
                hoTen.Text = congDan.hoTen;
                ngaySinh.Text = congDan.ngayThangNamSinh.ToString();
                danToc.Text = congDan.danToc;
                queQuan.Text = congDan.queQuan;
                thuongTru.Text = congDan.noiThuongTru;
            }
        }

        private void txtGiayToTuyThanNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LapDayThongTin(txtGiayToTuyThanNu, txtHoTenNu, txtNgaySinhNu, txtDanTocNu, txtQueQuanNu, txtNoiCuTruNu);
            }
        }
    }
}
