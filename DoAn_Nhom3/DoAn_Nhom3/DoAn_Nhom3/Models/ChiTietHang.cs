namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHang")]
    public partial class ChiTietHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        [StringLength(50)]
        public string hinh1 { get; set; }

        [StringLength(50)]
        public string hinh2 { get; set; }

        [StringLength(50)]
        public string hinh3 { get; set; }

        [StringLength(1000)]
        public string TenSP { get; set; }

        [Key]
        [StringLength(1000)]
        public string Price { get; set; }

        [StringLength(1000)]
        public string About { get; set; }

        [StringLength(1000)]
        public string kichthuoc { get; set; }

        [StringLength(1000)]
        public string vatlieu { get; set; }

        [StringLength(100)]
        public string ma { get; set; }

        [StringLength(1000)]
        public string danhmuc { get; set; }

        [StringLength(1000)]
        public string Tags { get; set; }

        [StringLength(1000)]
        public string noidung { get; set; }
    }
}
