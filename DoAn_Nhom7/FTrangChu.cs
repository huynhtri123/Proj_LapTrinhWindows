using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DoAn_Nhom7
{
    public partial class FTrangChu : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO congdandao = new CongDanDAO();
        public FTrangChu()
        {
            InitializeComponent();
            tclChucNang.TabPages[1].Enabled = false;
            tclChucNang.TabPages[2].Enabled = false;
            cmbTimKiem.Enabled = false;
        }
        public void LayDanhSach()
        {
            this.dGVDanhSach.DataSource = congdandao.DanhSach();

            if (rdbDaKetHon.Checked == true)
                TimNguoiDaKetHon();
            else if (rdbChuaKetHon.Checked == true)
                TimNguoiChuaKetHon();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LayDanhSach();
            dGVDanhSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dGVDanhSach.Columns[0].HeaderText = "Họ tên";
            dGVDanhSach.Columns[1].HeaderText = "Ngày tháng năm sinh";
            dGVDanhSach.Columns[2].HeaderText = "Giới tính";
            dGVDanhSach.Columns[3].HeaderText = "CMND";
            dGVDanhSach.Columns[4].HeaderText = "Dân tộc ";
            dGVDanhSach.Columns[5].HeaderText = "Tình trạng hôn nhân";
            dGVDanhSach.Columns[6].HeaderText = "Nơi đăng kí khai sinh";
            dGVDanhSach.Columns[7].HeaderText = "Quê quán";
            dGVDanhSach.Columns[8].HeaderText = "Nơi thường trú";
            dGVDanhSach.Columns[9].HeaderText = "Trình độ học vấn";
            dGVDanhSach.Columns[10].HeaderText = "Nghề nghiệp";
            dGVDanhSach.Columns[11].HeaderText = "Lương";
            dGVDanhSach.Columns[12].HeaderText = "Số lần kết hôn";
            dGVDanhSach.Columns[13].HeaderText = "Tạm trú";
            dGVDanhSach.Columns[14].HeaderText = "Nơi cấp CMND";
            dGVDanhSach.Columns[15].HeaderText = "Ngày cấp";
            dGVDanhSach.Columns[16].HeaderText = "Quốc tịch";
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap formdn = new frmDangNhap();
            formdn.tclChucNang = tclChucNang;
            formdn.cmbTimKiem = cmbTimKiem;
            formdn.dangNhap = btnDangNhap;
            formdn.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet dts = congdandao.TimCongDanTheoCCCD(txtCCCD.Text, dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["cmnd"];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            txtCCCD.Text = "";
            KiemTraTamTruTamVang();
        }
        public void TimNguoiDaKetHon()
        {
            DataSet dts = congdandao.TimCongDanDaKetHon(dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["tinhTrangHonNhan"];
        }
        public void TimNguoiChuaKetHon()
        {
            DataSet dts = congdandao.TimCongDanDocThan(dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["tinhTrangHonNhan"];
        }
        public void KiemTraTamTruTamVang()
        {
           foreach (DataGridViewRow row  in dGVDanhSach.Rows)
            {
                if (!row.IsNewRow)
                {                
                    string date = (string)row.Cells["tamTru"].Value;
                    if (date.Length >11 )
                    { string[] lines = date.Split('\n');
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
        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cmbTimKiem.Text;
            switch (dv)
            {
                case "CĂN CƯỚC CÔNG DÂN":
                    FCongDan formCCCD = new FCongDan();
                    formCCCD.Show();
                    break;
                case "THUẾ":
                    FThue fThue = new FThue();
                    fThue.Show();
                    break;
                case "SỔ HỘ KHẨU":
                    FSoHoKhau fShk = new FSoHoKhau();
                    fShk.ShowDialog();
                    break;
                case "TẠM TRÚ/ TẠM VẮNG":
                    FTamTruTamVang fTttv = new FTamTruTamVang();
                    fTttv.ShowDialog();
                    break;
                case "THỐNG KÊ DÂN SỐ":
                    FThongKe fTkds = new FThongKe();
                    fTkds.ShowDialog();
                    break;
                case "HÔN NHÂN VÀ GIA ĐÌNH":
                    HonNhanVaGiaDinh fHnvgd = new HonNhanVaGiaDinh();
                    fHnvgd.ShowDialog();
                    break;
                case "KHAI SINH":
                    FKhaiSinh fKs = new FKhaiSinh();
                    fKs.Show();
                    break;
                case "KHAI TỬ":
                    FKhaiTu fKt = new FKhaiTu();
                    fKt.Show();
                    break;
            }
        }

        private void btnCCCD_Click(object sender, EventArgs e)
        {
            UCCanCuoc uc = new UCCanCuoc();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UCThue uc = new UCThue();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnSoHoKhau_Click(object sender, EventArgs e)
        {
            UCSoHoKhau uc = new UCSoHoKhau();
            uc.Dock= DockStyle.Fill;
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
        private void dGVDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string data = dGVDanhSach.Rows[e.RowIndex].Cells["cmnd"].Value.ToString();
            DataGridViewRow row = dGVDanhSach.Rows[e.RowIndex];
            if (row.ErrorText != "")
            // Tạo và hiển thị form mới với thông tin từ cell click
            {
                tclChucNang.SelectedIndex = 2;
                pnHienThi.Visible = true;
                UCTamTruTamVang uc = new UCTamTruTamVang();
                uc.Data = data;
                uc.Dock = DockStyle.Fill;
                pnHienThi.Controls.Clear();
                pnHienThi.Controls.Add(uc);
            }
            else
            {
                string imagePath = ""+data+".png";
                if (File.Exists(imagePath))
                {
                    Process.Start(imagePath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tệp ảnh.");
                }
            }    

        }


        private void btnKhaiSinh_Click(object sender, EventArgs e)
        {
            UCKhaiSinh uc = new UCKhaiSinh();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnTimKiemTen_Click(object sender, EventArgs e)
        {
            DataSet dts = congdandao.TimCongDanTheoTen(txtCCCD.Text, dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["hoTen"];
        }
    }
}
