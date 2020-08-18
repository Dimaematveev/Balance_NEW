namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dev.Device")]
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            Results = new HashSet<Result>();
        }

        public int ID { get; set; }

        public int ModelID { get; set; }

        [StringLength(50)]
        public string SN { get; set; }

        public int Year { get; set; }

        public int SpID { get; set; }

        public int SiID { get; set; }

        public int LocationID { get; set; }

        public bool? IsZip { get; set; }

        public bool? IsBroken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        public virtual Location Location { get; set; }

        public virtual Model Model { get; set; }

        public virtual Sp_Si Sp_Si { get; set; }

        public virtual Sp_Si Sp_Si1 { get; set; }

        public virtual Monitor Monitor { get; set; }

        public virtual Printer Printer { get; set; }
    }
}
