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
    
    public partial class ThongBao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongBao()
        {
            this.ThongBao_NhanXet = new HashSet<ThongBao_NhanXet>();
            this.ThongBaoTepDinhKems = new HashSet<ThongBaoTepDinhKem>();
            this.HocViens = new HashSet<HocVien>();
        }
    
        public int MaThongBao { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> NguoiTao { get; set; }
        public Nullable<int> MaLopHoc { get; set; }
    
        public virtual LopHoc LopHoc { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao_NhanXet> ThongBao_NhanXet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBaoTepDinhKem> ThongBaoTepDinhKems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocViens { get; set; }
    }
}
