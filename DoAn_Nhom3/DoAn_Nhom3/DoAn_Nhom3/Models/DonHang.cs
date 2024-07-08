namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [StringLength(30)]
        public string TenKhach { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        public int? id { get; set; }

        public int? TongTien { get; set; }

        public virtual Giohang Giohang { get; set; }

        public virtual ProductC ProductC { get; set; }
    }
}
