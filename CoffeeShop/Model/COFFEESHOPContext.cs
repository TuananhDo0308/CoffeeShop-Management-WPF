using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShop.Model
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

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Billdetail> Billdetails { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=COFFEESHOP;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PK__BILL__74108A90C28B4896");

                entity.ToTable("BILL");

                entity.Property(e => e.IdBill)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_BILL");

                entity.Property(e => e.DayBill)
                    .HasColumnType("date")
                    .HasColumnName("DAY_BILL");

                entity.Property(e => e.IdEm).HasColumnName("ID_EM");

                entity.Property(e => e.NameCustomer)
                    .HasMaxLength(200)
                    .HasColumnName("NAME_CUSTOMER");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.StatusBill)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_BILL");

                entity.HasOne(d => d.IdEmNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdEm)
                    .HasConstraintName("FK__BILL__ID_EM__3D5E1FD2");
            });

            modelBuilder.Entity<Billdetail>(entity =>
            {
                entity.HasKey(e => new { e.IdBill, e.Id })
                    .HasName("PK__BILLDETA__1731C452831D0FC7");

                entity.ToTable("BILLDETAIL");

                entity.Property(e => e.IdBill).HasColumnName("ID_BILL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BILLDETAIL__ID__412EB0B6");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BILLDETAI__ID_BI__403A8C7D");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEm)
                    .HasName("PK__EMPLOYEE__8B62DF49FA2F977B");

                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.Username, "UQ__EMPLOYEE__B15BE12E4C0C4C9F")
                    .IsUnique();

                entity.Property(e => e.IdEm)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_EM");

                entity.Property(e => e.AddressEm)
                    .HasMaxLength(4000)
                    .HasColumnName("ADDRESS_EM");

                entity.Property(e => e.DayOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("DAY_OF_BIRTH");

                entity.Property(e => e.ImageData)
                    .HasColumnType("image")
                    .HasColumnName("IMAGE_DATA");

                entity.Property(e => e.NameEm)
                    .HasMaxLength(4000)
                    .HasColumnName("NAME_EM");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(100)
                    .HasColumnName("NAME_ROLE");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASS");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUM");

                entity.Property(e => e.Sex)
                    .HasMaxLength(3)
                    .HasColumnName("SEX");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("MENU");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Available).HasColumnName("AVAILABLE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImageData)
                    .HasColumnType("image")
                    .HasColumnName("IMAGE_DATA");

                entity.Property(e => e.NameFood)
                    .HasMaxLength(200)
                    .HasColumnName("NAME_FOOD");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7, 0)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasColumnName("TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
