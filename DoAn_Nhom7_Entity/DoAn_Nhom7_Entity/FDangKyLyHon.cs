using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class FDangKyLyHon : Form
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public FDangKyLyHon()
        {
            InitializeComponent();
        }

        private void FDangKyLyHon_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ThoaDieuKienLyHon(txtCMNDA.Text, txtCMNDB.Text))
            {
                ThucHienLyHon();
            }
            else
                MessageBox.Show("Có người đang ở tình trạng độc thân");
        }
        public bool ThoaDieuKienLyHon(string cmndNam, string cmndNu)
        {
            if (KiemTraHonNhan(cmndNam) == false && KiemTraHonNhan(cmndNu) == false)
                return true;
            else return false;
        }
        public bool KiemTraHonNhan(string cmnd)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                if (congDan.tinhTrangHonNhan == "Doc Than")
                    return true;
            }
            return false;
        }
        public void ThucHienLyHon()
        {
            CongDan A = new CongDan()
            {
                cmnd = txtCMNDA.Text
            };
            CongDan B = new CongDan()
            {
                cmnd = txtCMNDB.Text
            };
            CapNhatLyHon(A);
            CapNhatLyHon(B);
            string mashk = TimMaSHK(txtCMNDA.Text);
            string CMNDChuHo = TimChuHoSHK(mashk);
            string quanhe;
            if (CMNDChuHo == txtCMNDA.Text)
                quanhe = "Vo";
            else
                quanhe = "Con Dau";

            ThanhVienSoHoKhau tv = new ThanhVienSoHoKhau()
            {
                maSoHoKhau = mashk,
                CMNDChuHo = CMNDChuHo,
                CMNDThanhVien = txtCMNDB.Text,
                quanHeVoiChuHo = quanhe
            };
            Xoa(B);
            CapNhatQuanHeLyHon(A, B);
        }
        public void CapNhatLyHon(CongDan A)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == A.cmnd);
            if (congDan != null)
            {
                congDan.tinhTrangHonNhan = "Doc Than";
                db.SaveChanges();
            }
            else MessageBox.Show("That bai");
        }
        public string TimMaSHK(string cmnd)
        {
            var tv = db.ThanhVienSoHoKhaus.FirstOrDefault(p => p.CMNDChuHo == cmnd || p.CMNDThanhVien == cmnd);
            if (tv != null)
            {
                return tv.maSoHoKhau;
            }
            return null;
        }
        public string TimChuHoSHK(string mashk)
        {
            var chuHo = db.SoHoKhaus.Where(s => s.maSoHoKhau == mashk).Select(s => s.CMNDChuHo).FirstOrDefault();
            return chuHo;
        }
        public void Xoa(CongDan cd)
        {
            string mashk = TimMaSHK(cd.cmnd);

            var thanhVien = db.ThanhVienSoHoKhaus.FirstOrDefault(t => t.CMNDThanhVien == cd.cmnd);
            if (thanhVien != null)
            {
                db.ThanhVienSoHoKhaus.Remove(thanhVien);
                db.SaveChanges();
                MessageBox.Show("Xoa thanh vien ra khoi so ho khau thanh cong");
            }

            var quanHe = db.QuanHes.FirstOrDefault(q => q.CMND1 == cd.cmnd || q.CMND2 == cd.cmnd);
            if (quanHe != null)
            {
                db.QuanHes.Remove(quanHe);
                db.SaveChanges();
                MessageBox.Show("Xoa moi quan he thanh cong");
            }

            var tv = db.ThanhVienSoHoKhaus.FirstOrDefault(p=>p.CMNDChuHo == cd.cmnd);
            if (tv != null)
            {
                db.ThanhVienSoHoKhaus.Remove(tv);
                db.SaveChanges();
                MessageBox.Show("Xoa thanh vien thanh cong");
            }

            var shk = db.SoHoKhaus.FirstOrDefault(p=>p.CMNDChuHo == cd.cmnd);
            if (shk != null)
            {
                db.SoHoKhaus.Remove(shk);
                db.SaveChanges();
                MessageBox.Show("Xoa so ho khau thanh cong");
            }
        }
        public void CapNhatQuanHeLyHon(CongDan a, CongDan b)
        {
            var quanHe = db.QuanHes.FirstOrDefault(q => q.CMND1 == a.cmnd && q.CMND2 == b.cmnd);
            if (quanHe != null)
            {
                db.QuanHes.Remove(quanHe);
                db.SaveChanges();
                MessageBox.Show("Cap nhat moi quan he ly hon thanh cong");
            }
        }

        private void txtCMNDA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LapDayThongTin_LyHon(txtCMNDA.Text, txtTenA, txtNamSinhA, txtCuTruA);
                txtCMNDB.Text = CMNDVoChong(txtCMNDA.Text);
                if (txtCMNDB.Text != "")
                    LapDayThongTin_LyHon(txtCMNDB.Text, txtTenB, txtNamSinhB, txtCuTruB);
                else
                    MessageBox.Show("Không tìm thấy vợ");
            }
        }
        public void LapDayThongTin_LyHon(string cmnd, TextBox hoTen, TextBox ngaySinh, TextBox thuongTru)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                hoTen.Text = congDan.hoTen;
                ngaySinh.Text = congDan.ngayThangNamSinh;
                thuongTru.Text = congDan.noiThuongTru;
            }
        }
        public string CMNDVoChong(string cmnd)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                string a = congDan.tinhTrangHonNhan;
                if (a != "Doc Than")
                    a = a.Substring(32);
                else
                    a = "";
                return a;
            }
            return "";
        }
    }
}