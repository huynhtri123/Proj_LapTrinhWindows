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
            tttvDao.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru);

        }
        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tttvDao.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru);
            }
        }
        public void dienGiong_CongAn(string congAn, TextBox congAn2, TextBox congAn3)
        {
            congAn2.Text = congAn;
            congAn3.Text = congAn;
        }

        private void txtCongAn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dienGiong_CongAn(txtCongAn.Text, txtCongAn2, txtCongAn3);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CongDan cdA = new CongDan(txtTamTru.Text, txtCMND.Text, dTPNgayBatDau.Text);
            cddao.CapNhatTamTru(cdA);
        }
    }
}
