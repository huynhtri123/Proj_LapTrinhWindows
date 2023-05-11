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
    public partial class FTrangChu : Form
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public FTrangChu()
        {
            InitializeComponent();
        }

        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    string dv = cmbTimKiem.Text;
            //    switch (dv)
            //    {
            //        case "Can cuoc cong dan":
            //            FCongDan formCCCD = new FCongDan();
            //            formCCCD.Show();
            //            break;
            //        case "Thue":
            //            FThue fThue = new FThue();
            //            fThue.Show();
            //            break;
            //        case "So ho khau":
            //            FSoHoKhau fShk = new FSoHoKhau();
            //            fShk.ShowDialog();
            //            break;
            //        case "Tam tru, tam vang":
            //            FTamTruTamVang fTttv = new FTamTruTamVang();
            //            fTttv.ShowDialog();
            //            break;
            //        case "Thong ke dan so":
            //            FThongKe fTkds = new FThongKe();
            //            fTkds.ShowDialog();
            //            break;
            //        case "Hon nhan va gia dinh":
            //            HonNhanVaGiaDinh fHnvgd = new HonNhanVaGiaDinh();
            //            fHnvgd.ShowDialog();
            //            break;
            //        case "Khai sinh":
            //            FKhaiSinh fKs = new FKhaiSinh();
            //            fKs.Show();
            //            break;
            //        case "Khai tu":
            //            FKhaiTu fKt = new FKhaiTu();
            //            fKt.Show();
            //            break;
            //    }
            //}
        }

        private void btnCCCD_Click(object sender, EventArgs e)
        {
            UCCanCuoc uc = new UCCanCuoc();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            UCThue uc = new UCThue();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnSoHoKhau_Click(object sender, EventArgs e)
        {
            UCSoHoKhau uc = new UCSoHoKhau();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnTamTru_Click(object sender, EventArgs e)
        {
            UCTamTruTamVang uc = new UCTamTruTamVang();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UCThongKeDanSo uc = new UCThongKeDanSo();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnHonNhan_Click(object sender, EventArgs e)
        {
            UCHonNhan uc = new UCHonNhan();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnKhaiTu_Click(object sender, EventArgs e)
        {
            UCKhaiTu uc = new UCKhaiTu();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FDangNhap dn = new FDangNhap();
            dn.ShowDialog();
        }

        private void FTrangChu_Load(object sender, EventArgs e)
        {
            LayDanhSach();
            dGVDanhSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        public void LayDanhSach()
        {
            var result = from c in db.CongDans
                         select new
                         {
                             hoTen = c.hoTen,
                             ngayThangNamSinh =c.ngayThangNamSinh,
                             gioiTinh = c.gioiTinh,
                             cmnd = c.cmnd,
                             danToc = c.danToc,
                             tinhTrangHonNhan = c.tinhTrangHonNhan,
                             noiDangKiKhaiSinh = c.noiDangKiKhaiSinh,
                             queQuan = c.queQuan,
                             noiThuongTru = c.noiThuongTru,
                             trinhDoHocVan = c.trinhDoHocVan,
                             ngheNghiep = c.ngheNghiep,
                             luong = c.luong,
                             soLanKetHon = c.soLanKetHon,
                             tamTru = c.tamTru,
                             noiCapCMND = c.noiCapCMND,
                             ngayCap = c.ngayCap,
                             quocTich = c.quocTich
                         };
            this.dGVDanhSach.DataSource = result.ToList();

            if (rdbDaKetHon.Checked == true)
                TimNguoiDaKetHon();
            else if (rdbChuaKetHon.Checked == true)
                TimNguoiChuaKetHon();
        }
        public void TimNguoiDaKetHon()
        {
            var result = from c in db.CongDans
                         where c.tinhTrangHonNhan != "Doc Than"
                         select new
                         {
                             hoTen = c.hoTen,
                             ngayThangNamSinh = c.ngayThangNamSinh,
                             gioiTinh = c.gioiTinh,
                             cmnd = c.cmnd,
                             danToc = c.danToc,
                             tinhTrangHonNhan = c.tinhTrangHonNhan,
                             noiDangKiKhaiSinh = c.noiDangKiKhaiSinh,
                             queQuan = c.queQuan,
                             noiThuongTru = c.noiThuongTru,
                             trinhDoHocVan = c.trinhDoHocVan,
                             ngheNghiep = c.ngheNghiep,
                             luong = c.luong,
                             soLanKetHon = c.soLanKetHon,
                             tamTru = c.tamTru,
                             noiCapCMND = c.noiCapCMND,
                             ngayCap = c.ngayCap,
                             quocTich = c.quocTich
                         };
            this.dGVDanhSach.DataSource = result.ToList();
        }
        public void TimNguoiChuaKetHon()
        {
            var result = from c in db.CongDans
                         where c.tinhTrangHonNhan == "Doc Than"
                         select new
                         {
                             hoTen = c.hoTen,
                             ngayThangNamSinh = c.ngayThangNamSinh,
                             gioiTinh = c.gioiTinh,
                             cmnd = c.cmnd,
                             danToc = c.danToc,
                             tinhTrangHonNhan = c.tinhTrangHonNhan,
                             noiDangKiKhaiSinh = c.noiDangKiKhaiSinh,
                             queQuan = c.queQuan,
                             noiThuongTru = c.noiThuongTru,
                             trinhDoHocVan = c.trinhDoHocVan,
                             ngheNghiep = c.ngheNghiep,
                             luong = c.luong,
                             soLanKetHon = c.soLanKetHon,
                             tamTru = c.tamTru,
                             noiCapCMND = c.noiCapCMND,
                             ngayCap = c.ngayCap,
                             quocTich = c.quocTich
                         };
            this.dGVDanhSach.DataSource = result.ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            txtCCCD.Text = "";
            KiemTraTamTruTamVang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var result = from c in db.CongDans
                         where c.cmnd == txtCCCD.Text
                         select new
                         {
                             hoTen = c.hoTen,
                             ngayThangNamSinh = c.ngayThangNamSinh,
                             gioiTinh = c.gioiTinh,
                             cmnd = c.cmnd,
                             danToc = c.danToc,
                             tinhTrangHonNhan = c.tinhTrangHonNhan,
                             noiDangKiKhaiSinh = c.noiDangKiKhaiSinh,
                             queQuan = c.queQuan,
                             noiThuongTru = c.noiThuongTru,
                             trinhDoHocVan = c.trinhDoHocVan,
                             ngheNghiep = c.ngheNghiep,
                             luong = c.luong,
                             soLanKetHon = c.soLanKetHon,
                             tamTru = c.tamTru,
                             noiCapCMND = c.noiCapCMND,
                             ngayCap = c.ngayCap,
                             quocTich = c.quocTich
                         };
            this.dGVDanhSach.DataSource = result.ToList();
        }
        public void KiemTraTamTruTamVang()
        {
            foreach (DataGridViewRow row in dGVDanhSach.Rows)
            {
                if (!row.IsNewRow)
                {
                    string date = (string)row.Cells["tamTru"].Value;
                    if (date.Length > 11)
                    {
                        string[] lines = date.Split('\n');
                        string dateStart = lines[0].Substring(lines[0].Length - 10);
                        DateTime dateTime = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime toDate = DateTime.Now;
                        TimeSpan duration = toDate.Subtract(dateTime);
                        int months = (int)duration.TotalDays / 30;
                        if (months > 24)
                        {
                            DataGridViewCell cell = row.Cells[13];
                            cell.ErrorText = "Số tháng tạm trú vượt quá 24 : " + months;
                            row.ErrorText = "Có lỗi về ngày tạm trú";

                        }
                    }
                }
            }

        }
        private void dGVDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string cmnd = dGVDanhSach.Rows[e.RowIndex].Cells["cmnd"].Value.ToString();

            //// Tạo và hiển thị form mới với thông tin từ cell click
            //FThongTinCongDan form = new FThongTinCongDan(cmnd);
            //form.ShowDialog();
        }
    }
}
