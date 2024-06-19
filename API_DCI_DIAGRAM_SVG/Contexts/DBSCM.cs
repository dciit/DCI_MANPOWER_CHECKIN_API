using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class DBSCM : DbContext
    {
        public DBSCM()
        {
        }

        public DBSCM(DbContextOptions<DBSCM> options)
            : base(options)
        {
        }

        public virtual DbSet<ViApsPartMaster> ViApsPartMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.226.86;Database=dbSCM;TrustServerCertificate=True;uid=sa;password=decjapan");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<ViApsPartMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_APS_PartMaster");

                entity.Property(e => e.Cm)
                    .HasMaxLength(1)
                    .HasColumnName("CM")
                    .IsFixedLength();

                entity.Property(e => e.Model)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.PartCode)
                    .HasMaxLength(50)
                    .HasColumnName("PART_CODE");

                entity.Property(e => e.PartNameCode)
                    .HasMaxLength(50)
                    .HasColumnName("PART_NAME_CODE");

                entity.Property(e => e.Partno)
                    .HasMaxLength(50)
                    .HasColumnName("PARTNO");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
