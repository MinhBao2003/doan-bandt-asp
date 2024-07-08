namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTin")]
    public partial class ThongTin
    {
        [StringLength(300)]
        public string Ten { get; set; }

        [Key]
        [StringLength(1000)]
        public string noidung { get; set; }

        [StringLength(1300)]
        public string Hinh { get; set; }

        [StringLength(1300)]
        public string Hinh2 { get; set; }

        [StringLength(1300)]
        public string Hinh3 { get; set; }

        [StringLength(300)]
        public string NoiDung2 { get; set; }
    }
}
