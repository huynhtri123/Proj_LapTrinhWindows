//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_Nhom7_Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThanhVienSoHoKhau
    {
        public string maSoHoKhau { get; set; }
        public string CMNDChuHo { get; set; }
        public string CMNDThanhVien { get; set; }
        public string quanHeVoiChuHo { get; set; }
    
        public virtual CongDan CongDan { get; set; }
        public virtual QuanHe QuanHe { get; set; }
        public virtual SoHoKhau SoHoKhau { get; set; }
    }
}
