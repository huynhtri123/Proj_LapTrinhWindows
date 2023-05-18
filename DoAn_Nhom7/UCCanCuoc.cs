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
using System.IO;

namespace DoAn_Nhom7
{
    public partial class UCCanCuoc : UserControl
    {
        CongDanDAO cddao = new CongDanDAO();
        public static int stt;
        public UCCanCuoc()
        {
            InitializeComponent();

            string[] quocTich = { "Việt Nam", "Nga"};
            foreach (string dt in quocTich)
            {
                cmbQuocTich.Items.Add(dt);
            }
            AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
            foreach (string dt in quocTich)
            {
                data1.Add(dt);
            }
            cmbQuocTich.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbQuocTich.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbQuocTich.AutoCompleteCustomSource = data1;
            //
            string[] hocVan = { "Đại Học", "Trung Học Phổ Thông","Trung Học Cơ Sở", "Tiểu Học","Không Học" };
            foreach (string dt in hocVan)
            {
                cmbHocVan.Items.Add(dt);
            }
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (string dt in hocVan)
            {
                data.Add(dt);
            }
            cmbHocVan.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbHocVan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbHocVan.AutoCompleteCustomSource = data;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string GioiTinh;
            stt = Convert.ToInt32(File.ReadAllText("E:/Sualancuoi/Proj_LapTrinhWindows/cmndcon.txt"));
            string cmnd = stt.ToString();
            stt++;
            File.WriteAllText("E:/Sualancuoi/Proj_LapTrinhWindows/cmndcon.txt", stt.ToString());
            if (rDNam.Checked)
            {
                GioiTinh = "Nam"; 
            }
            else
            {
                GioiTinh = "Nữ"; 
            }
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, GioiTinh, cmnd, cmbDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, cmbTinh.Text, txtThuongTru.Text, cmbHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, cmbNoiCap.Text, dTPNgayCap.Text,cmbQuocTich.Text);
            cddao.Them(cd);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string GioiTinh;
            if (rDNam.Checked)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, GioiTinh, txtCMND.Text, cmbDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, cmbTinh.Text, txtThuongTru.Text, cmbHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, cmbNoiCap.Text, dTPNgayCap.Text, cmbQuocTich.Text);
            cddao.Xoa(cd);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string GioiTinh;
            if (rDNam.Checked)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, GioiTinh, txtCMND.Text, cmbDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, cmbTinh.Text, txtThuongTru.Text, cmbHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, cmbNoiCap.Text, dTPNgayCap.Text, cmbQuocTich.Text);
            cddao.Sua(cd);
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cddao.LapDayThongTinCD(txtCMND, txtHoTen, dTPNgaySinh, rDNu,rDNam, cmbDanToc, txtHonNhan, txtKhaiSinh, cmbTinh, txtThuongTru, cmbHocVan, txtNgheNghiep, txtLuong, txtSoLanKetHon, txtTamTru, cmbNoiCap, dTPNgayCap,cmbQuocTich);
            }
        }

        private void cmbQuocTich_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbQuocTich.SelectedIndex == 0)
            {
                cmbDanToc.Items.Clear();
                cmbTinh.Items.Clear();
                cmbNoiCap.Items.Clear();
                string[] danToc = { "Kinh", "Tày", "Thái", "Mường", "Khmer", "Hoa", "Nùng", "H'Mông", "Dao", "Gia Rai", "Ê Đê", "Ba Na", "Sán Chay", "Chăm", "Kơ Ho", "Xơ Đăng", "Sán Dìu", "Hrê", "Ra Glai", "Mnông", "Thổ", "Stiêng", "Khơ mú", "Bru - Vân Kiều", "Cơ Tu", "Giáy", "Tà Ôi", "Mạ", "Giẻ-Triêng", "Co", "Chơ Ro", "Xinh Mun", "Hà Nhì", "Chu Ru", "Lào", "La Chí", "Kháng", "Phù Lá", "La Hủ", "La Ha", "Pà Thẻn", "Lự", "Ngái", "Chứt", "Lô Lô", "Mảng", "Cơ Lao", "Bố Y", "Cống", "Si La", "Pu Péo", "Rơ Măm", "Brâu", "Ơ Đu" };
                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in danToc)
                {
                    cmbDanToc.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in danToc)
                {
                    data.Add(dt);
                }
                cmbDanToc.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDanToc.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbDanToc.AutoCompleteCustomSource = data;
                string[] tinh = { "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước","Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng", "Đắk Lắk","Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang","Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang","Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu","Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An","Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam","Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh","Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang","TP Hồ Chí Minh", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" };
            
                foreach (string dt in tinh)
                {
                    cmbNoiCap.Items.Add(dt);
                    cmbTinh.Items.Add(dt);
                }
                AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                foreach (string dt in tinh)
                {
                    data1.Add(dt);
                }
                cmbTinh.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbTinh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbTinh.AutoCompleteCustomSource = data1;
                cmbNoiCap.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbNoiCap.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbNoiCap.AutoCompleteCustomSource = data1;
            }    
            else 
            {
                cmbDanToc.Items.Clear();
                cmbTinh.Items.Clear();
                cmbNoiCap.Items.Clear();

                string[] danToc = {"Nga","Tatar","Chuvash" };                // Thêm tên dân tộc vào ComboBox
                foreach (string dt in danToc)
                {
                    cmbDanToc.Items.Add(dt);
                }
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (string dt in danToc)
                {
                    data.Add(dt);
                }
                cmbDanToc.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDanToc.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbDanToc.AutoCompleteCustomSource = data;
                string[] tinh = { "Belgorod", "Bryansk", "Ivanovo" };
                foreach (string dt in tinh)
                {
                    cmbTinh.Items.Add(dt);
                    cmbNoiCap.Items.Add(dt);

                }
                AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                foreach (string dt in tinh)
                {
                    data1.Add(dt);
                }
                cmbTinh.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbTinh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbTinh.AutoCompleteCustomSource = data1;
                cmbNoiCap.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbNoiCap.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbNoiCap.AutoCompleteCustomSource = data1;
            }    
        }

        private void UCCanCuoc_Load(object sender, EventArgs e)
        {

        }
    }
}
