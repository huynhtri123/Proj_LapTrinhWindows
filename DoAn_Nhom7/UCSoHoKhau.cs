﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Globalization;
using System.IO;

namespace DoAn_Nhom7
{
    public partial class UCSoHoKhau : UserControl
    {
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        ThanhVienShkDAO tvDao = new ThanhVienShkDAO();
        SoHoKhauDAO shkDao = new SoHoKhauDAO();
        KhaiSinhDAO ksdao = new KhaiSinhDAO();
        CongDanDAO cddao = new CongDanDAO();
        public static int stt;
        public UCSoHoKhau()
        {
            InitializeComponent();
            string[] tinh = { "Nghệ An", "Hồ Chí Minh" };
            foreach (string dt in tinh)
            {
                cmbTinhThanhPho.Items.Add(dt);
            }
            AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
            foreach (string dt in tinh)
            {
                data1.Add(dt);
            }
            cmbTinhThanhPho.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTinhThanhPho.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbTinhThanhPho.AutoCompleteCustomSource = data1;
            string[] quanHe = { "Con Dâu", "Vợ", "Con Trai", "Con Gái","Cháu Trai","Cháu Gái" };
            foreach (string dt in quanHe)
            {
                cmbQuanHe.Items.Add(dt);
            }
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (string dt in quanHe)
            {
                data.Add(dt);
            }
            cmbQuanHe.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbQuanHe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbQuanHe.AutoCompleteCustomSource = data;
 
        }
        public void LayDanhSach()
        {
            this.dtgvSoHoKhau.DataSource = hkdao.DanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (shkDao.KiemTraSHK(txtCMND.Text))
            {
                stt = Convert.ToInt32(File.ReadAllText("E:/Sualancuoi/Proj_LapTrinhWindows/cmndcon.txt"));
                string mashk = stt.ToString();
                stt++;
                File.WriteAllText("E:/Sualancuoi/Proj_LapTrinhWindows/cmndcon.txt", stt.ToString());
                SoHoKhau hk = new SoHoKhau(mashk, txtCMND.Text, txtMaKhuVuc.Text, cmbXaPhuong.Text, cmbQuanHuyen.Text, cmbTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
                hkdao.ThemSoHoKhau(hk);
                LayDanhSach();
            }
            else
                MessageBox.Show("Người này đã có sổ hộ khẩu rồi!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, cmbXaPhuong.Text, cmbQuanHuyen.Text, cmbTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
            hkdao.XoaSoHoKhau(hk);
            LayDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (hkdao.TimMaSHK(txtCMND.Text)==txtMaSoHoKhau.Text)
            {
                SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, cmbXaPhuong.Text, cmbQuanHuyen.Text, cmbTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
                hkdao.SuaSoHoKhau(hk);
                LayDanhSach();
                LayDanhSachThanhVien();

            }
            else
                MessageBox.Show("Không cùng sổ hộ khẩu");
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
        private void dtgvSoHoKhau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvSoHoKhau.Rows[e.RowIndex];
            txtMaSoHoKhau.Text = row.Cells[0].Value.ToString();
            txtCMND.Text = row.Cells[1].Value.ToString();
            txtMaKhuVuc.Text = row.Cells[2].Value.ToString();
            cmbXaPhuong.Text = row.Cells[3].Value.ToString();
            cmbQuanHuyen.Text = row.Cells[4].Value.ToString();
            cmbTinhThanhPho.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            DateTime ngayLap = DateTime.ParseExact(row.Cells[7].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtpNgayLap.Value = ngayLap;
        }
        public void LayDanhSachThanhVien()
        {
            this.dtgvThanhVienShk.DataSource = hkdao.DanhSachThanhVien(txtMaSoHoKhau.Text);
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LayDanhSachThanhVien();
            dtgvThanhVienShk.Columns[0].HeaderText = "Mã sổ hộ khẩu";
            dtgvThanhVienShk.Columns[1].HeaderText = "CMND thành viên";
            dtgvThanhVienShk.Columns[2].HeaderText = "Quan hệ với chủ hộ";
        }

        private void btnThemTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text ,txtCMND.Text, txtCmnd_tv.Text, cmbQuanHe.Text);
            if (shkDao.KiemTraTVSHK(txtCmnd_tv.Text))
            {
                if (cmbQuanHe.Text == "Vợ")
                    if  (ksdao.CMNDVoChong(txtCMND.Text) == "" )
                    {
                        CongDan cdA = new CongDan(txtCMND.Text, "");
                        CongDan cdB = new CongDan(txtCmnd_tv.Text, txtHoTen_tv.Text);
                        cddao.CapNhatKetHon(cdA, cdB);
                        tvDao.ThietLapQuanHe(tv);
                        tvDao.ThemThanhVien(tv);
                        LayDanhSachThanhVien();
                    }
                    else if ( ksdao.CMNDVoChong(txtCMND.Text) == txtCmnd_tv.Text)
                    {
                        CongDan cdA = new CongDan(txtCMND.Text, "");
                        CongDan cdB = new CongDan(txtCmnd_tv.Text, txtHoTen_tv.Text);
                        tvDao.ThietLapQuanHe(tv);
                        tvDao.ThemThanhVien(tv);
                        LayDanhSachThanhVien();
                    }
                    else
                    {
                        MessageBox.Show("Đã có vợ rồi !!!");
                    }
                else
                {
                    tvDao.ThietLapQuanHe(tv);
                    tvDao.ThemThanhVien(tv);
                    LayDanhSachThanhVien();
                }    
            }
            else
                MessageBox.Show("Người này đã có sổ hộ khẩu roi");
        }

        private void btnXoaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCMND.Text, txtCmnd_tv.Text, cmbQuanHe.Text);
            tvDao.XoaThanhVien(tv);
            LayDanhSachThanhVien();
        }

