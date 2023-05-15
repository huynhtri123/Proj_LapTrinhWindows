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

namespace DoAn_Nhom7
{
    public partial class UCTamTruTamVang : UserControl
    {
        CongDanDAO cddao = new CongDanDAO();
        TamTruTamVangDAO tttvDao = new TamTruTamVangDAO();
        public string Data { get; set; }
        public UCTamTruTamVang()
        {
            InitializeComponent();
        }

        private void UCTamTruTamVang_Load(object sender, EventArgs e)
        {
            txtCMND.Text = Data;
            tttvDao.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru,txtNgayCap);
            string[] tinh = { "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "TP Hồ Chí Minh", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" };

            foreach (string dt in tinh)
            {
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

        }
        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tttvDao.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru,txtNgayCap);
            }
        }
        public void dienGiong_CongAn(string congAn, TextBox congAn2, TextBox congAn3)
        {
            congAn2.Text = congAn;
            congAn3.Text = congAn;
        }



        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CongDan cdA = new CongDan(txtTamTru.Text, txtCMND.Text, dTPNgayBatDau.Text);
            cddao.CapNhatTamTru(cdA);
        }

        private void cmbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTinh.SelectedIndex != -1)
            {
                dienGiong_CongAn(cmbTinh.Text, txtCongAn2, txtCongAn3);
            }
        }
    }
}
