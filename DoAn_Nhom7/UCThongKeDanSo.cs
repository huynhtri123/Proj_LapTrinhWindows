using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_Nhom7
{
    public partial class UCThongKeDanSo : UserControl
    {
        ThongKeDAO tkDao = new ThongKeDAO();
        public UCThongKeDanSo()
        {
            InitializeComponent();
        }

        private void UCThongKeDanSo_Load(object sender, EventArgs e)
        {
            tkDao.XuLy(chartTyLeNamNu);
        }
    }
}
