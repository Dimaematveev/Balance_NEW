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
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.DeviceWithAdditionalFields = new HashSet<DeviceWithAdditionalField>();
        }
    
        public int IDDevice { get; set; }
        public int ModelOfDeviceID { get; set; }
        public string SerialNumber { get; set; }
    
        public virtual ModelOfDevice ModelOfDevice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeviceWithAdditionalField> DeviceWithAdditionalFields { get; set; }
        public virtual Kit Kit { get; set; }

        public override string ToString()
        {
            return SerialNumber;
        }
    }
}
