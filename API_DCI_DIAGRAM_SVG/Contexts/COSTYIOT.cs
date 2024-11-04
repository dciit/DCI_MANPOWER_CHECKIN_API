using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class COSTYIOT : DbContext
    {
        public COSTYIOT()
        {
        }

        public COSTYIOT(DbContextOptions<COSTYIOT> options)
            : base(options)
        {
        }

        public virtual DbSet<ScrGasTight> ScrGasTights { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=COSTY;Database=dbIoT;TrustServerCertificate=True;uid=sa;password=decjapan");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<ScrGasTight>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Serial })
                    .HasName("PK_SCR_N2Charge");

                entity.ToTable("SCR_GasTight");

                entity.HasIndex(e => new { e.Serial, e.InsertDate }, "IX_SCR_GasTight");

                entity.HasIndex(e => new { e.Serial, e.InsertBy }, "IX_SCR_GasTight_1");

                entity.HasIndex(e => new { e.InsertBy, e.Serial, e.InsertDate }, "IX_SCR_GasTight_2");

                entity.HasIndex(e => e.InsertDate, "NONCLS_IDX_SCR_GasTight_Insert_Date");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Serial).HasMaxLength(50);

                entity.Property(e => e.InsertBy)
                    .HasMaxLength(30)
                    .HasColumnName("Insert_By");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Insert_Date");

                entity.Property(e => e.ModelCode)
                    .HasMaxLength(50)
                    .HasColumnName("Model_Code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
