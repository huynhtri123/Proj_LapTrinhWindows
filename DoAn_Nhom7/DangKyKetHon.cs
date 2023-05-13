using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class DangKyKetHon : Form
    {
        CongDanDAO cddao = new CongDanDAO();
        HonNhanDAO hnDao = new HonNhanDAO();
        ThanhVienShkDAO mem = new ThanhVienShkDAO();
        DangKyKetHonDAO dkkhDao = new DangKyKetHonDAO();
        public DangKyKetHon()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (hnDao.ThoaDieuKienKetHon(txtGiayToTuyThanNam.Text, txtGiayToTuyThanNu.Text) == true)
            {
                CongDan cdA = new CongDan(txtGiayToTuyThanNam.Text, txtHoTenNam.Text);
                CongDan cdB = new CongDan(txtGiayToTuyThanNu.Text, txtHoTenNu.Text);
                string maSHKCK = dkkhDao.TimMaSHK(txtGiayToTuyThanNam.Text);
                string CMNDChuHoCK = dkkhDao.TimChuHoSHK(maSHKCK);
                string maSHKVK = dkkhDao.TimMaSHK(txtGiayToTuyThanNu.Text);
                string CMNDChuHoVK = dkkhDao.TimChuHoSHK(maSHKVK);
                string quanhe;
                if (CMNDChuHoCK == txtGiayToTuyThanNam.Text)
                    quanhe = "Vợ";
                else
                    quanhe = "Con Dâu";
                ThanhVienShk tv = new ThanhVienShk(maSHKCK, CMNDChuHoCK, txtGiayToTuyThanNu.Text, quanhe);
                ThanhVienShk tv1 = new ThanhVienShk(maSHKVK, CMNDChuHoVK, txtGiayToTuyThanNu.Text, "Con Gái");
                cddao.CapNhatKetHon(cdA, cdB);
                mem.ThietLapQuanHe(tv);
                DialogResult result = MessageBox.Show("Bạn có muốn chuyển sổ hộ khẩu người vợ không ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    mem.XoaThanhVien(tv1);
                    mem.ThemThanhVien(tv);
                }
            }
            else
                MessageBox.Show("Có người không đạt điều kiện kết hôn (1.chưa đủ tuổi; 2.đã kết hôn,3. trong 1 gia đình)");
        }
        private void txtGiayToTuyThanNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (hnDao.GioiTinh(txtGiayToTuyThanNam.Text) == "Nam")
                    hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNam, txtHoTenNam, txtNgaySinhNam, txtDanTocNam, txtQueQuanNam, txtNoiCuTruNam);
                else
                    MessageBox.Show("Sai giới tính !!!");
            }
        }

        private void txtGiayToTuyThanNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (hnDao.GioiTinh(txtGiayToTuyThanNu.Text) == "Nữ")
                    hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNu, txtHoTenNu, txtNgaySinhNu,txtDanTocNu, txtQueQuanNu, txtNoiCuTruNu);
                else
                    MessageBox.Show("Sai giới tính !!!");
            }
        }

        private void DangKyKetHon_Load(object sender, EventArgs e)
        {

        }

    }
}
