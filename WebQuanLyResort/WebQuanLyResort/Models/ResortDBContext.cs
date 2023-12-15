using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebQuanLyResort.Models
{
    public partial class ResortDBContext : DbContext
    {
        public ResortDBContext()
            : base("name=ResortDBContext")
        {
        }

        public virtual DbSet<datphong> datphongs { get; set; }
        public virtual DbSet<dichvu> dichvus { get; set; }
        public virtual DbSet<doiphong> doiphongs { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<khachsan> khachsans { get; set; }
        public virtual DbSet<loaiphong> loaiphongs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<phong> phongs { get; set; }
        public virtual DbSet<quyen> quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThaoTacDatPhong> ThaoTacDatPhongs { get; set; }
        public virtual DbSet<thietbi> thietbis { get; set; }
        public virtual DbSet<chitietsudungdv> chitietsudungdvs { get; set; }
        public virtual DbSet<chitietsudungtb> chitietsudungtbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<datphong>()
                .Property(e => e.id_datphong)
                .IsUnicode(false);

            modelBuilder.Entity<datphong>()
                .Property(e => e.id_nhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<datphong>()
                .Property(e => e.id_khachhang)
                .IsUnicode(false);

            modelBuilder.Entity<datphong>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<datphong>()
                .HasMany(e => e.chitietsudungdvs)
                .WithRequired(e => e.datphong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<datphong>()
                .HasMany(e => e.chitietsudungtbs)
                .WithRequired(e => e.datphong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<datphong>()
                .HasMany(e => e.hoadons)
                .WithRequired(e => e.datphong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dichvu>()
                .Property(e => e.id_dichvu)
                .IsUnicode(false);

            modelBuilder.Entity<dichvu>()
                .HasMany(e => e.chitietsudungdvs)
                .WithRequired(e => e.dichvu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<doiphong>()
                .Property(e => e.id_phong_bandau)
                .IsUnicode(false);

            modelBuilder.Entity<doiphong>()
                .Property(e => e.id_phong_doiphong)
                .IsUnicode(false);

            modelBuilder.Entity<doiphong>()
                .Property(e => e.id_nhanvien_thuchien)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_datphong)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_nhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_khachhang)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.id_khachhang)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.cmnd)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .HasMany(e => e.datphongs)
                .WithRequired(e => e.khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .HasMany(e => e.hoadons)
                .WithRequired(e => e.khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachsan>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<loaiphong>()
                .HasMany(e => e.phongs)
                .WithRequired(e => e.loaiphong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.id_nhanvien)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.ten_dang_nhap)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .Property(e => e.mat_khau)
                .IsUnicode(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.datphongs)
                .WithRequired(e => e.nhanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.doiphongs)
                .WithRequired(e => e.nhanvien)
                .HasForeignKey(e => e.id_nhanvien_thuchien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.hoadons)
                .WithRequired(e => e.nhanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phong>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<phong>()
                .Property(e => e.DienTich)
                .IsUnicode(false);

            modelBuilder.Entity<phong>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<phong>()
                .HasMany(e => e.datphongs)
                .WithRequired(e => e.phong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<quyen>()
                .HasMany(e => e.nhanviens)
                .WithRequired(e => e.quyen1)
                .HasForeignKey(e => e.quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThaoTacDatPhong>()
                .Property(e => e.id_khachhang)
                .IsUnicode(false);

            modelBuilder.Entity<ThaoTacDatPhong>()
                .Property(e => e.id_nhanvien_datphong)
                .IsUnicode(false);

            modelBuilder.Entity<ThaoTacDatPhong>()
                .Property(e => e.id_nhanvien_thuchien)
                .IsUnicode(false);

            modelBuilder.Entity<ThaoTacDatPhong>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<thietbi>()
                .Property(e => e.id_thietbi)
                .IsUnicode(false);

            modelBuilder.Entity<thietbi>()
                .HasMany(e => e.chitietsudungtbs)
                .WithRequired(e => e.thietbi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<chitietsudungdv>()
                .Property(e => e.id_datphong)
                .IsUnicode(false);

            modelBuilder.Entity<chitietsudungdv>()
                .Property(e => e.id_dichvu)
                .IsUnicode(false);

            modelBuilder.Entity<chitietsudungtb>()
                .Property(e => e.id_datphong)
                .IsUnicode(false);

            modelBuilder.Entity<chitietsudungtb>()
                .Property(e => e.id_thietbi)
                .IsUnicode(false);
        }
    }
}
