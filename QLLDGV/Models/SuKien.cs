//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLLDGV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuKien
    {
        public System.Guid MaSuKien { get; set; }
        public string TenHP { get; set; }
        public System.Guid Nhom { get; set; }
        public Nullable<System.Guid> GiaoVien { get; set; }
        public string TenSuKien { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
    
        public virtual GIAOVIEN GIAOVIEN1 { get; set; }
        public virtual HocPhan HocPhan { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
