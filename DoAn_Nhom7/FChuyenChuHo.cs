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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn_Nhom7
{
    public partial class FChuyenChuHo : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        KhaiSinhDAO ksdao = new KhaiSinhDAO();
        public TextBox cmnd { get; set; }
        public FChuyenChuHo()
        {
            InitializeComponent();
 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cmnd.Text = cmbDanhSach.SelectedItem.ToString();
            this.Close();
        }

        private void lblDoanVan_Click(object sender, EventArgs e)
        {

        }

        private void FChuyenChuHo_Load(object sender, EventArgs e)
        {
            string cmndthanhvien;
            string tenthanhvien;
            string quanhe;
            string mashk = ksdao.TimMaSHK(cmnd.Text);
            string sqlStr1 = string.Format("SELECT tv.CMNDThanhVien, tv.quanHeVoiChuHo, cd.hoTen FROM ThanhVienSoHoKhau tv JOIN CongDan cd ON tv.CMNDThanhVien = cd.cmnd WHERE tv.maSoHoKhau  ='" + mashk + "'");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr1, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    cmndthanhvien = Convert.ToString(dta["CMNDThanhVien"]);
                    tenthanhvien = Convert.ToString(dta["hoTen"]);
                    quanhe = Convert.ToString(dta["quanHeVoiChuHo"]);
                    cmbDanhSach.Items.Add(quanhe+" : "+tenthanhvien+" - cmnd : " +cmndthanhvien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
