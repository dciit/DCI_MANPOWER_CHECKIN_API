using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class ManpowerContext : DbContext
    {
        public ManpowerContext()
        {
        }

        public ManpowerContext(DbContextOptions<ManpowerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DcrunNbr> DcrunNbr { get; set; } = null!;
        public virtual DbSet<MpckCheckInLog> MpckCheckInLog { get; set; } = null!;
        public virtual DbSet<MpckDictionary> MpckDictionary { get; set; } = null!;
        public virtual DbSet<MpckLayout> MpckLayout { get; set; } = null!;
        public virtual DbSet<MpckObject> MpckObject { get; set; } = null!;
        public virtual DbSet<MpckObjectMaster> MpckObjectMaster { get; set; } = null!;
        public virtual DbSet<SkcDictMstr> SkcDictMstr { get; set; } = null!;
        public virtual DbSet<SkcLicenseTraining> SkcLicenseTraining { get; set; } = null!;
        public virtual DbSet<ViMpckDictionary> ViMpckDictionary { get; set; } = null!;
        public virtual DbSet<ViMpckObjectList> ViMpckObjectList { get; set; } = null!;

        public virtual DbSet<SpDCRunNbr> SpDCRunNbr { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.226.86;Initial Catalog=dbSCM; Persist Security Info=True; Trust Server Certificate=true; User ID=sa;Password=decjapan;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<MpckDictionary>(entity =>
            {
                entity.HasKey(e => new { e.DictType, e.DictCode, e.DictRefCode });
            });

            modelBuilder.Entity<MpckLayout>(entity =>
            {
                entity.Property(e => e.UpdateDate).HasComment("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MpckObjectMaster>(entity =>
            {
                entity.HasKey(e => e.ObjMasterId)
                    .HasName("PK_LNS_OBJECT_MASTER");
            });

            modelBuilder.Entity<SkcLicenseTraining>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("PK_SKC_LicenseTraning");
            });

            modelBuilder.Entity<ViMpckDictionary>(entity =>
            {
                entity.ToView("vi_MPCK_Dictionary");
            });

            modelBuilder.Entity<ViMpckObjectList>(entity =>
            {
                entity.ToView("vi_MPCK_ObjectList");

                entity.Property(e => e.EmpName).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
