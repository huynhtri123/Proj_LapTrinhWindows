﻿using System;
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
    public partial class UCHonNhan : UserControl
    {
        public UCHonNhan()
        {
            InitializeComponent();
        }

        private void UCHonNhan_Load(object sender, EventArgs e)
        {

        }
        private void btnDangKyKetHon_Click(object sender, EventArgs e)
        {
            FDangKiKetHon dkkh = new FDangKiKetHon();
            dkkh.ShowDialog();
        }

        private void btnDangKyLyHon_Click(object sender, EventArgs e)
        {
            FDangKyLyHon frm = new FDangKyLyHon();
            frm.ShowDialog();
        }
    }
}
