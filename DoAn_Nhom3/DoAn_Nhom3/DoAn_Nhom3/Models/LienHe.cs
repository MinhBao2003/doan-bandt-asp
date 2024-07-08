namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        [StringLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Tenlienhe { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }
    }
}
