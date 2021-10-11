using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmartQuote.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbRedbookSmt> TbRedbookSmts { get; set; }
        public virtual DbSet<TbTariff> TbTariffs { get; set; }
        public virtual DbSet<TbTitle> TbTitles { get; set; }
        public virtual DbSet<VwVehiclebrand> VwVehiclebrands { get; set; }
        public virtual DbSet<VwVehiclemodel> VwVehiclemodels { get; set; }
        public virtual DbSet<VwVehiclesubmodel> VwVehiclesubmodels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.132.158.31;Initial Catalog=DB_SmartMotor;Persist Security Info=True;User ID=WEBAppDB;Password=Fci@WEB*1709");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<TbRedbookSmt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_RedbookSMT");

                entity.Property(e => e.Car2Hand).HasMaxLength(255);

                entity.Property(e => e.Cartype).HasMaxLength(255);

                entity.Property(e => e.Cc)
                    .HasMaxLength(255)
                    .HasColumnName("CC");

                entity.Property(e => e.Doors).HasMaxLength(255);

                entity.Property(e => e.Group).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasMaxLength(255);

                entity.Property(e => e.Kg).HasMaxLength(255);

                entity.Property(e => e.Make).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.NewPrice).HasMaxLength(255);

                entity.Property(e => e.Seats).HasMaxLength(255);

                entity.Property(e => e.SubModel).HasMaxLength(255);

                entity.Property(e => e.Vmicode)
                    .HasMaxLength(255)
                    .HasColumnName("VMICODE");

                entity.Property(e => e.YearModel).HasMaxLength(255);
            });

            modelBuilder.Entity<TbTariff>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Tariff");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Age1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ap)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("AP");

                entity.Property(e => e.Base).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cc)
                    .HasMaxLength(50)
                    .HasColumnName("CC");

                entity.Property(e => e.DD)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("D/D");

                entity.Property(e => e.Device)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Duty).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.F16).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.FirstPremium)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("%First Premium");

                entity.Property(e => e.FirstPremium1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("%First Premium1");

                entity.Property(e => e.FirstPremium2)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("First Premium");

                entity.Property(e => e.FirstPremiumภาษ)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("First Premium ภาษี");

                entity.Property(e => e.FirstPremiumอากร)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("First Premium อากร");

                entity.Property(e => e.FirstPremiumเบยรวม)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("First Premium เบี้ยรวม");

                entity.Property(e => e.Fleet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fleet %");

                entity.Property(e => e.Fleet1).HasColumnName("Fleet");

                entity.Property(e => e.GarageType)
                    .HasMaxLength(50)
                    .HasColumnName("Garage_Type");

                entity.Property(e => e.GroupEquip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Group_ Equip");

                entity.Property(e => e.Months)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("%Months");

                entity.Property(e => e.Named)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ncb)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCB %");

                entity.Property(e => e.Ncb1).HasColumnName("NCB");

                entity.Property(e => e.Net1)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Net (1)");

                entity.Property(e => e.Net2)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Net (2)");

                entity.Property(e => e.Net3)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Net (3)");

                entity.Property(e => e.Net4)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Net (4)");

                entity.Property(e => e.NetPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Net Premium");

                entity.Property(e => e.Other)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Other %");

                entity.Property(e => e.Other1).HasColumnName("Other");

                entity.Property(e => e.OtherDiscount)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("otherDiscount");

                entity.Property(e => e.PerKm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("%per km");

                entity.Property(e => e.PremiumPerKm)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium per km");

                entity.Property(e => e.Si)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SI");

                entity.Property(e => e.Tax).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Total Premium");

                entity.Property(e => e.Tpbi)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("TPBI");

                entity.Property(e => e.Tppd)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("TPPD");

                entity.Property(e => e.TypeCar)
                    .HasMaxLength(100)
                    .HasColumnName("Type Car");

                entity.Property(e => e.Use)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleCode).HasColumnName("Vehicle_Code");
            });

            modelBuilder.Entity<TbTitle>(entity =>
            {
                entity.HasKey(e => e.TitleCode);

                entity.ToTable("TB_Titles");

                entity.Property(e => e.TitleCode)
                    .ValueGeneratedNever()
                    .HasColumnName("Title_Code");

                entity.Property(e => e.TitleDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Title_Desc");
            });

            modelBuilder.Entity<VwVehiclebrand>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_vehiclebrand");

                entity.Property(e => e.Make).HasMaxLength(255);
            });

            modelBuilder.Entity<VwVehiclemodel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_vehiclemodel");

                entity.Property(e => e.Make).HasMaxLength(255);

                entity.Property(e => e.ModelCode).HasMaxLength(511);

                entity.Property(e => e.ModelDesc).HasMaxLength(255);
            });

            modelBuilder.Entity<VwVehiclesubmodel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_vehiclesubmodel");

                entity.Property(e => e.Make).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.SubModel).HasMaxLength(1023);

                entity.Property(e => e.SubModelDesc).HasMaxLength(513);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
