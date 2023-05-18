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
    public partial class frmDangNhap : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        TaiKhoanDAO tkdao = new TaiKhoanDAO();
        public TabControl tclChucNang { get; set; }
        public ComboBox cmbTimKiem { get; set; }
        public Button dangNhap { get; set; }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                MessageBox.Show("Tai khoan hoac mat khau khong duoc de trong");
            else
            {
                TaiKhoan tk = new TaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
                if (tkdao.DangNhap(tk) == 1)
                {
                    tclChucNang.TabPages[1].Enabled = true;
                    tclChucNang.TabPages[2].Enabled = true;
                    cmbTimKiem.Enabled = true;
                    dangNhap.Text = txtTaiKhoan.Text;
                    this.Close();
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = false;
            pnSignUp.Visible = true;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            pnSignUp.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = true;
            pnSignUp.Visible = false;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtUsername_Dk.Text == "" || txtPass_Dk.Text == "")
                MessageBox.Show("Tai khoan hoac mat khau khong duoc de trong");
            else
            {
                if (cbDongY.Checked == true && tkdao.KiemTraTonTai(txtUsername_Dk.Text) == false)
                {
                    TaiKhoan tk = new TaiKhoan(txtUsername_Dk.Text, txtPass_Dk.Text);
                    tkdao.DangKy(tk);
                }
                else
                {
                    MessageBox.Show("That bai! Tai khoan da ton tai, hoac ban chua cam ket!");
                }
            }
        }


    }
}
