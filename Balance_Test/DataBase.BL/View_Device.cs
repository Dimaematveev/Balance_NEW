namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dev.View_Device")]
    public partial class View_Device
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeviceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string GadgetName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string TypeName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string ModelName { get; set; }

        [StringLength(50)]
        public string SN { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SPID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(150)]
        public string SPRegisterNumber { get; set; }

        [StringLength(50)]
        public string SPDeal { get; set; }

        [StringLength(10)]
        public string SPPage { get; set; }

        public bool? SPIsSp { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SIID { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(150)]
        public string SIRegisterNumber { get; set; }

        [StringLength(50)]
        public string SIDeal { get; set; }

        [StringLength(10)]
        public string SIPage { get; set; }

        public bool? SIIsSp { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(255)]
        public string LocationName { get; set; }

        public bool? IsZip { get; set; }

        public bool? IsBroken { get; set; }
    }
}
