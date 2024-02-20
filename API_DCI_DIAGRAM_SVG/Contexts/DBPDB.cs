using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class DBPDB : DbContext
    {
        public DBPDB()
        {
        }

        public DBPDB(DbContextOptions<DBPDB> options)
            : base(options)
        {
        }

        public virtual DbSet<AndonDatum> AndonData { get; set; } = null!;
        public virtual DbSet<BoardDatum> BoardData { get; set; } = null!;
        public virtual DbSet<DataLog> DataLogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.226.145;Database=dbPDB;TrustServerCertificate=True;uid=sa;password=decjapan");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<AndonDatum>(entity =>
            {
                entity.HasKey(e => new { e.BoardId, e.ModelCode });

                entity.HasIndex(e => e.BoardId, "NonClusteredIndex-20190204-145640");

                entity.HasIndex(e => new { e.Pddate, e.Pdshift }, "NonClusteredIndex-20190204-145650");

                entity.Property(e => e.BoardId)
                    .HasMaxLength(4)
                    .HasColumnName("BoardID");

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.BoardName).HasMaxLength(250);

                entity.Property(e => e.EndRun).HasColumnType("datetime");

                entity.Property(e => e.ModelChangeEndTime).HasColumnType("datetime");

                entity.Property(e => e.ModelChangeStartTime).HasColumnType("datetime");

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Pddate)
                    .HasColumnType("date")
                    .HasColumnName("PDDate");

                entity.Property(e => e.Pdshift)
                    .HasMaxLength(50)
                    .HasColumnName("PDShift");

                entity.Property(e => e.StartRun).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BoardDatum>(entity =>
            {
                entity.HasKey(e => e.BoardId);

                entity.Property(e => e.BoardId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CycleTimeDecimal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("CycleTime_Decimal");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastActive).HasColumnType("datetime");

                entity.Property(e => e.LastCycleTime).HasColumnType("datetime");

                entity.Property(e => e.LastLog).HasColumnType("datetime");

                entity.Property(e => e.MachineNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PdModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReadPlan)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStart).HasColumnType("datetime");

                entity.Property(e => e.RequestType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceEnd).HasColumnType("datetime");

                entity.Property(e => e.ServiceRequest)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceStart).HasColumnType("datetime");

                entity.Property(e => e.Shift)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Tempature)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalNg).HasColumnName("TotalNG");
            });

            modelBuilder.Entity<DataLog>(entity =>
            {
                entity.HasKey(e => new { e.LogTime, e.BoardId });

                entity.ToTable("DataLog");

                entity.HasIndex(e => e.BoardId, "IdxBoard");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.BoardId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BreakDown).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Plan).HasColumnName("Plan_");

                entity.Property(e => e.Shift)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
