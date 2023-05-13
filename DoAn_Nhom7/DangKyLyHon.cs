using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class DangKyLyHon : Form
    {
        CongDanDAO cddao = new CongDanDAO();
        HonNhanDAO hnDao = new HonNhanDAO();
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        ThanhVienShkDAO tvDao = new ThanhVienShkDAO();
        DangKyLyHonDAO dklhDao = new DangKyLyHonDAO();
        public DangKyLyHon()
        {
            InitializeComponent();
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (hnDao.ThoaDieuKienLyHon(txtCMNDA.Text, txtCMNDB.Text))
            {
                CongDan cdA = new CongDan(txtCMNDA.Text);
                cddao.CapNhatLyHon(cdA);
                CongDan cdB = new CongDan(txtCMNDB.Text);
                cddao.CapNhatLyHon(cdB);
                string mashk = dklhDao.TimMaSHK(txtCMNDA.Text);
                string CMNDChuHo = dklhDao.TimChuHoSHK(mashk);
                string quanhe;
                if (CMNDChuHo == txtCMNDA.Text)
                    quanhe = "Vợ";
                else
                    quanhe = "Con Dâu";
                ThanhVienShk tv = new ThanhVienShk(mashk, CMNDChuHo, txtCMNDB.Text,quanhe);
                //tvDao.XoaThanhVien(tv);
                CongDan a = new CongDan(txtCMNDB.Text);
                cddao.Xoa1(a);
                cddao.CapNhatQuanHeLyHon(cdA, cdB);
            }
            else
                MessageBox.Show("Có người đang ở tình trạng độc thân");
        }        
        private void txtCMNDA_KeyDown(object sender, KeyEventArgs e)
        {              
            if (e.KeyCode == Keys.Enter)
            {
                hnDao.LapDayThongTin_LyHon(txtCMNDA.Text, txtTenA, txtNamSinhA, txtCuTruA);
                txtCMNDB.Text = dklhDao.CMNDVoChong(txtCMNDA.Text);
                if (txtCMNDB.Text != "")
                    hnDao.LapDayThongTin_LyHon(txtCMNDB.Text, txtTenB, txtNamSinhB, txtCuTruB);
                else
                    MessageBox.Show("Không tìm thấy vợ");
            }
        }
        private void DangKyLyHon_Load(object sender, EventArgs e)
        {

        }
    }
}
