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
    public partial class UCSoHoKhau : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCSoHoKhau()
        {
            InitializeComponent();
        }
        public void LayDanhSach()
        {
            var result = from c in db.SoHoKhaus
                         select new
                         {
                             maSoHoKhau = c.maSoHoKhau,
                             CMNDChuHo = c.CMNDChuHo,
                             maKV = c.maKV,
                             xaPhuong = c.xaPhuong,
                             quanHuyen = c.quanHuyen,
                             tinhTP = c.tinhTP,
                             diaChi = c.diaChi,
                             ngayLap = c.ngayLap
                         };
            this.dtgvSoHoKhau.DataSource = result.ToList();
        }
        public void LayDanhSachThanhVien()
        {
            var result = from c in db.ThanhVienSoHoKhaus
                         where c.maSoHoKhau == txtMaSoHoKhau.Text
                         select new
                         {
                             maSoHoKhau = c.maSoHoKhau,
                             CMNDThanhVien = c.CMNDThanhVien,
                             quanHeVoiChuHo = c.quanHeVoiChuHo

                         };
            this.dtgvThanhVienShk.DataSource = result.ToList();
        }
        private void UCSoHoKhau_Load(object sender, EventArgs e)
        {
            LayDanhSach();
            dtgvSoHoKhau.Columns[0].HeaderText = "Mã sổ hộ khẩu";
            dtgvSoHoKhau.Columns[1].HeaderText = "CMND Chủ hộ";
            dtgvSoHoKhau.Columns[2].HeaderText = "Mã khu vực";
            dtgvSoHoKhau.Columns[3].HeaderText = "Xã phường";
            dtgvSoHoKhau.Columns[4].HeaderText = "Quận huyện";
            dtgvSoHoKhau.Columns[5].HeaderText = "Tỉnh thành phố";
            dtgvSoHoKhau.Columns[6].HeaderText = "Địa chỉ";
            dtgvSoHoKhau.Columns[7].HeaderText = "Ngày lập";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LayDanhSachThanhVien();
            dtgvThanhVienShk.Columns[0].HeaderText = "Mã sổ hộ khẩu";
            dtgvThanhVienShk.Columns[1].HeaderText = "CMND thành viên";
            dtgvThanhVienShk.Columns[2].HeaderText = "Quan hệ với chủ hộ";
        }

        private void dtgvSoHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvSoHoKhau.Rows[e.RowIndex];
            txtMaSoHoKhau.Text = row.Cells[0].Value.ToString();
            txtCMND.Text = row.Cells[1].Value.ToString();
            txtMaKhuVuc.Text = row.Cells[2].Value.ToString();
            txtXaPhuong.Text = row.Cells[3].Value.ToString();
            txtQuanHuyen.Text = row.Cells[4].Value.ToString();
            txtTinhThanhPho.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            dtpNgayLap.Text = row.Cells[7].Value.ToString();
        }       
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraSHK(txtCMND.Text))
            {
                SoHoKhau shk = new SoHoKhau()
                {
                    maSoHoKhau = txtMaSoHoKhau.Text,
                    CMNDChuHo = txtCMND.Text,
                    maKV = txtMaKhuVuc.Text,
                    xaPhuong = txtXaPhuong.Text,
                    quanHuyen = txtQuanHuyen.Text,
                    tinhTP = txtTinhThanhPho.Text,
                    diaChi = txtDiaChi.Text,
                    ngayLap = dtpNgayLap.Text
                };
                db.SoHoKhaus.Add(shk);
                db.SaveChanges();
                LayDanhSach();
            }
            else MessageBox.Show("Da co so ho khau");
        }
        public bool KiemTraSHK(string cmnd)
        {
            var soHoKhau = db.SoHoKhaus.FirstOrDefault(shk => shk.CMNDChuHo == cmnd);

            if (soHoKhau != null)
                return false;
            return true;
        }

        private void dtgvThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvThanhVienShk.Rows[e.RowIndex];
            txtCmnd_tv.Text = row.Cells[1].Value.ToString();

            string cmnd = txtCmnd_tv.Text;
            var query = from cd in db.CongDans
                        join tvshk in db.ThanhVienSoHoKhaus on cd.cmnd equals tvshk.CMNDThanhVien
                        join shk in db.SoHoKhaus on new { tvshk.maSoHoKhau, tvshk.CMNDChuHo } equals new { shk.maSoHoKhau, shk.CMNDChuHo }
                        where cd.cmnd == cmnd
                        select new
                        {
                            shk.maSoHoKhau,
                            cd.hoTen,
                            cd.gioiTinh,
                            tvshk.quanHeVoiChuHo
                        };
            var result = query.FirstOrDefault();
            if (result != null)
            {
                txtMaShk_tv.Text = result.maSoHoKhau;
                txtHoTen_tv.Text = result.hoTen;
                txtGioiTinh_tv.Text = result.gioiTinh;
                txtQuanHe.Text = result.quanHeVoiChuHo;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SoHoKhau shk = db.SoHoKhaus.Where(p => p.maSoHoKhau == txtMaSoHoKhau.Text).SingleOrDefault();
            db.SoHoKhaus.Remove(shk);
            db.SaveChanges();
            LayDanhSach();
            MessageBox.Show("Thanh cong");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SoHoKhau shk = db.SoHoKhaus.Where(p => p.maSoHoKhau == txtMaSoHoKhau.Text).SingleOrDefault();
            shk.maKV = txtMaKhuVuc.Text;
            shk.xaPhuong = txtXaPhuong.Text;
            shk.quanHuyen = txtQuanHuyen.Text;
            shk.tinhTP = txtTinhThanhPho.Text;
            shk.diaChi = txtDiaChi.Text;
            shk.ngayLap = dtpNgayLap.Text;

            db.SaveChanges();
            LayDanhSach();
            MessageBox.Show("Thanh cong");
        }
        public bool KiemTraTVSHK(string cmnd)
        {
            var shk = db.ThanhVienSoHoKhaus.FirstOrDefault(p => p.CMNDThanhVien == cmnd);
            if (shk != null)
                return false;
            return true;
        }

        private void btnThemTv_Click(object sender, EventArgs e)
        {
            ThanhVienSoHoKhau tv = new ThanhVienSoHoKhau()
            {
                maSoHoKhau = txtMaShk_tv.Text,
                CMNDChuHo = txtCMND.Text,
                CMNDThanhVien = txtCmnd_tv.Text,
                quanHeVoiChuHo = txtQuanHe.Text
            };
            if (KiemTraTVSHK(tv.CMNDThanhVien))
            {
                ThemThanhVien(tv);
                LayDanhSachThanhVien();
            }
            else MessageBox.Show("Da co so ho khau");
        }
        public void ThemThanhVien(ThanhVienSoHoKhau tv)
        {
            if (tv.quanHeVoiChuHo == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else
                ThietLapMoiQuanHeVoChong(tv);

            var quanHe = db.QuanHes.FirstOrDefault(qh => qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien);
            if (quanHe == null)
            {
                MessageBox.Show("Không tìm thấy quan hệ giữa hai thành viên");
                return;
            }
            db.ThanhVienSoHoKhaus.Add(tv);
            db.SaveChanges();
            MessageBox.Show("Thành công");
        }
        public void ThietLapQuanHe(ThanhVienSoHoKhau tv)
        {
            if (tv.quanHeVoiChuHo == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else
                ThietLapMoiQuanHeVoChong(tv);
        }
        public void ThietLapMoiQuanHeBoCon(ThanhVienSoHoKhau tv)
        {
            var quanHe = new QuanHe()
            {
                CMND1 = tv.CMNDChuHo,
                CMND2 = tv.CMNDThanhVien,
                quanHeVoiCMND1 = "Con",
                quanHeVoiCMND2 = "Bo"
            };
            db.QuanHes.Add(quanHe);
            db.SaveChanges();
            MessageBox.Show("thanh cong");
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienSoHoKhau tv)
        {
            var quanHe = db.QuanHes.FirstOrDefault(qh => qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien);
            if (quanHe != null)
            {
                quanHe.quanHeVoiCMND1 = "Vo";
                quanHe.quanHeVoiCMND2 = "Chong";
                db.SaveChanges();
                MessageBox.Show("thanh cong");
            }
            else
            {
                MessageBox.Show("Không tìm thấy quan hệ gia đình");
            }
        }
        public void SuaThanhVien(ThanhVienSoHoKhau tv, string qh1)
        {
            string qh2 = "";
            if (qh1 == "Con")
                qh2 = "Bo";
            else
                qh2 = "Chong";

            var quanHe = db.QuanHes.FirstOrDefault(qh => qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien);
            if (quanHe != null)
            {
                quanHe.quanHeVoiCMND1 = qh1;
                quanHe.quanHeVoiCMND2 = qh2;

                tv.quanHeVoiChuHo = quanHe.quanHeVoiCMND1;

                db.SaveChanges();
                LayDanhSachThanhVien();
                MessageBox.Show("Thanh cong");
            }
            else MessageBox.Show("Khong tim thay quan he!");
        }
        private void btnSuaTv_Click(object sender, EventArgs e)
        {
            ThanhVienSoHoKhau tv = db.ThanhVienSoHoKhaus.Where(p => p.maSoHoKhau == txtMaShk_tv.Text && p.CMNDChuHo == txtCMND.Text).SingleOrDefault();
            if (tv != null)
            {
                SuaThanhVien(tv, txtQuanHe.Text);
            }
            else MessageBox.Show("Khong tim thay so ho khau nay!");
        }

        private void btnXoaTv_Click(object sender, EventArgs e)
        {
            ThanhVienSoHoKhau tv = db.ThanhVienSoHoKhaus.Where(p => p.CMNDThanhVien == txtCmnd_tv.Text).SingleOrDefault();
            if (tv != null)
            {
                db.ThanhVienSoHoKhaus.Remove(tv);
                db.SaveChanges();
                MessageBox.Show("Thanh cong");
                LayDanhSachThanhVien();
            }
            else MessageBox.Show("Khong tim thay so ho khau!");
        }
        public void LapTVSoHoKhau(TextBox txtCMND, TextBox txtCmnd_tv, TextBox txtMaShk_tv, TextBox txtMaSoHoKhau, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv, TextBox txtQuanHe)
        {
            var query = from qh in db.QuanHes
                        join cd in db.CongDans on qh.CMND2 equals cd.cmnd
                        where qh.CMND1 == txtCMND.Text && qh.CMND2 == txtCmnd_tv.Text
                        select new
                        {
                            cd.hoTen,
                            cd.gioiTinh,
                            qh.quanHeVoiCMND1
                        };

            var result = query.FirstOrDefault();

            if (result != null)
            {
                txtMaShk_tv.Text = txtMaSoHoKhau.Text;
                txtHoTen_tv.Text = result.hoTen;
                txtGioiTinh_tv.Text = result.gioiTinh;
                txtQuanHe.Text = result.quanHeVoiCMND1;
            }
            else
            {
                txtMaShk_tv.Text = "";
                txtHoTen_tv.Text = "";
                txtGioiTinh_tv.Text = "";
                txtQuanHe.Text = "";
            }
        }
        public void LapThongTin(TextBox txtCmnd_tv, TextBox txtHoTen_tv, TextBox txtGioiTinh_tv)
        {
            var query = from cd in db.CongDans
                        where cd.cmnd == txtCmnd_tv.Text
                        select new
                        {
                            cd.hoTen,
                            cd.gioiTinh
                        };
            var result = query.FirstOrDefault();
            if (result != null)
            {
                txtHoTen_tv.Text = result.hoTen;
                txtGioiTinh_tv.Text = result.gioiTinh;
            }
            else
            {
                txtHoTen_tv.Text = "";
                txtGioiTinh_tv.Text = "";
            }           
        }
        private void txtCmnd_tv_KeyDown(object sender, KeyEventArgs e)
        {
            LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
            if (txtHoTen_tv.Text == "")
                LapThongTin(txtCmnd_tv, txtHoTen_tv, txtGioiTinh_tv);
        }
        public void LapSoHoKhau(TextBox txtMaSoHoKhau, TextBox txtCMND, TextBox txtMaKhuVuc, TextBox txtXaPhuong, TextBox txtQuanHuyen, TextBox txtTinhThanhPho, TextBox txtDiaChi, DateTimePicker dtpNgayLap)
        {
            var query = from shk in db.SoHoKhaus
                        where shk.maSoHoKhau == txtMaSoHoKhau.Text
                        select new
                        {
                            shk.maSoHoKhau,
                            shk.CMNDChuHo,
                            shk.maKV,
                            shk.xaPhuong,
                            shk.quanHuyen,
                            shk.tinhTP,
                            shk.diaChi,
                            shk.ngayLap
                        };
            var result = query.FirstOrDefault();
            if (result != null)
            {
                txtCMND.Text = result.CMNDChuHo;
                txtMaKhuVuc.Text = result.maKV;
                txtXaPhuong.Text = result.xaPhuong;
                txtQuanHuyen.Text = result.quanHuyen;
                txtTinhThanhPho.Text = result.tinhTP;
                txtDiaChi.Text = result.diaChi;
                dtpNgayLap.Text = result.ngayLap;
            }
        }

        private void txtMaSoHoKhau_KeyDown(object sender, KeyEventArgs e)
        {
            LapSoHoKhau(txtMaSoHoKhau, txtCMND, txtMaKhuVuc, txtXaPhuong, txtQuanHuyen, txtTinhThanhPho, txtDiaChi, dtpNgayLap);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            var shkList = db.ThanhVienSoHoKhaus.Where(t => t.CMNDThanhVien == txtTraCuu.Text).Select(t => t.maSoHoKhau).Union(db.SoHoKhaus.Where(s => s.CMNDChuHo == txtTraCuu.Text).Select(s => s.maSoHoKhau));
            try
            {
                string maSoHoKhau = shkList.FirstOrDefault();
                if (!string.IsNullOrEmpty(maSoHoKhau))
                {
                    txtMaSoHoKhau.Text = maSoHoKhau;
                    txtCmnd_tv.Text = txtTraCuu.Text;
                    LapSoHoKhau(txtMaSoHoKhau, txtCMND, txtMaKhuVuc, txtXaPhuong, txtQuanHuyen, txtTinhThanhPho, txtDiaChi, dtpNgayLap);
                    LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
                    if (txtHoTen_tv.Text == "")
                        txtCmnd_tv.Text = "";
                    foreach (DataGridViewRow row in dtgvSoHoKhau.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.ToString() == txtCMND.Text)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                    LayDanhSachThanhVien();
                    foreach (DataGridViewRow row in dtgvThanhVienShk.Rows)
                    {
                        object value = row.Cells[1].Value;
                        if (value != null && value.ToString() == txtCmnd_tv.Text)
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
        }
    }
}
