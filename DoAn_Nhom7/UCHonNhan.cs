using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class UCHonNhan : UserControl
    {
        public UCHonNhan()
        {
            InitializeComponent();
        }

        private void btnDangKyKetHon_Click(object sender, EventArgs e)
        {
            DangKyKetHon form1 = new DangKyKetHon();
            form1.ShowDialog();
        }

        private void btnDangKyLyHon_Click(object sender, EventArgs e)
        {
            DangKyLyHon form1 = new DangKyLyHon();
            form1.ShowDialog();
        }

        private void UCHonNhan_Load(object sender, EventArgs e)
        {

        }
    }
}
