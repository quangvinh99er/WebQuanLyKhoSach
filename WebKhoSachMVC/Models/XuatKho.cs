//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebKhoSachMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class XuatKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XuatKho()
        {
            this.KiemKeKhoes = new HashSet<KiemKeKho>();
        }
    
        public int IdXKho { get; set; }
        public Nullable<System.DateTime> NgayXuat { get; set; }
        public int IdSach { get; set; }
        public Nullable<int> Soluongxuat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KiemKeKho> KiemKeKhoes { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
