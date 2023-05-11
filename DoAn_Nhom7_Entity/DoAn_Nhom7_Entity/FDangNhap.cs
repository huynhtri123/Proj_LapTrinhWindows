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
    public partial class FDangNhap : Form
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = false;
            pnSignUp.Visible = true;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = true;
            pnSignUp.Visible = false;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void FDangNhap_Load(object sender, EventArgs e)
        {
            pnSignUp.Visible = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
        }
    }
}
