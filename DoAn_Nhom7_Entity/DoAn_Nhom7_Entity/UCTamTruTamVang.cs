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
    public partial class UCTamTruTamVang : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCTamTruTamVang()
        {
            InitializeComponent();
        }

        private void UCTamTruTamVang_Load(object sender, EventArgs e)
        {

        }
        public void LapDayThongTinTamTru(TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox queQuan, TextBox thuongTru, TextBox ngayCap)
        {
            var query = from cd in db.CongDans
                        where cd.cmnd == cmnd.Text
                        select new
                        {
                            cd.hoTen,
                            cd.ngayThangNamSinh,
                            cd.queQuan,
                            cd.noiThuongTru,
                            cd.ngayCap
                        };
            var result = query.FirstOrDefault();
            if (result != null)
            {
                hoTen.Text = result.hoTen;
                ngaySinh.Text = result.ngayThangNamSinh;
                queQuan.Text = result.queQuan;
                thuongTru.Text = result.noiThuongTru;
                ngayCap.Text = result.ngayCap;
            }           
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru, txtNgayCap);
        }
        public void dienGiong_CongAn(string congAn, TextBox congAn2, TextBox congAn3)
        {
            congAn2.Text = congAn;
            congAn3.Text = congAn;
        }

        private void txtCongAn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dienGiong_CongAn(txtCongAn.Text, txtCongAn2, txtCongAn3);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CongDan cd = new CongDan()
            {
                tamTru = txtTamTru.Text,
                cmnd = txtCMND.Text,
                ngayCap = dTPNgayBatDau.Text
            };
            string n = CapNhatTamTru(cd);

            CongDan congdan = db.CongDans.Where(p => p.cmnd == cd.cmnd).SingleOrDefault();
            congdan.tamTru = cd.tamTru + " " + cd.ngayCap + "\n" + n;
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
        }
        public string CapNhatTamTru(CongDan cd)
        {
            string n = "";
            var result = db.CongDans.Where(p => p.cmnd == cd.cmnd).FirstOrDefault();
            if (result != null)
            {
                n = n + result.tamTru.ToString();
            }
            return n;
        }
    }
}
