namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inf.Repair")]
    public partial class Repair
    {
        public int ID { get; set; }

        public int ResultID { get; set; }

        [StringLength(100)]
        public string NumberZ { get; set; }

        public DateTime? DateBeginZ { get; set; }

        public DateTime? DateEndZ { get; set; }

        public DateTime? DateOut { get; set; }

        public DateTime? DateIn { get; set; }

        public bool? SpSiFlag { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Result Result { get; set; }
    }
}
