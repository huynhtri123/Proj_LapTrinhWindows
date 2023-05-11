using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class ThanhVienShkDAO
    {
        DBConnection dbc = new DBConnection();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);

        public void ThietLapMoiQuanHeBoCon(ThanhVienShk tv)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con", "Bố");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bố", "Con");
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienShk tv)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Vợ", "Chồng");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Chồng", "Vợ");
                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Vo', quanHeVoiCMND2 = 'Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
        }
        public void ThietLapMoiQuanHeBoConDau(ThanhVienShk tv)
        {
            string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')",  tv.CmndThanhVien, tv.CmndChuHo, "Bố Chồng", "Con Dâu");

            //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void ThietLapMoiQuanHeOngChau(ThanhVienShk tv)
        {

                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Cháu", "Ông");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Ông", "Cháu");

                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            
        }
        public void ThietLapQuanHeGiaDinh(ThanhVienShk tv)
        {
            string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.MaShk+ "'");
            if (tv.QuanHe == "Con Dâu")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Con Trai" || b == "Con Gái") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Chị Dâu", "Em Rể");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Em Rể", "Chị Dâu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

                        else if (b == "Vợ")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Me Chồng");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ Chồng", "Con Dâu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Cháu")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Mự", "Cháu");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Cháu", "Mự");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

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
            else if (tv.QuanHe == "Cháu")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Con Trai") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Chú");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Con Gái" && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Dì");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Dì", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Vợ")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Bà");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Con Dâu" && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Mự");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mự", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
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
            else if (tv.QuanHe == "Con")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Bố"))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Ông");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Ông", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if ((b == "Mẹ") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Bà");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Anh Trai")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Chú");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Em Gái")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu", "Gì");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Gì", "Cháu");
                            dbc.XuLy1(sqlStr1);
                            dbc.XuLy1(sqlStr2);
                        }
                        else if ((b == "Vợ") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con", "Mẹ");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ", "Con");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
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
            else if (tv.QuanHe == "Vợ")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Bố"))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bố Chồng", "Con Dâu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if ((b == "Mẹ") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Mẹ Chồng");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ Chồng", "Con Dâu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Anh Trai" || b == "Em Gái")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Chị Dâu", "Em Rể");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Em Rể", "Chị Dâu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

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
        public void ThemThanhVien(ThanhVienShk tv)
        {
            if (tv.QuanHe == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else if(tv.QuanHe=="Vợ")
                ThietLapMoiQuanHeVoChong(tv);
            else if(tv.QuanHe == "Con Dâu")
                ThietLapMoiQuanHeBoConDau(tv);
            else if (tv.QuanHe == "Cháu")
                ThietLapMoiQuanHeOngChau(tv);
            ThietLapQuanHeGiaDinh(tv);
            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '{0}', '{1}', '{2}', quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}'", tv.MaShk,tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
        }
        public void SuaThanhVien(ThanhVienShk tv,string qh1)
        {
           string qh2 = "";
            if (qh1 == "Con")
                qh2 = "Bố";
            else if (qh1 == "Con Dau")
                qh2 = "Bo Chong";
            else
                qh2 = "Chong";
            string sqlStr = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = '"+qh1+"', quanHeVoiCMND2 = '"+qh2+"' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            string sqlStr1 = string.Format("UPDATE ThanhVienSoHoKhau SET quanHeVoiChuHo = (SELECT quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}') WHERE maSoHoKhau = '{0}' AND CmndChuHo = '{1}' AND CmndThanhVien = '{2}'", tv.MaShk, tv.CmndChuHo, tv.CmndThanhVien);

            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void XoaThanhVien(ThanhVienShk tv)
        {
           /* string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.MaShk + "'");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    string a = Convert.ToString(dta["CMNDThanhVien"]);
                    string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                    string sqlStr1 = string.Format("DELETE FROM QuanHe WHERE CMND1='{0}' AND CMND2 ='{1}' ", a, tv.CmndThanhVien);
                    string sqlStr2 = string.Format("DELETE FROM QuanHe WHERE CMND1='{0}' AND CMND2 ='{1}' ", tv.CmndThanhVien, a);
                    dbc.XuLy(sqlStr1);
                    dbc.XuLy(sqlStr2);
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

            string sqlStr4 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'",tv.CmndChuHo,tv.CmndThanhVien);
            string sqlStr5 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndThanhVien, tv.CmndChuHo);*/

            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy(sqlStr3);
            //dbc.XuLy(sqlStr4);
            //dbc.XuLy(sqlStr5);

        }
        public void DienThanhVienSHK(string cmnd, TextBox mashk, TextBox hoten, TextBox gioitinh, TextBox quanhe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd == '{0}'",cmnd);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    mashk.Text = Convert.ToString(dta["maSoHoKhau"]);
                    hoten.Text = Convert.ToString(dta["hoTen"]); ;
                    gioitinh.Text = Convert.ToString(dta["gioiTinh"]);
                    quanhe.Text = Convert.ToString(dta["quanHeVoiChuHo"]);
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
        public void ThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e, DataGridView dtgvThanhVienShk, TextBox cmndTv, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, TextBox quanHe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd = '{0}'", cmndTv.Text);
            dbc.ThanhVienShk_CellClick(sender, e, sqlStr, dtgvThanhVienShk, cmndTv, maShkTv, hoTenTv, gioiTinhTv, quanHe);
        }
    }
}
