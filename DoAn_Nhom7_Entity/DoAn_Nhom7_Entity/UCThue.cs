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
    public partial class UCThue : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCThue()
        {
            InitializeComponent();
        }

        private void UCThue_Load(object sender, EventArgs e)
        {
            LayDanhSach();
        }
        public void LayDanhSach()
        {
            var result = from c in db.Thues
                         select new
                         { 
                             CCCD = c.CCCD,
                             LoaiThue = c.LoaiThue,
                             MucThue = c.MucThue,
                             TinhTrang = c.TinhTrang
                         };
            this.dGVThue.DataSource = result.ToList();
            this.dGVChinhSuaDanhSach.DataSource = result.ToList();
        }
        public void LayThongTinCongDan()
        {
            //var cd = db.CongDans.Where(p => p.cmnd == txtCCCD.Text).SingleOrDefault();
            //dGVCongDan.DataSource = cd;
            //txtCCCD.Text = cd.cmnd;
            //txtLuong.Text = cd.luong;
            //txtTen.Text = cd.hoTen;
            //txtNgheNghiep.Text = cd.ngheNghiep;

            var cdList = db.CongDans.Where(p => p.cmnd == txtCCCD.Text).ToList();
            dGVCongDan.DataSource = cdList;

            if (cdList.Count > 0)
            {
                txtLuong.Text = cdList[0].luong.ToString();
                txtTen.Text = cdList[0].hoTen;
                txtNgheNghiep.Text = cdList[0].ngheNghiep;
            }
        }
        private void tinhSoTienCanDong()
        {
            if (cbChuaDong.Checked == true)
            {
                Thue thue = new Thue()
                {
                    CCCD = txtCCCD.Text, 
                    LoaiThue = txtLoaiThue.Text, 
                    MucThue = (float?)Convert.ToDouble(txtMucThue.Text), 
                    TinhTrang = cbChuaDong.Text
                };
                CongDan cd  = TimCongDanTheoCCCD(thue);
                double luong = Convert.ToDouble(cd.luong);
                double mucThue = Convert.ToDouble(txtMucThue.Text);
                double soTien = (luong * mucThue) / 100;
                txtSoTienCanDong.Text = Convert.ToString(soTien);
                cbDaDong.Checked = false;
            }
            else
            {
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
            }
        }
        public void DongTien(Thue thue)
        {
            var t = db.Thues.Where(p => p.CCCD == txtCCCD.Text).SingleOrDefault();
            t.CCCD = thue.CCCD;
            t.LoaiThue = thue.LoaiThue;
            t.MucThue = thue.MucThue;
            t.TinhTrang = thue.TinhTrang;
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
        }
        public CongDan TimCongDanTheoCCCD(Thue thue)
        {
            var cd = db.CongDans.Where(p => p.cmnd == thue.CCCD).SingleOrDefault();
            return cd;
        }

        private void dGVThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD.Text = row.Cells[0].Value.ToString();
            txtLoaiThue.Text = row.Cells[1].Value.ToString();
            txtMucThue.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.ToString() == "Chua dong")
            {
                cbChuaDong.Checked = true;
                cbDaDong.Checked = false;
            }
            else if (row.Cells[3].Value.ToString() == "Da dong")
            {
                cbDaDong.Checked = true;
                cbChuaDong.Checked = false;
            }
            tinhSoTienCanDong();
            LayThongTinCongDan();
        }

        private void btnThemDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue()
            {
                CCCD = txtCCCD2.Text,
                LoaiThue = txtLoaiThue2.Text,
                MucThue = (float?)Convert.ToDouble(txtMucThue2.Text),
                TinhTrang = txtTinhTrang2.Text
            };
            db.Thues.Add(thue);
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
            LayDanhSach();
        }

        private void btnSuaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = db.Thues.Where(p => p.CCCD == txtCCCD2.Text).SingleOrDefault();
            thue.LoaiThue = txtLoaiThue2.Text;
            thue.MucThue = (float?)Convert.ToDouble(txtMucThue2.Text);
            thue.TinhTrang = txtTinhTrang2.Text;
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
            LayDanhSach();
        }

        private void btnXoaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = db.Thues.Where(p => p.CCCD == txtCCCD2.Text).SingleOrDefault();
            db.Thues.Remove(thue);
            db.SaveChanges();
            MessageBox.Show("Thanh cong");
            LayDanhSach();
        }
        private void dGVChinhSuaDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD2.Text = row.Cells[0].Value.ToString();
            txtLoaiThue2.Text = row.Cells[1].Value.ToString();
            txtMucThue2.Text = row.Cells[2].Value.ToString();
            txtTinhTrang2.Text = row.Cells[3].Value.ToString();
        }
        private void btnDongTien_Click(object sender, EventArgs e)
        {
            if (cbDaDong.Checked == true)
                MessageBox.Show("Ban da dong tien roi!");
            else
            {
                Thue thue = new Thue()
                {
                   CCCD = txtCCCD.Text, 
                   LoaiThue = txtLoaiThue.Text, 
                   MucThue = (float?)Convert.ToDouble(txtMucThue.Text), 
                   TinhTrang = cbDaDong.Text
                };
                DongTien(thue);
                cbChuaDong.Checked = false;
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
                LayDanhSach();
            }
        }
    }
}
