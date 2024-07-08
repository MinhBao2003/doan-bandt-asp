namespace DoAn_Nhom3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(30)]
        public string HoTenAD { get; set; }

        [StringLength(39)]
        public string TaiKhoan { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        public int? Id_Quyen { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Admin { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
