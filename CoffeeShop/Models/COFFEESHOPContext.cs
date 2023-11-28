using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShop.Models
{
    public partial class COFFEESHOPContext : DbContext
    {
        public COFFEESHOPContext()
        {
        }

        public COFFEESHOPContext(DbContextOptions<COFFEESHOPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Loaimon> Loaimons { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=COFFEESHOP;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Mama })
                    .HasName("PK__CHITIETH__563CD650BD6234C7");

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Mama).HasColumnName("MAMA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHOA__MAHD__45F365D3");

                entity.HasOne(d => d.MamaNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Mama)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHOA__MAMA__46E78A0C");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__HOADON__603F20CE5F27138D");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahd)
                    .ValueGeneratedNever()
                    .HasColumnName("MAHD");

                entity.Property(e => e.Gia)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("GIA");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("date")
                    .HasColumnName("NGAYLAP");

                entity.Property(e => e.Tinhtrang)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TINHTRANG");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK__HOADON__MAKH__4316F928");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK__HOADON__MANV__4222D4EF");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KHACHHAN__603F592C51CACFCB");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh)
                    .ValueGeneratedNever()
                    .HasColumnName("MAKH");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(200)
                    .HasColumnName("HOTEN");
            });

            modelBuilder.Entity<Loaimon>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAIMON__2F633F23518B8EDC");

                entity.ToTable("LOAIMON");

                entity.Property(e => e.Maloai)
                    .ValueGeneratedNever()
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(100)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Mama)
                    .HasName("PK__MENU__603F69E21BD82987");

                entity.ToTable("MENU");

                entity.Property(e => e.Mama)
                    .ValueGeneratedNever()
                    .HasColumnName("MAMA");

                entity.Property(e => e.Gia)
                    .HasColumnType("decimal(7, 0)")
                    .HasColumnName("GIA");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Tenmonan)
                    .HasMaxLength(200)
                    .HasColumnName("TENMONAN");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__MENU__MALOAI__3D5E1FD2");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__603F5114A28FFD50");

                entity.ToTable("NHANVIEN");

                entity.HasIndex(e => e.Tendn, "UQ__NHANVIEN__A58D77814E39BFF6")
                    .IsUnique();

                entity.Property(e => e.Manv)
                    .ValueGeneratedNever()
                    .HasColumnName("MANV");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(200)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(3)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(200)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tendn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENDN");

                entity.Property(e => e.Tenvt)
                    .HasMaxLength(100)
                    .HasColumnName("TENVT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
