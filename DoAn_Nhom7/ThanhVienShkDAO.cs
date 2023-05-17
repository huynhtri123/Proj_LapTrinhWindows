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

        public void ThietLapMoiQuanHeBoCon(ThanhVienShk tv,string quanhe)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, quanhe, "Bố");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bố", quanhe);
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
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))

            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bố Chồng", "Con Dâu");
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }

            //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);

        }
        public void ThietLapMoiQuanHeOngChau(ThanhVienShk tv,string quanhe)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))

            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndChuHo, tv.CmndThanhVien, quanhe, "Ông");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Ông", quanhe);

                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
            
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
                        if (dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Con Trai" || b == "Con Gái"))
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
            else if (tv.QuanHe == "Cháu Trai"|| tv.QuanHe == "Cháu Gái")
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
                        if (dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", tv.QuanHe);
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Con Gái")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Dì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Dì", tv.QuanHe);
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Vợ")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", tv.QuanHe);
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Con Dâu")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, tv.QuanHe, "Mự");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mự", tv.QuanHe);
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Cháu Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Cháu Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em ", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
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
            else if (tv.QuanHe == "Con Trai" )
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
                        if (dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Bố"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Ông");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Ông", "Cháu Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Mẹ") )
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Em Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Trai", "Gì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Gì", "Cháu Trai");
                                dbc.XuLy1(sqlStr1);
                                dbc.XuLy1(sqlStr2);
                            }
                            else if ((b == "Vợ") )
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Trai", "Mẹ");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ", "Con Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Trai", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Con Gái"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Trai", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em Trai");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
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
            else if (tv.QuanHe == "Con Gái")
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
                        if (dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if ((b == "Bố"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Ông");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Ông", "Cháu Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Mẹ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Bà");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bà", "Cháu Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Chú");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chú", "Cháu Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Em Gái")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Cháu Gái", "Gì");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Gì", "Cháu Gái");
                                dbc.XuLy1(sqlStr1);
                                dbc.XuLy1(sqlStr2);
                            }
                            else if ((b == "Vợ"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Gái", "Mẹ");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ", "Con Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Con Trai"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Gái", "Anh Trai");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Anh Trai", "Em Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if ((b == "Con Gái"))
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Em Gái", "Chị Gái");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Chị Gái", "Em Gái");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
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
                        if (dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {
                            if (b == "Bố")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Bố Chồng");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Bố Chồng", "Con Dâu");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Mẹ")
                            {

                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Con Dâu", "Mẹ Chồng");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Mẹ Chồng", "Con Dâu");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }
                            else if (b == "Anh Trai" || b == "Em Gái" || b == "Chị Gái" || b == "Em Trai")
                            {
                                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", a, tv.CmndThanhVien, "Chị Dâu", "Em Rể");
                                string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', N'{2}',N'{3}')", tv.CmndThanhVien, a, "Em Rể", "Chị Dâu");
                                dbc.XuLy(sqlStr1);
                                dbc.XuLy(sqlStr2);
                            }


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
        public void ThietLapQuanHe(ThanhVienShk tv)
        {
            if (tv.QuanHe == "Con Trai" || tv.QuanHe == "Con Gái")
                ThietLapMoiQuanHeBoCon(tv,tv.QuanHe);
            else if(tv.QuanHe=="Vợ")
                ThietLapMoiQuanHeVoChong(tv);
            else if(tv.QuanHe == "Con Dâu")
                ThietLapMoiQuanHeBoConDau(tv);
            else if (tv.QuanHe == "Cháu Trai" || tv.QuanHe == "Cháu Gái")
                ThietLapMoiQuanHeOngChau(tv,tv.QuanHe);
            ThietLapQuanHeGiaDinh(tv);
        }
        public void ThemThanhVien(ThanhVienShk tv)
        {

            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '{0}', '{1}', '{2}', quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}'", tv.MaShk, tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy1(sqlStr);
        }
        public void XoaTamThanhVien(ThanhVienShk tv)
        {
            string sqlStr4 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            string sqlStr5 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndThanhVien, tv.CmndChuHo); 
            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy1(sqlStr3);
            dbc.XuLy(sqlStr4);
            dbc.XuLy(sqlStr5);
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
            dbc.XuLy1(sqlStr3);
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
        public void ThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e, DataGridView dtgvThanhVienShk, TextBox cmndTv, TextBox maShkTv, TextBox hoTenTv, TextBox gioiTinhTv, ComboBox quanHe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd = '{0}'", cmndTv.Text);
            dbc.ThanhVienShk_CellClick(sender, e, sqlStr, dtgvThanhVienShk, cmndTv, maShkTv, hoTenTv, gioiTinhTv, quanHe);
        }
    }
}
