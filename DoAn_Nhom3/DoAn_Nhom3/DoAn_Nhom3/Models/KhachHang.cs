namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [StringLength(30)]
        public string HoTenKH { get; set; }

        [StringLength(39)]
        public string TaiKhoan { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        public int? Id_Quyen { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        public int Id_KhachHang { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
