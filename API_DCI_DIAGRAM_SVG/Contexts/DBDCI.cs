using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class DBDCI : DbContext
    {
        public DBDCI()
        {
        }

        public DBDCI(DbContextOptions<DBDCI> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<LnsEquipment> LnsEquipment { get; set; } = null!;
        public virtual DbSet<LnsEquipmentCheckLog> LnsEquipmentCheckLog { get; set; } = null!;
        public virtual DbSet<LnsEquipmentMaster> LnsEquipmentMaster { get; set; } = null!;
        public virtual DbSet<LnsLayout> LnsLayout { get; set; } = null!;
        public virtual DbSet<TrLineProcess> TrLineProcess { get; set; } = null!;
        public virtual DbSet<ViTrTrainessLog> ViTrTrainessLog { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.226.145;Initial Catalog=dbDCI; Persist Security Info=True; Trust Server Certificate=true; User ID=sa;Password=decjapan;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<LnsEquipment>(entity =>
            {
                entity.HasKey(e => e.EqpId)
                    .HasName("PK_LNS_LAYOUT_MASTER");

                entity.Property(e => e.EqpPriority).ValueGeneratedOnAdd();

                entity.Property(e => e.EqpRotate).HasDefaultValueSql("((0))");

                entity.Property(e => e.EqpTrigger).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextYear).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LnsEquipmentMaster>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_LNS_OBJECT_MASTER");

                entity.Property(e => e.ObjMstNextDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextYear).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ViTrTrainessLog>(entity =>
            {
                entity.ToView("vi_TR_trainess_log");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
