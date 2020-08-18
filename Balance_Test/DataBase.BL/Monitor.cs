namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dev.Monitor")]
    public partial class Monitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeviceID { get; set; }

        [StringLength(50)]
        public string ScreenResolution { get; set; }

        public virtual Device Device { get; set; }
    }
}
