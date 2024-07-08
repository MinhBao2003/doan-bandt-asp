namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [StringLength(300)]
        public string NoiDungbl { get; set; }

        [Key]
        [StringLength(300)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Tenbl { get; set; }
    }
}
