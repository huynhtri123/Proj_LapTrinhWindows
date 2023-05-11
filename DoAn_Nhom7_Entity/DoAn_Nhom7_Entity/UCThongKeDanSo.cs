using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn_Nhom7_Entity
{
    public partial class UCThongKeDanSo : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCThongKeDanSo()
        {
            InitializeComponent();
        }

        private void UCThongKeDanSo_Load(object sender, EventArgs e)
        {
            XuLyThongKeDanSo(chartTyLeNamNu);
        }
        public void XuLyThongKeDanSo(Chart chartTyLeNamNu)
        {
            var data = db.CongDans.GroupBy(c => c.gioiTinh).Select(g => new { gioiTinh = g.Key, soLuong = g.Count() }).ToList();
            chartTyLeNamNu.DataSource = data;
            chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].XValueMember = "gioiTinh";
            chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].YValueMembers = "soLuong";
        }

    }
}
