namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dic.Sp_Si")]
    public partial class Sp_Si
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sp_Si()
        {
            Devices = new HashSet<Device>();
            Devices1 = new HashSet<Device>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string RegisterNumber { get; set; }

        [StringLength(50)]
        public string Deal { get; set; }

        [StringLength(10)]
        public string Page { get; set; }

        public bool? IsSp { get; set; }

        public bool IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices1 { get; set; }
    }
}
