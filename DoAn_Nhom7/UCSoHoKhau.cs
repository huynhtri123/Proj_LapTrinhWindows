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
using System.Security.Policy;
using System.Globalization;

namespace DoAn_Nhom7
{
    public partial class UCSoHoKhau : UserControl
    {
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        ThanhVienShkDAO tvDao = new ThanhVienShkDAO();
        SoHoKhauDAO shkDao = new SoHoKhauDAO();
        DBConnection db = new DBConnection();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
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
        }
        public void LayDanhSach()
        {
            this.dtgvSoHoKhau.DataSource = hkdao.DanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (db.KiemTraSHK(txtCMND.Text))
            {
                SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, cmbXaPhuong.Text, cmbQuanHuyen.Text, cmbTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
                hkdao.ThemSoHoKhau(hk);
                LayDanhSach();
            }
            else
                MessageBox.Show("Da co shk");
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
            }
            else
                MessageBox.Show("Khong cung shk");
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
            dtpNgayLap.Text = row.Cells[7].Value.ToString();
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

            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text ,txtCMND.Text, txtCmnd_tv.Text, txtQuanHe.Text);
            if (shkDao.KiemTraTVSHK(txtCmnd_tv.Text))
            {
                tvDao.ThietLapQuanHe(tv);
                tvDao.ThemThanhVien(tv);
                LayDanhSachThanhVien();
            }
            else
                MessageBox.Show("Da co shk");
        }

        private void btnXoaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCMND.Text, txtCmnd_tv.Text, txtQuanHe.Text);
            tvDao.XoaThanhVien(tv);
            LayDanhSachThanhVien();
        }

        private void btnSuaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCMND.Text, txtCmnd_tv.Text, txtQuanHe.Text);
            tvDao.SuaThanhVien(tv,txtQuanHe.Text);
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
            tvDao.ThanhVienShk_CellClick(sender, e, dtgvThanhVienShk, txtCmnd_tv, txtMaShk_tv, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
        }

        private void txtCmnd_tv_KeyDown(object sender, KeyEventArgs e)
        {
            hkdao.LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);

            if (txtHoTen_tv.Text == "")
                hkdao.LapThongTin(txtCmnd_tv, txtHoTen_tv, txtGioiTinh_tv);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            string sqlStr = string.Format("SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '" + txtTraCuu.Text + "' OR CMNDChuHo = '" + txtTraCuu.Text + "'");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    txtMaSoHoKhau.Text = Convert.ToString(dta["maSoHoKhau"]);
                    txtCmnd_tv.Text = txtTraCuu.Text;
                    hkdao.LapSoHoKhau(txtMaSoHoKhau, txtCMND, txtMaKhuVuc, cmbXaPhuong, cmbQuanHuyen, cmbTinhThanhPho, txtDiaChi, dtpNgayLap);
                    hkdao.LapTVSoHoKhau(txtCMND, txtCmnd_tv, txtMaShk_tv, txtMaSoHoKhau, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
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
            finally
            {
                conn.Close();
            }

            /*LayDanhSach();
            shkDao.TraCuu_Click(sender, e, dtgvSoHoKhau, dtgvThanhVienShk,
                txtMaSoHoKhau, txtCmnd_tv, txtTraCuu, txtCMND, txtMaKhuVuc, txtXaPhuong, txtQuanHuyen, txtTinhThanhPho,
                txtDiaChi, dtpNgayLap, txtMaShk_tv, txtHoTen_tv, txtGioiTinh_tv, txtQuanHe);
            LayDanhSachThanhVien();*/

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
