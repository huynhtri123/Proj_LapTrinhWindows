using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    internal class SoHoKhau
    {
        private string maSoHoKhau;
        private string cmnd;
        private string maKV;
        private string xaPhuong;
        private string quanHuyen;
        private string tinhTP;
        private string diaChi;
        private string ngayLap;

        public string MaKV
        { get { return this.maKV; } set { this.maKV = value; } }
        public string XaPhuong
        { get { return this.xaPhuong; } set { this.xaPhuong = value; } }
        public string QuanHuyen
        { get { return this.quanHuyen; } set { this.quanHuyen = value; } }
        public string TinhThanhPho
        { get { return this.tinhTP; } set { this.tinhTP = value; } }
        public string CMND
        { get { return this.cmnd; } set { this.cmnd = value; } }
        public string MaSoHoKhau
        { get { return this.maSoHoKhau; } set { this.maSoHoKhau = value; } }
        public string DiaChi
        { get { return this.diaChi; } set { this.diaChi = value; } }
        public string NgayLap
        { get { return this.ngayLap; } set { this.ngayLap = value; } }
        public SoHoKhau()
        {

        }
        public SoHoKhau(string maSoHoKhau, string cmnd, string maKV, string xaPhuong, string quanHuyen, string tinhTP, string diaChi, string ngayLap)
        {
            this.MaKV = maKV;
            this.XaPhuong = xaPhuong;
            this.QuanHuyen = quanHuyen;
            this.TinhThanhPho = tinhTP;
            this.CMND = cmnd;
            this.MaSoHoKhau = maSoHoKhau;
            this.DiaChi = diaChi;
            this.NgayLap = ngayLap;

        }
    }
}

