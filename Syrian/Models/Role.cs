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
    
    public partial class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.TimeSpan CreatedTime { get; set; }
    }
}
