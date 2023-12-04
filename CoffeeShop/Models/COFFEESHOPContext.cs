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

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Billdetail> Billdetails { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=COFFEESHOP;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PK__BILL__74108A90650E66B7");

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
                    .HasConstraintName("FK__BILL__ID_EM__403A8C7D");
            });

            modelBuilder.Entity<Billdetail>(entity =>
            {
                entity.HasKey(e => new { e.IdBill, e.Id })
                    .HasName("PK__BILLDETA__1731C452B02843F5");

                entity.ToTable("BILLDETAIL");

                entity.Property(e => e.IdBill).HasColumnName("ID_BILL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BILLDETAIL__ID__440B1D61");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BILLDETAI__ID_BI__4316F928");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEm)
                    .HasName("PK__EMPLOYEE__8B62DF49BAB60C0C");

                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.Username, "UQ__EMPLOYEE__B15BE12E282685E8")
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
                entity.Property(e => e.ImageData)
                    .HasColumnType("image")
                    .HasColumnName("IMAGE_DATA");
                entity.Property(e => e.Available).HasColumnName("AVAILABLE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IdType).HasColumnName("ID_TYPE");

                entity.Property(e => e.NameFood)
                    .HasMaxLength(200)
                    .HasColumnName("NAME_FOOD");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7, 0)")
                    .HasColumnName("PRICE");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK__MENU__ID_TYPE__3D5E1FD2");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("TYPE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Available).HasColumnName("AVAILABLE");

                entity.Property(e => e.Type1)
                    .HasMaxLength(100)
                    .HasColumnName("TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
