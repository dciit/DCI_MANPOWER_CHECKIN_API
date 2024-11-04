using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class DBIOT : DbContext
    {
        public DBIOT()
        {
        }

        public DBIOT(DbContextOptions<DBIOT> options)
            : base(options)
        {
        }

        public virtual DbSet<ScrGasTight> ScrGasTights { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Costy;Database=dbIot;TrustServerCertificate=True;uid=sa;password=decjapan");
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

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Serial)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.InsertBy)
                    .HasMaxLength(30)
                    .HasColumnName("Insert_By");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Insert_Date");

                entity.Property(e => e.ModelCode)
                    .HasMaxLength(5)
                    .HasColumnName("Model_Code")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
