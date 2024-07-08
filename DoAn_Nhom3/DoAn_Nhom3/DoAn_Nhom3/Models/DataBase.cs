using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn_Nhom3.Models
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChiTietHang> ChiTietHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Giohang> Giohangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ProductC> ProductCs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<ThongTin> ThongTins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<ProductC>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
