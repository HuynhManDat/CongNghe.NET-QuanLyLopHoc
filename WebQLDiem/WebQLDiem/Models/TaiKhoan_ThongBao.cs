//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLDiem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiKhoan_ThongBao
    {
        public int MaThongBao { get; set; }
        public Nullable<int> MaTaiKhoan { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
