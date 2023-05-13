using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class UCKhaiSinh : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCKhaiSinh()
        {
            InitializeComponent();
        }

        public bool KiemTraHonNhan(string cmnd)
        {
            return KiemTraVoChong(cmnd, txtCMNDCha.Text, txtCMNDMe.Text);
        }
        public bool KiemTraVoChong(string cmnd, string cmndCha, string cmndMe)
        {
            var congDan = db.CongDans.FirstOrDefault(c => c.cmnd == cmnd);
            if (congDan != null)
            {
                cmndCha = congDan.tinhTrangHonNhan;
                string cmndDoiPhuong = cmndCha.Substring(32);
                if (cmndDoiPhuong == cmndMe)
                {
                    return true;
                }
            }
            return false;
        }
        public int SoLuongThanhVien(string cmnd)
        {
            string a = TimMaSHK(cmnd);
            var count = db.ThanhVienSoHoKhaus.Count(t => t.maSoHoKhau == a);

            return count;
        }
        public string TimMaSHK(string cmnd)
        {
            var maSoHoKhau = db.ThanhVienSoHoKhaus.Where(t => t.CMNDChuHo == cmnd || t.CMNDThanhVien == cmnd).Select(t => t.maSoHoKhau).FirstOrDefault();
            return maSoHoKhau;
        }
        public string TimChuHoSHK(string mashk)
        {
            var chuHo = db.SoHoKhaus.Where(s => s.maSoHoKhau == mashk).Select(s => s.CMNDChuHo).FirstOrDefault();

            return chuHo;
        }
        private void UCKhaiSinh_Load(object sender, EventArgs e)
        {
            
        }
        public void CapNhatKhaiSinh(string cmndbo, string cmndme, string cmndcon)
        {
            var quanHe = new QuanHe
            {
                CMND1 = cmndbo,
                CMND2 = cmndcon,
                quanHeVoiCMND1 = "Con",
                quanHeVoiCMND2 = "Bố"
            };
            db.QuanHes.Add(quanHe);
            db.SaveChanges();

            var quanHe2 = new QuanHe
            {
                CMND1 = cmndcon,
                CMND2 = cmndbo,
                quanHeVoiCMND1 = "Bố",
                quanHeVoiCMND2 = "Con"
            };
            db.QuanHes.Add(quanHe);
            db.SaveChanges();

            var quanHe3 = new QuanHe
            {
                CMND1 = cmndme,
                CMND2 = cmndcon,
                quanHeVoiCMND1 = "Mẹ",
                quanHeVoiCMND2 = "Con"
            };
            db.QuanHes.Add(quanHe);
            db.SaveChanges();

            var quanHe4 = new QuanHe
            {
                CMND1 = cmndcon,
                CMND2 = cmndme,
                quanHeVoiCMND1 = "Con",
                quanHeVoiCMND2 = "Mẹ"
            };
            db.QuanHes.Add(quanHe);
            db.SaveChanges();
        }
        public void ThemThanhVien(ThanhVienSoHoKhau tv)
        {
            if (tv.quanHeVoiChuHo == "Con")
                ThietLapMoiQuanHe(tv, "Bố", "Con");

            else if (tv.quanHeVoiChuHo == "Vợ")
                ThietLapMoiQuanHe(tv, "Chồng", "Vợ");

            else if (tv.quanHeVoiChuHo == "Con Dâu")
                ThietLapMoiQuanHe(tv, "Bố Chồng", "Con Dâu");

            else if (tv.quanHeVoiChuHo == "Cháu")
                ThietLapMoiQuanHe(tv, "Ông", "Cháu");

            ThietLapQuanHeGiaDinh(tv);


            var query = from qh in db.QuanHes
                        where qh.CMND1 == tv.CMNDChuHo && qh.CMND2 == tv.CMNDThanhVien
                        select qh.quanHeVoiCMND1;

            string quanHeVoiChuHo = query.FirstOrDefault();

            if (!string.IsNullOrEmpty(quanHeVoiChuHo))
            {
                var thanhVienSoHoKhau = new ThanhVienSoHoKhau
                {
                    maSoHoKhau = tv.maSoHoKhau,
                    CMNDChuHo = tv.CMNDChuHo,
                    CMNDThanhVien = tv.CMNDThanhVien,
                    quanHeVoiChuHo = quanHeVoiChuHo
                };
                db.ThanhVienSoHoKhaus.Add(thanhVienSoHoKhau);
                db.SaveChanges();
            }
        }
        public bool ChuaCoQuanHe(string cmnda, string cmndb)
        {
            var quanHe = db.QuanHes.FirstOrDefault(qh => qh.CMND1 == cmnda && qh.CMND2 == cmndb);
            if (quanHe != null)
            {
                return false;
            }
            return true;
        }
        public void ThietLapMoiQuanHe(ThanhVienSoHoKhau tv, string a, string b)
        {
            if (ChuaCoQuanHe(tv.CMNDChuHo, tv.CMNDThanhVien) && ChuaCoQuanHe(tv.CMNDThanhVien, tv.CMNDChuHo))
            {
                var quanHe = new QuanHe
                {
                    CMND1 = tv.CMNDChuHo,
                    CMND2 = tv.CMNDThanhVien,
                    quanHeVoiCMND1 = b,
                    quanHeVoiCMND2 = a
                };
                db.QuanHes.Add(quanHe);
                db.SaveChanges();

                var quanHe2 = new QuanHe
                {
                    CMND1 = tv.CMNDThanhVien,
                    CMND2 = tv.CMNDChuHo,
                    quanHeVoiCMND1 = a,
                    quanHeVoiCMND2 = b
                };

                db.QuanHes.Add(quanHe2);
                db.SaveChanges();
            }
        }
        //public void ThietLapMoiQuanHeVoChong(ThanhVienSoHoKhau tv)
        //{
        //    if (ChuaCoQuanHe(tv.CMNDChuHo, tv.CMNDThanhVien) && ChuaCoQuanHe(tv.CMNDThanhVien, tv.CMNDChuHo))
        //    {
        //        var quanHe = new QuanHe
        //        {
        //            CMND1 = tv.CMNDChuHo,
        //            CMND2 = tv.CMNDThanhVien,
        //            quanHeVoiCMND1 = "Vợ",
        //            quanHeVoiCMND2 = "Chồng"
        //        };
        //        db.QuanHes.Add(quanHe);
        //        db.SaveChanges();

        //        var quanHe2 = new QuanHe
        //        {
        //            CMND1 = tv.CMNDThanhVien,
        //            CMND2 = tv.CMNDChuHo,
        //            quanHeVoiCMND1 = "Chồng",
        //            quanHeVoiCMND2 = "Vợ"
        //        };
        //        db.QuanHes.Add(quanHe2);
        //        db.SaveChanges();
        //    }
        //}
        //public void ThietLapMoiQuanHeBoConDau(ThanhVienSoHoKhau tv)
        //{
        //    if (ChuaCoQuanHe(tv.CMNDChuHo, tv.CMNDThanhVien) && ChuaCoQuanHe(tv.CMNDThanhVien, tv.CMNDChuHo))
        //    {
        //        var quanHe = new QuanHe
        //        {
        //            CMND1 = tv.CMNDChuHo,
        //            CMND2 = tv.CMNDThanhVien,
        //            quanHeVoiCMND1 = "Con Dâu",
        //            quanHeVoiCMND2 = "Bố Chồng"
        //        };
        //        db.QuanHes.Add(quanHe);
        //        db.SaveChanges();

        //        var quanHe2 = new QuanHe
        //        {
        //            CMND1 = tv.CMNDThanhVien,
        //            CMND2 = tv.CMNDChuHo,
        //            quanHeVoiCMND1 = "Bố Chồng",
        //            quanHeVoiCMND2 = "Con Dâu"
        //        };
        //        db.QuanHes.Add(quanHe2);
        //        db.SaveChanges();
        //    }
        //}
        //public void ThietLapMoiQuanHeOngChau(ThanhVienSoHoKhau tv)
        //{
        //    if (ChuaCoQuanHe(tv.CMNDChuHo, tv.CMNDThanhVien) && ChuaCoQuanHe(tv.CMNDThanhVien, tv.CMNDChuHo))
        //    {
        //        var quanHe = new QuanHe
        //        {
        //            CMND1 = tv.CMNDChuHo,
        //            CMND2 = tv.CMNDThanhVien,
        //            quanHeVoiCMND1 = "Cháu",
        //            quanHeVoiCMND2 = "Ông"
        //        };
        //        db.QuanHes.Add(quanHe);
        //        db.SaveChanges();

        //        var quanHe2 = new QuanHe
        //        {
        //            CMND1 = tv.CMNDThanhVien,
        //            CMND2 = tv.CMNDChuHo,
        //            quanHeVoiCMND1 = "Ông",
        //            quanHeVoiCMND2 = "Cháu"
        //        };
        //        db.QuanHes.Add(quanHe2);
        //        db.SaveChanges();
        //    }
        //}
        public void ThietLapQuanHeGiaDinh(ThanhVienSoHoKhau tv)
        {
            string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.maSoHoKhau + "'");
            if (tv.quanHeVoiChuHo == "Con Dâu")
            {
                var query = from qh in db.QuanHes
                            join tvshk in db.ThanhVienSoHoKhaus on qh.CMND1 equals tvshk.CMNDChuHo
                            where (qh.quanHeVoiCMND1 == "Con Trai" || qh.quanHeVoiCMND1 == "Con Gái") &&
                                  ChuaCoQuanHe(tvshk.CMNDThanhVien, tv.CMNDThanhVien) &&
                                  ChuaCoQuanHe(tv.CMNDThanhVien, tvshk.CMNDThanhVien)
                            select new { qh.CMND1, qh.quanHeVoiCMND1 };

                foreach (var result in query)
                {
                    if (result.quanHeVoiCMND1 == "Con Trai" || result.quanHeVoiCMND1 == "Con Gái")
                    {
                        ThietLapMoiQuanHe(tv, "Em Rể", "Chị Dâu");
                    }
                    else if (result.quanHeVoiCMND1 == "Vợ")
                    {
                        ThietLapMoiQuanHe(tv, "Mẹ Chồng", "Con Dâu");
                    }
                    else if (result.quanHeVoiCMND1 == "Cháu")
                    {
                        ThietLapMoiQuanHe(tv, "Cháu", "Mợ");
                    }
                }
            }
            else if (tv.quanHeVoiChuHo == "Cháu")
            {
                var query = from qh in db.QuanHes
                            join tvshk in db.ThanhVienSoHoKhaus on qh.CMND1 equals tvshk.CMNDChuHo
                            where (qh.quanHeVoiCMND1 == "Con Trai" || qh.quanHeVoiCMND1 == "Con Gái" || qh.quanHeVoiCMND1 == "Vợ" || qh.quanHeVoiCMND1 == "Con Dâu") &&
                                  ChuaCoQuanHe(tvshk.CMNDThanhVien, tv.CMNDThanhVien) &&
                                  ChuaCoQuanHe(tv.CMNDThanhVien, tvshk.CMNDThanhVien)
                            select new { qh.CMND1, qh.quanHeVoiCMND1 };

                foreach (var result in query)
                {
                    string a = result.CMND1;
                    string b = result.quanHeVoiCMND1;

                    if (b == "Con Trai")
                    {
                        ThietLapMoiQuanHe(tv, "Chú", "Cháu");
                    }
                    else if (b == "Con Gái")
                    {
                        ThietLapMoiQuanHe(tv, "Dì", "Cháu");
                    }
                    else if (b == "Vợ")
                    {
                        ThietLapMoiQuanHe(tv, "Bà", "Cháu");
                    }
                    else if (b == "Con Dâu")
                    {
                        ThietLapMoiQuanHe(tv, "Mợ", "Cháu");
                    }
                }
            }
            else if (tv.quanHeVoiChuHo == "Con")
            {
                var query = from qh in db.QuanHes
                            join tvshk in db.ThanhVienSoHoKhaus on qh.CMND1 equals tvshk.CMNDChuHo
                            where (qh.quanHeVoiCMND1 == "Bố" || qh.quanHeVoiCMND1 == "Mẹ" || qh.quanHeVoiCMND1 == "Anh Trai" || qh.quanHeVoiCMND1 == "Em Gái" || qh.quanHeVoiCMND1 == "Vợ") &&
                                  ChuaCoQuanHe(tvshk.CMNDThanhVien, tv.CMNDThanhVien) &&
                                  ChuaCoQuanHe(tv.CMNDThanhVien, tvshk.CMNDThanhVien)
                            select new { qh.CMND1, qh.quanHeVoiCMND1 };

                foreach (var result in query)
                {
                    string a = result.CMND1;
                    string b = result.quanHeVoiCMND1;

                    if (b == "Bố")
                    {
                        ThietLapMoiQuanHe(tv, "Ông", "Cháu");
                    }
                    else if (b == "Mẹ")
                    {
                        ThietLapMoiQuanHe(tv, "Bà", "Cháu");
                    }
                    else if (b == "Anh Trai")
                    {
                        ThietLapMoiQuanHe(tv, "Chú", "Cháu");
                    }
                    else if (b == "Em Gái")
                    {
                        ThietLapMoiQuanHe(tv, "Dì", "Cháu");
                    }
                    else if (b == "Vợ")
                    {
                        ThietLapMoiQuanHe(tv, "Mẹ", "Con");
                    }
                }
            }
            else if (tv.quanHeVoiChuHo == "Vợ")
            {
                var query = from qh in db.QuanHes
                            join tvshk in db.ThanhVienSoHoKhaus on qh.CMND1 equals tvshk.CMNDChuHo
                            where (qh.quanHeVoiCMND1 == "Bố" || qh.quanHeVoiCMND1 == "Mẹ" || qh.quanHeVoiCMND1 == "Anh Trai" || qh.quanHeVoiCMND1 == "Em Gái") &&
                                  ChuaCoQuanHe(tvshk.CMNDThanhVien, tv.CMNDThanhVien) &&
                                  ChuaCoQuanHe(tv.CMNDThanhVien, tvshk.CMNDThanhVien)
                            select new { qh.CMND1, qh.quanHeVoiCMND1 };

                foreach (var result in query)
                {
                    string a = result.CMND1;
                    string b = result.quanHeVoiCMND1;

                    if (b == "Bố")
                    {
                        ThietLapMoiQuanHe(tv, "Bố Chồng", "Con Dâu");
                    }
                    else if (b == "Mẹ")
                    {
                        ThietLapMoiQuanHe(tv, "Mẹ Chồng", "Con Dâu");
                    }
                    else if (b == "Anh Trai" || b == "Em Gái")
                    {
                        ThietLapMoiQuanHe(tv, "Em Rể", "Chị Dâu");
                    }
                }
            }
        }

        private void txtCMNDCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KhaiSinh_KeyDown(txtCMNDCha, txtTenCha, txtDanTocCha, txtQuocTichCha);
                txtCMNDMe.Text = CMNDVoChong(txtCMNDCha.Text);
                if (txtCMNDMe.Text != "")
                {
                    KhaiSinh_KeyDown(txtCMNDMe, txtTenMe, txtDanTocMe, txtQuocTichMe);
                    txtHoTen.Text = txtTenCha.Text;
                    txtQuanHe.Text = "Bố";
                }
                else
                    MessageBox.Show("Khong tim thay nguoi yeu");
            }
        }
        public string CMNDVoChong(string cmnd)
        {
            var query = from congDan in db.CongDans
                        where congDan.cmnd == cmnd
                        select congDan.tinhTrangHonNhan;

            string a = query.FirstOrDefault();

            if (a != null)
            {
                if (a != "Độc Thân")
                    a = a.Substring(32);
                else
                    a = "";
            }

            return a;
        }
        public void KhaiSinh_KeyDown(TextBox cmnd, TextBox ten, TextBox danToc, TextBox quocTich)
        {
            var query = from congDan in db.CongDans
                        where congDan.cmnd == cmnd.Text
                        select new { congDan.hoTen, congDan.danToc, congDan.quocTich };

            var result = query.FirstOrDefault();

            if (result != null)
            {
                ten.Text = result.hoTen;
                danToc.Text = result.danToc;
                quocTich.Text = result.quocTich;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (KiemTraHonNhan(txtCMNDCha.Text))
            {
                int cc = SoLuongThanhVien(txtCMNDCha.Text);
                MessageBox.Show(Convert.ToString(cc));
                string cmndcon = txtCMNDCha.Text + "-con " + SoLuongThanhVien(txtCMNDCha.Text) + "";
                string GioiTinh;
                if (rDNam.Checked)
                {
                    GioiTinh = "Nam";
                }
                else
                {
                    GioiTinh = "Nữ";
                }
                string mashk = TimMaSHK(txtCMNDCha.Text);
                string cmndChuHo = TimChuHoSHK(mashk);
                string quanhe;
                if (cmndChuHo == txtCMNDCha.Text)
                    quanhe = "Con";
                else
                    quanhe = "Cháu";

                ThanhVienSoHoKhau tv = new ThanhVienSoHoKhau()
                {
                    maSoHoKhau = mashk,
                    CMNDChuHo = cmndChuHo,
                    CMNDThanhVien = cmndcon,
                    quanHeVoiChuHo = quanhe
                };
                CongDan congDan = new CongDan()
                {
                    hoTen = txtTen.Text,
                    ngayThangNamSinh = tpNgSinh.Text,
                    gioiTinh = GioiTinh,
                    cmnd = cmndcon,
                    danToc = txtDanToc.Text,
                    tinhTrangHonNhan = "Doc Than",
                    noiDangKiKhaiSinh = txtNoiSinh.Text,
                    queQuan = txtQueQuan.Text,
                    noiThuongTru = txtQueQuan.Text,
                    quocTich = txtQuocTich.Text
                };

                db.CongDans.Add(congDan);
                db.SaveChanges();

                CapNhatKhaiSinh(txtCMNDCha.Text, txtCMNDMe.Text, cmndcon);
                //mem.ThietLapMoiQuanHeBoCon(tv);
                ThemThanhVien(tv);
                FThongTinCongDan form = new FThongTinCongDan();
                form.cmnd = cmndcon;
                form.cmndbo = txtCMNDCha.Text;
                form.cmndme = txtCMNDMe.Text;
                form.noidk = txtNoiSinh.Text;
                form.ngaydk = tpDangKy.Text;
                form.ShowDialog();
                Bitmap bitmap = new Bitmap(form.Width, form.Height);
                form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
                foreach (Control control in form.Controls)
                {
                    if (control is Label button)
                    {
                        Point buttonLocation = button.PointToScreen(Point.Empty);
                        Point formLocation = form.PointToScreen(Point.Empty);
                        Point relativeLocation = new Point(buttonLocation.X - formLocation.X, buttonLocation.Y - formLocation.Y);
                        relativeLocation.Y += 34;
                        relativeLocation.X += 7;

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawString(button.Text, button.Font, new SolidBrush(button.ForeColor), relativeLocation);
                        }
                    }
                }
                bitmap.Save("" + cmndcon + ".png");
                bitmap.Dispose();
            }
            else
                MessageBox.Show("2 người chưa kết hôn");
        }
    }
}
