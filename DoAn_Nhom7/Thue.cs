using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class Thue
    {
        private string cccd;
        private string loaiThue;
        private double mucThue;
        private string tinhTrang;
        public string LoaiThue
        {
            get { return this.loaiThue; }
            set { this.loaiThue = value; }
        }
        public double MucThue
        {
            get { return this.mucThue; }
            set { this.mucThue = value; }
        }
        public string TinhTrang
        {
            get { return this.tinhTrang; }
            set { this.tinhTrang = value; }
        }
        public string CCCD
        {
            get { return this.cccd; }
            set { this.cccd = value; }
        }
        public Thue()
        {

        }
        public Thue(string cccd, string loaiThue, double mucThue, string tinhTrang)
        {
            this.CCCD = cccd;
            this.LoaiThue = loaiThue;
            this.MucThue = mucThue;
            this.TinhTrang = tinhTrang;
        }
        public Thue(string cccd)
        {
            this.CCCD = cccd;
        }
        ~Thue()
        {

        }
    }
}
