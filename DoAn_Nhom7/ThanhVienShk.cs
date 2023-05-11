using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class ThanhVienShk
    {
        private string maShk;
        private string cmndChuHo;
        private string cmndThanhVien;
        private string quanHe;
        public string MaShk { get => maShk; set => maShk = value; }
        public string CmndChuHo { get => cmndChuHo; set => cmndChuHo = value; }
        public string CmndThanhVien { get => cmndThanhVien; set => cmndThanhVien = value; }
        public string QuanHe { get => quanHe; set => quanHe = value; }
        public ThanhVienShk()
        {

        }
        public ThanhVienShk(string maShk,  string cmndChuHo, string cmndThanhVien, string quanHe)
        {

            MaShk = maShk;
            CmndThanhVien = cmndThanhVien;
            QuanHe = quanHe;
            CmndChuHo = cmndChuHo;
        }
        ~ThanhVienShk()
        {

        }
    }
}
