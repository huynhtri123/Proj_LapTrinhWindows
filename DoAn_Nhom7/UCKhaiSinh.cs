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
    public partial class UCKhaiSinh : UserControl
    {
        CongDanDAO cdDao = new CongDanDAO();
        ThanhVienShkDAO mem = new ThanhVienShkDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        public UCKhaiSinh()
        {
            InitializeComponent();
            string[] tinh = { "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "TP Hồ Chí Minh", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" };

            foreach (string dt in tinh)
            {
                cmbQueQuan.Items.Add(dt);
            }
            AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
            foreach (string dt in tinh)
            {
                data1.Add(dt);
            }
            cmbQueQuan.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbQueQuan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbQueQuan.AutoCompleteCustomSource = data1;
        }

        private void UCKhaiSinh_Load(object sender, EventArgs e)
        {

        }
        public bool KiemTraHonNhan(string cmnd)
        {
            return ksDao.KiemTraHonNhan(cmnd, txtCMNDCha.Text, txtCMNDMe.Text);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (KiemTraHonNhan(txtCMNDCha.Text))
            {
                string cmndcon = txtCMNDCha.Text + "-con " + ksDao.SoLuongThanhVien(txtCMNDCha.Text) + "";
                string GioiTinh;
                if (rDNam.Checked)
                {
                    GioiTinh = "Nam";
                }
                else
                {
                    GioiTinh = "Nữ";
                }
                string mashk = ksDao.TimMaSHK(txtCMNDCha.Text);
                string cmndChuHo = ksDao.TimChuHoSHK(mashk);
                string quanhe;
                if (cmndChuHo == txtCMNDCha.Text)
                {
                    if (GioiTinh == "Nam")
                        quanhe = "Con Trai";
                    else
                        quanhe = "Con Gái";
                }
                else
                {
                    if (GioiTinh == "Nữ")
                        quanhe = "Cháu Gái";
                    else
                        quanhe = "Cháu Trai";
                }
                    
                ThanhVienShk tv = new ThanhVienShk(mashk, cmndChuHo, cmndcon, quanhe);

                CongDan congDan = new CongDan(txtTen.Text, tpNgSinh.Text, GioiTinh, cmndcon, txtDanToc.Text, "Độc Thân", txtNoiSinh.Text, cmbQueQuan.Text, cmbQueQuan.Text, txtQuocTich.Text);
                cdDao.Them(congDan);
                if (GioiTinh == "Nam")
                    quanhe = "Con Trai";
                else
                    quanhe = "Con Gái";
                cdDao.CapNhatKhaiSinh(txtCMNDCha.Text, txtCMNDMe.Text, cmndcon,quanhe);
                //mem.ThietLapMoiQuanHeBoCon(tv);
                mem.ThietLapQuanHe(tv);
                DialogResult result = MessageBox.Show("Bạn có muốn thêm con vào sổ hộ khẩu không", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    mem.ThemThanhVien(tv);
                }
                FThongTinCongDancs form = new FThongTinCongDancs();
                form.cmnd = cmndcon;
                form.cmndbo = txtCMNDCha.Text;
                form.cmndme = txtCMNDMe.Text;
                form.noidk = txtNoiSinh.Text;
                form.ngaydk = tpDangKy.Text;
                form.ShowDialog();
                Bitmap bitmap = new Bitmap(form.Width, form.Height);
                form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
                foreach (Control control in form.Controls)
                {
                    if (control is Label button)
                    {
                        Point buttonLocation = button.PointToScreen(Point.Empty);
                        Point formLocation = form.PointToScreen(Point.Empty);
                        Point relativeLocation = new Point(buttonLocation.X - formLocation.X, buttonLocation.Y - formLocation.Y);
                        relativeLocation.Y += 34;
                        relativeLocation.X += 7;

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawString(button.Text, button.Font, new SolidBrush(button.ForeColor), relativeLocation);
                        }
                    }
                }
                bitmap.Save("" + cmndcon + ".png");
                bitmap.Dispose();
            }
            else
                MessageBox.Show("2 người chưa kết hôn");
        }

        private void txtCMNDCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ksDao.KhaiSinh_KeyDown(txtCMNDCha, txtTenCha, txtDanTocCha, txtQuocTichCha);
                txtCMNDMe.Text = ksDao.CMNDVoChong(txtCMNDCha.Text);
                if (txtCMNDMe.Text != "")
                { 
                    ksDao.KhaiSinh_KeyDown(txtCMNDMe, txtTenMe, txtDanTocMe, txtQuocTichMe);
                    txtHoTen.Text = txtTenCha.Text;
                    txtQuanHe.Text = "Bố";
                }
                else
                    MessageBox.Show("Khong tim thay nguoi yeu");
                txtDanToc.Text=txtDanTocCha.Text;
                txtQuocTich.Text = txtQuocTichCha.Text;

            }
        }
    }
}