        private void btnSuaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCMND.Text, txtCmnd_tv.Text, cmbQuanHe.Text);
            tvDao.XoaTamThanhVien(tv);
            tvDao.ThietLapQuanHe(tv);
            tvDao.ThemThanhVien(tv);
            LayDanhSachThanhVien();
        }

        private void dtgvSoHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvSoHoKhau.Rows[e.RowIndex];
            txtMaSoHoKhau.Text = row.Cells[0].Value.ToString();
            txtCMND.Text = row.Cells[1].Value.ToString();
            txtMaKhuVuc.Text = row.Cells[2].Value.ToString();
            cmbXaPhuong.Text = row.Cells[3].Value.ToString();
            cmbQuanHuyen.Text = row.Cells[4].Value.ToString();
            cmbTinhThanhPho.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            DateTime ngayLap = DateTime.ParseExact(row.Cells[7].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtpNgayLap.Value = ngayLap;

        }

        private void dtgvThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvThanhVienShk.Rows[e.RowIndex];
            txtCmnd_tv.Text = row.Cells[1].Value.ToString();
            hkdao.LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, cmbQuanHe);

            if (txtHoTen_tv.Text == "")
                hkdao.LapThongTin(txtCmnd_tv, txtHoTen_tv, txtGioiTinh_tv);
        }

        private void txtCmnd_tv_KeyDown(object sender, KeyEventArgs e)
        {
            hkdao.LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, cmbQuanHe);
            if (txtHoTen_tv.Text == "")
                hkdao.LapThongTin(txtCmnd_tv, txtHoTen_tv, txtGioiTinh_tv);
        }
        
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            txtCmnd_tv.Text = txtTraCuu.Text;
            shkDao.TraCuuSoHoKhau_Click(sender, e, dtgvSoHoKhau, dtgvThanhVienShk, txtMaSoHoKhau, txtCmnd_tv, txtTraCuu, txtCMND, txtMaKhuVuc,
                                cmbXaPhuong, cmbQuanHuyen, cmbTinhThanhPho, txtDiaChi, dtpNgayLap, txtMaShk_tv, txtHoTen_tv, txtGioiTinh_tv, cmbQuanHe);

        }

        private void txtMaSoHoKhau_KeyDown(object sender, KeyEventArgs e)
        {
            hkdao.LapSoHoKhau(txtMaSoHoKhau, txtCMND, txtMaKhuVuc, cmbXaPhuong, cmbQuanHuyen, cmbTinhThanhPho, txtDiaChi, dtpNgayLap);
        }

        private void cmbTinhThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTinhThanhPho.SelectedIndex == 0)
            {
                cmbQuanHuyen.Items.Clear();
                string[] quanhuyen = { "Nam Đàn", "Thanh Chương" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in quanhuyen)
                {
                    cmbQuanHuyen.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in quanhuyen)
                {
                    data.Add(dt);
                }
                cmbQuanHuyen.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbQuanHuyen.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbQuanHuyen.AutoCompleteCustomSource = data;

            }
            else
            {
                    cmbQuanHuyen.Items.Clear();
                    string[] quanhuyen = { "Thủ Đức", "Bình Thạnh" };
                    // Thêm tên dân tộc vào ComboBox
                    foreach (string dt in quanhuyen)
                    {
                        cmbQuanHuyen.Items.Add(dt);
                    }
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    foreach (string dt in quanhuyen)
                    {
                        data.Add(dt);
                    }
                    cmbQuanHuyen.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbQuanHuyen.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbQuanHuyen.AutoCompleteCustomSource = data;
                
            }
        }

        private void cmbXaPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuanHuyen.SelectedItem.ToString() == "Nam Đàn")
            {
                cmbXaPhuong.Items.Clear();
                string[] quanhuyen = { "Nam Kim", "Khánh Sơn", "Nam Cường" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in quanhuyen)
                {
                    cmbXaPhuong.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in quanhuyen)
                {
                    data.Add(dt);
                }
                cmbXaPhuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbXaPhuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbXaPhuong.AutoCompleteCustomSource = data;

            }
            else if (cmbQuanHuyen.SelectedItem.ToString() == "Thanh Chương")
            {
                cmbXaPhuong.Items.Clear();
                string[] quanhuyen = { "Cát Văn", "Thanh Nho", "Hạnh Lâm" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in quanhuyen)
                {
                    cmbXaPhuong.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in quanhuyen)
                {
                    data.Add(dt);
                }
                cmbXaPhuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbXaPhuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbXaPhuong.AutoCompleteCustomSource = data;

            }
            else if (cmbQuanHuyen.SelectedItem.ToString() == "Bình Thạnh")
            {
                cmbXaPhuong.Items.Clear();
                string[] quanhuyen = { "Phường 3", "Phường 1", "Phường 5" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in quanhuyen)
                {
                    cmbXaPhuong.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in quanhuyen)
                {
                    data.Add(dt);
                }
                cmbXaPhuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbXaPhuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbXaPhuong.AutoCompleteCustomSource = data;

            }
            else if (cmbQuanHuyen.SelectedItem.ToString() == "Thủ Đức")
            {
                cmbXaPhuong.Items.Clear();
                string[] quanhuyen = { "Linh Chiểu", "Bình Thọ", "Linh Tây" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in quanhuyen)
                {
                    cmbXaPhuong.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in quanhuyen)
                {
                    data.Add(dt);
                }
                cmbXaPhuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbXaPhuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbXaPhuong.AutoCompleteCustomSource = data;

            }
        }
    }
    
}
