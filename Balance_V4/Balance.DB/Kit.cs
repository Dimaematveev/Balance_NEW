//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Balance.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kit()
        {
            this.Devices = new HashSet<Device>();
        }
    
        public int IDKit { get; set; }
        public string Name { get; set; }
    
        public virtual KitLoction KitLoction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
