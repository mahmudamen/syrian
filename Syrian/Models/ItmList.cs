//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Syrian.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItmList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItmList()
        {
            this.orditm = new HashSet<orditm>();
        }
    
        public int ItemID { get; set; }
        public string ItmName { get; set; }
        public int ItmType { get; set; }
        public decimal ItmPrice { get; set; }
        public bool IsActive { get; set; }
    
        public virtual TypeList TypeList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orditm> orditm { get; set; }
    }
}
