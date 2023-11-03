using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public partial class HRMContext : DbContext
    {
        public HRMContext()
        {
        }

        public HRMContext(DbContextOptions<HRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DvcdMstr> DvcdMstr { get; set; } = null!;
        public virtual DbSet<Emcl> Emcl { get; set; } = null!;
        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<HrTaff> HrTaff { get; set; } = null!;
        public virtual DbSet<LineMstr> LineMstr { get; set; } = null!;
        public virtual DbSet<OtrqReq> OtrqReq { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.226.86;Initial Catalog=dbHRM; Persist Security Info=True; Trust Server Certificate=true; User ID=sa;Password=decjapan;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DvcdMstr>(entity =>
            {
                entity.Property(e => e.SortNo).HasDefaultValueSql("((999))");
            });

            modelBuilder.Entity<Emcl>(entity =>
            {
                entity.HasKey(e => new { e.Ym, e.Code });
            });

            modelBuilder.Entity<HrTaff>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.TaffType, e.TaffRecord });
            });

            modelBuilder.Entity<OtrqReq>(entity =>
            {
                entity.HasKey(e => new { e.Odate, e.Rq, e.Code });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
