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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn_Nhom7
{
    public partial class UCThue : UserControl
    {
        ThueDAO thueDao = new ThueDAO();
        public UCThue()
        {
            InitializeComponent();
            string[] loaiThue = { "Thuế thu nhập cá nhân", "Thuế bảo vệ môi trường", "Thuế tài nguyên", "Thuế nhà đất" };
            foreach (string dt in loaiThue)
            {
                cmbLoaiThue.Items.Add(dt);
            }
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (string dt in loaiThue)
            {
                data.Add(dt);
            }
            cmbLoaiThue.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbLoaiThue.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbLoaiThue.AutoCompleteCustomSource = data;
            string[] tinhTrang = { "Đã đóng","Chưa đóng"};
            foreach (string dt in tinhTrang)
            {
                cmbTinhTrang2.Items.Add(dt);
            }
            AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
            foreach (string dt in tinhTrang)
            {
                data1.Add(dt);
            }
            cmbTinhTrang2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTinhTrang2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbTinhTrang2.AutoCompleteCustomSource = data;
        }
        private void UCThue_Load(object sender, EventArgs e)
        {
            LayDanhSach();
            dGVThue.Columns[0].HeaderText = "Mã sổ hộ khẩu";
            dGVThue.Columns[1].HeaderText = "Loại thuế";
            dGVThue.Columns[2].HeaderText = "Mức thuế";
            dGVThue.Columns[3].HeaderText = "Tình trạng";
           
        }
        public void LayDanhSach()
        {
            this.dGVThue.DataSource = thueDao.DanhSach();
            this.dGVChinhSuaDanhSach.DataSource = thueDao.DanhSach();
          
        }
        public void LayThongTinCongDan() //lay thong tin de truyen vao datagridview (dGVCongDan)
        {
            thueDao.LayThongTinCongDan(txtCCCD.Text, this.dGVCongDan, txtLuong, txtTen, txtNgheNghiep);
            dGVCongDan.Columns[0].HeaderText = "Họ tên";
            dGVCongDan.Columns[1].HeaderText = "Ngày tháng năm sinh";
            dGVCongDan.Columns[2].HeaderText = "Giới tính";
            dGVCongDan.Columns[3].HeaderText = "CMND";
            dGVCongDan.Columns[4].HeaderText = "Dân tộc ";
            dGVCongDan.Columns[5].HeaderText = "Tình trạng hôn nhân";
            dGVCongDan.Columns[6].HeaderText = "Nơi đăng kí khai sinh";
            dGVCongDan.Columns[7].HeaderText = "Quê quán";
            dGVCongDan.Columns[8].HeaderText = "Nơi thường trú";
            dGVCongDan.Columns[9].HeaderText = "Trình độ học vấn";
            dGVCongDan.Columns[10].HeaderText = "Nghề nghiệp";
            dGVCongDan.Columns[11].HeaderText = "Lương";
            dGVCongDan.Columns[12].HeaderText = "Số lần kết hôn";
            dGVCongDan.Columns[13].HeaderText = "Tạm trú";
            dGVCongDan.Columns[14].HeaderText = "Nơi cấp CMND";
            dGVCongDan.Columns[15].HeaderText = "Ngày cấp";
            dGVCongDan.Columns[16].HeaderText = "Quốc tịch";
        }
        private void tinhSoTienCanDong()
        {
            if (cbChuaDong.Checked == true)
            {
                Thue thue = new Thue(txtCCCD.Text, txtLoaiThue.Text, Convert.ToDouble(txtMucThue.Text), cbChuaDong.Text);
                DataSet dts = thueDao.timCongDanTheoCCCD(thue);
                double luong = Convert.ToDouble(dts.Tables[0].Rows[0][11].ToString());
                double mucThue = Convert.ToDouble(txtMucThue.Text);
                double soTien = (luong * mucThue) / 100;
                txtSoTienCanDong.Text = Convert.ToString(soTien);
                cbDaDong.Checked = false;
            }
            else
            {
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
            }
        }
        private void btnDongTien_Click(object sender, EventArgs e)
        {
            if (cbDaDong.Checked == true)
                MessageBox.Show("Ban da dong tien roi!");
            else
            {
                Thue thue = new Thue(txtCCCD.Text, txtLoaiThue.Text, Convert.ToDouble(txtMucThue.Text), cbDaDong.Text);
                thueDao.DongTien(thue);
                cbChuaDong.Checked = false;
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
                LayDanhSach();
            }
        }
        private void btnThemDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, cmbLoaiThue.Text, Convert.ToDouble(txtMucThue2.Text), cmbTinhTrang2.Text);
            thueDao.ThemDoiTuong(thue);
            LayDanhSach();
        }
        private void btnSuaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, cmbLoaiThue.Text, Convert.ToDouble(txtMucThue2.Text), cmbTinhTrang2.Text);
            thueDao.SuaDoiTuong(thue);
            LayDanhSach();
        }
        private void btnXoaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, cmbLoaiThue.Text, Convert.ToDouble(txtMucThue2.Text), cmbTinhTrang2.Text);
            thueDao.XoaDoiTuong(thue);
            LayDanhSach();
        }
        private void dGVThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD.Text = row.Cells[0].Value.ToString();
            txtLoaiThue.Text = row.Cells[1].Value.ToString();
            txtMucThue.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.ToString() == "Chưa đóng")
            {
                cbChuaDong.Checked = true;
                cbDaDong.Checked = false;
            }
            else if (row.Cells[3].Value.ToString() == "Đã đóng")
            {
                cbDaDong.Checked = true;
                cbChuaDong.Checked = false;
            }
            tinhSoTienCanDong();
            LayThongTinCongDan();
        }
        private void dGVChinhSuaDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD2.Text = row.Cells[0].Value.ToString();
            cmbLoaiThue.Text = row.Cells[1].Value.ToString();
            txtMucThue2.Text = row.Cells[2].Value.ToString();
            cmbTinhTrang2.Text = row.Cells[3].Value.ToString();
        }
    }
}
