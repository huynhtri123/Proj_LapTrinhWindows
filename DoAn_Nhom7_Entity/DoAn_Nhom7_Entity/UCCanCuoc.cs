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
    public partial class UCCanCuoc : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCCanCuoc()
        {
            InitializeComponent();
        }

        private void UCCanCuoc_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (rDNam.Checked)
                gt = rDNam.Text;
            else
                gt = rDNu.Text;

            CongDan cd = new CongDan()
            {
                hoTen = txtHoTen.Text,
                ngayThangNamSinh = dTPNgaySinh.Text,
                gioiTinh = gt,
                cmnd = txtCMND.Text,
                danToc = txtDanToc.Text,
                tinhTrangHonNhan = txtHonNhan.Text,
                noiDangKiKhaiSinh = txtKhaiSinh.Text,
                queQuan = txtQueQuan.Text,
                noiThuongTru = txtThuongTru.Text,
                trinhDoHocVan = txtHocVan.Text,
                ngheNghiep = txtNgheNghiep.Text,
                luong = txtLuong.Text,
                soLanKetHon = txtSoLanKetHon.Text,
                tamTru = txtTamTru.Text,
                noiCapCMND = txtNoiCapCMND.Text,
                ngayCap = dTPNgayCap.Text,
                quocTich = txtQuocTich.Text
            };
            db.CongDans.Add(cd);
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CongDan cd = db.CongDans.Where(p => p.cmnd == txtCMND.Text).SingleOrDefault();
            db.CongDans.Remove(cd);
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (rDNam.Checked)
                gt = rDNam.Text;
            else
                gt = rDNu.Text;

            CongDan cd = db.CongDans.Where(p => p.cmnd == txtCMND.Text).SingleOrDefault();
            cd.hoTen = txtHoTen.Text;
            cd.ngayThangNamSinh = dTPNgaySinh.Text;
            cd.gioiTinh = gt;
            cd.danToc = txtDanToc.Text;
            cd.tinhTrangHonNhan = txtHonNhan.Text;
            cd.noiDangKiKhaiSinh = txtKhaiSinh.Text;
            cd.queQuan = txtQueQuan.Text;
            cd.noiThuongTru = txtThuongTru.Text;
            cd.trinhDoHocVan = txtHocVan.Text;
            cd.ngheNghiep = txtNgheNghiep.Text;
            cd.luong = txtLuong.Text;
            cd.soLanKetHon = txtSoLanKetHon.Text;
            cd.tamTru = txtTamTru.Text;
            cd.noiCapCMND = txtNoiCapCMND.Text;
            cd.ngayCap = dTPNgayCap.Text;
            cd.quocTich = txtQuocTich.Text;

            db.SaveChanges();
            MessageBox.Show("Thanh cong");
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LapDayThongTinCD(txtCMND, txtHoTen, dTPNgaySinh, rDNu, rDNam, txtDanToc, txtHonNhan, txtKhaiSinh, txtQueQuan, txtThuongTru, txtHocVan, txtNgheNghiep, txtLuong, txtSoLanKetHon, txtTamTru, txtNoiCapCMND, dTPNgayCap, txtQuocTich);
            }
        }
        public void LapDayThongTinCD(TextBox cmnd, TextBox a, DateTimePicker dt, RadioButton b, RadioButton b1, TextBox d, TextBox f, TextBox g, TextBox j, TextBox k, TextBox x, TextBox y, TextBox z, TextBox i, TextBox t, TextBox n, DateTimePicker m, TextBox p)
        {
            var congDan = db.CongDans.FirstOrDefault(cd => cd.cmnd == cmnd.Text);

            if (congDan != null)
            {
                a.Text = congDan.hoTen;
                dt.Text = congDan.ngayThangNamSinh;
                if (congDan.gioiTinh == "nu")
                {
                    b.Checked = true;
                }
                else
                {
                    b1.Checked = true;
                }
                d.Text = congDan.danToc;
                f.Text = congDan.tinhTrangHonNhan;
                g.Text = congDan.noiDangKiKhaiSinh;
                j.Text = congDan.queQuan;
                k.Text = congDan.noiThuongTru;
                x.Text = congDan.trinhDoHocVan;
                y.Text = congDan.ngheNghiep;
                z.Text = congDan.luong;
                i.Text = congDan.soLanKetHon.ToString();
                t.Text = congDan.tamTru;
                n.Text = congDan.noiCapCMND;
                m.Text = congDan.ngayCap;
                p.Text = congDan.quocTich;
            }           
        }
    }
}
