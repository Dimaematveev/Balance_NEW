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
    
    public partial class AdditionalFieldForDevice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdditionalFieldForDevice()
        {
            this.DeviceWithAdditionalFields = new HashSet<DeviceWithAdditionalField>();
        }
    
        public int TypeOfDeviceID { get; set; }
        public int AdditionalFieldID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeviceWithAdditionalField> DeviceWithAdditionalFields { get; set; }
        public virtual AdditionalField AdditionalField { get; set; }
        public virtual TypeOfDevice TypeOfDevice { get; set; }
    }
}
