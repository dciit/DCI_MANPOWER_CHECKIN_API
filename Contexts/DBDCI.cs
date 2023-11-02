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

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<LnsEquipment> LnsEquipments { get; set; } = null!;
        public virtual DbSet<LnsEquipmentCheckLog> LnsEquipmentCheckLogs { get; set; } = null!;
        public virtual DbSet<LnsEquipmentMaster> LnsEquipmentMasters { get; set; } = null!;
        public virtual DbSet<LnsLayout> LnsLayouts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.226.145;Database=dbDCI;TrustServerCertificate=True;uid=sa;password=decjapan");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.Resign, "IX_Employee");

                entity.HasIndex(e => new { e.Costcenter, e.Resign }, "IX_Employee_1");

                entity.HasIndex(e => new { e.LineCode, e.Dvcd, e.Resign }, "IX_Employee_2");

                entity.HasIndex(e => new { e.Resign, e.Posit, e.Costcenter, e.Budgettype, e.LineCode, e.Dvcd }, "IX_Employee_3");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("CODE");

                entity.Property(e => e.Andon)
                    .HasMaxLength(500)
                    .HasColumnName("ANDON");

                entity.Property(e => e.AnnualcalDt)
                    .HasColumnType("date")
                    .HasColumnName("ANNUALCAL_DT");

                entity.Property(e => e.Birth)
                    .HasColumnType("date")
                    .HasColumnName("BIRTH");

                entity.Property(e => e.Budgettype)
                    .HasMaxLength(10)
                    .HasColumnName("BUDGETTYPE");

                entity.Property(e => e.Bus)
                    .HasMaxLength(50)
                    .HasColumnName("BUS");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .HasColumnName("COMPANY");

                entity.Property(e => e.Costcenter)
                    .HasMaxLength(50)
                    .HasColumnName("COSTCENTER");

                entity.Property(e => e.Dlrate)
                    .HasMaxLength(50)
                    .HasColumnName("DLRATE");

                entity.Property(e => e.Dvcd)
                    .HasMaxLength(10)
                    .HasColumnName("DVCD");

                entity.Property(e => e.Grpot)
                    .HasMaxLength(50)
                    .HasColumnName("GRPOT");

                entity.Property(e => e.Join)
                    .HasColumnType("date")
                    .HasColumnName("JOIN");

                entity.Property(e => e.LineCode).HasMaxLength(100);

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("MAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("NICKNAME");

                entity.Property(e => e.Otype)
                    .HasMaxLength(50)
                    .HasColumnName("OTYPE");

                entity.Property(e => e.PGrade)
                    .HasMaxLength(10)
                    .HasColumnName("P_GRADE");

                entity.Property(e => e.PRank)
                    .HasMaxLength(10)
                    .HasColumnName("P_RANK");

                entity.Property(e => e.Posit)
                    .HasMaxLength(50)
                    .HasColumnName("POSIT");

                entity.Property(e => e.Pren)
                    .HasMaxLength(50)
                    .HasColumnName("PREN");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.Resign)
                    .HasColumnType("date")
                    .HasColumnName("RESIGN");

                entity.Property(e => e.Rstype)
                    .HasMaxLength(50)
                    .HasColumnName("RSTYPE");

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .HasColumnName("SEX");

                entity.Property(e => e.Stop)
                    .HasMaxLength(50)
                    .HasColumnName("STOP");

                entity.Property(e => e.Surn)
                    .HasMaxLength(200)
                    .HasColumnName("SURN");

                entity.Property(e => e.Tcaddr3)
                    .HasMaxLength(50)
                    .HasColumnName("TCADDR3");

                entity.Property(e => e.Tcaddr4)
                    .HasMaxLength(50)
                    .HasColumnName("TCADDR4");

                entity.Property(e => e.Tctel)
                    .HasMaxLength(50)
                    .HasColumnName("TCTEL");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .HasColumnName("TELEPHONE");

                entity.Property(e => e.Tname)
                    .HasMaxLength(200)
                    .HasColumnName("TNAME");

                entity.Property(e => e.TposijoinDt)
                    .HasColumnType("date")
                    .HasColumnName("TPOSIJOIN_DT");

                entity.Property(e => e.Tposiname)
                    .HasMaxLength(150)
                    .HasColumnName("TPOSINAME");

                entity.Property(e => e.Tpren)
                    .HasMaxLength(20)
                    .HasColumnName("TPREN");

                entity.Property(e => e.Tsex)
                    .HasMaxLength(20)
                    .HasColumnName("TSEX");

                entity.Property(e => e.Tsurn)
                    .HasMaxLength(200)
                    .HasColumnName("TSURN");

                entity.Property(e => e.Workcenter)
                    .HasMaxLength(10)
                    .HasColumnName("WORKCENTER");

                entity.Property(e => e.Wsts)
                    .HasMaxLength(50)
                    .HasColumnName("WSTS");

                entity.Property(e => e.Wtype)
                    .HasMaxLength(50)
                    .HasColumnName("WTYPE");
            });

            modelBuilder.Entity<LnsEquipment>(entity =>
            {
                entity.HasKey(e => e.EqpId)
                    .HasName("PK_LNS_LAYOUT_MASTER");

                entity.ToTable("LNS_Equipment");

                entity.Property(e => e.EqpId)
                    .HasMaxLength(50)
                    .HasColumnName("EQP_ID");

                entity.Property(e => e.EqpH).HasColumnName("EQP_H");

                entity.Property(e => e.EqpLastCheckBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EQP_LastCheckBy");

                entity.Property(e => e.EqpLastCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EQP_LastCheckDT");

                entity.Property(e => e.EqpNextCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EQP_NextCheckDT");

                entity.Property(e => e.EqpPriority)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EQP_PRIORITY");

                entity.Property(e => e.EqpRemark)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EQP_Remark");

                entity.Property(e => e.EqpRotate)
                    .HasColumnName("EQP_Rotate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EqpScale).HasColumnName("EQP_Scale");

                entity.Property(e => e.EqpStartCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EQP_StartCheckDT");

                entity.Property(e => e.EqpStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EQP_Status");

                entity.Property(e => e.EqpSubTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EQP_SubTitle");

                entity.Property(e => e.EqpTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EQP_Title");

                entity.Property(e => e.EqpTrigger)
                    .HasColumnName("EQP_Trigger")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EqpW).HasColumnName("EQP_W");

                entity.Property(e => e.EqpX).HasColumnName("EQP_X");

                entity.Property(e => e.EqpY).HasColumnName("EQP_Y");

                entity.Property(e => e.Factory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Layout)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LayoutCode)
                    .HasMaxLength(50)
                    .HasColumnName("LAYOUT_CODE");

                entity.Property(e => e.ObjId)
                    .HasMaxLength(50)
                    .HasColumnName("OBJ_ID");

                entity.Property(e => e.ObjMstNextDay)
                    .HasColumnName("OBJ_MstNextDay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextMonth)
                    .HasColumnName("OBJ_MstNextMonth")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextYear)
                    .HasColumnName("OBJ_MstNextYear")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LnsEquipmentCheckLog>(entity =>
            {
                entity.HasKey(e => e.Nbr);

                entity.ToTable("LNS_Equipment_Check_Log");

                entity.HasIndex(e => e.EqpCheckDt, "IX_LNS_Equipment_Check_Log");

                entity.HasIndex(e => e.EqpStatus, "IX_LNS_Equipment_Check_Log_1");

                entity.HasIndex(e => new { e.EqpStatus, e.EqpCheckDt, e.EqpCheckBy }, "IX_LNS_Equipment_Check_Log_2");

                entity.Property(e => e.Nbr).HasMaxLength(50);

                entity.Property(e => e.EqpCheckBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EQP_CheckBy");

                entity.Property(e => e.EqpCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EQP_CheckDT");

                entity.Property(e => e.EqpId)
                    .HasMaxLength(50)
                    .HasColumnName("EQP_ID");

                entity.Property(e => e.EqpNextCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EQP_NextCheckDT");

                entity.Property(e => e.EqpRemark)
                    .HasMaxLength(150)
                    .HasColumnName("EQP_Remark");

                entity.Property(e => e.EqpStatus)
                    .HasMaxLength(50)
                    .HasColumnName("EQP_Status");
            });

            modelBuilder.Entity<LnsEquipmentMaster>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_LNS_OBJECT_MASTER");

                entity.ToTable("LNS_Equipment_MASTER");

                entity.Property(e => e.ObjId)
                    .HasMaxLength(50)
                    .HasColumnName("OBJ_ID");

                entity.Property(e => e.ObjH).HasColumnName("OBJ_H");

                entity.Property(e => e.ObjMstNextDay)
                    .HasColumnName("OBJ_MstNextDay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextMonth)
                    .HasColumnName("OBJ_MstNextMonth")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjMstNextYear)
                    .HasColumnName("OBJ_MstNextYear")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjName)
                    .HasMaxLength(50)
                    .HasColumnName("OBJ_NAME");

                entity.Property(e => e.ObjSvg)
                    .HasColumnType("text")
                    .HasColumnName("OBJ_SVG");

                entity.Property(e => e.ObjW).HasColumnName("OBJ_W");
            });

            modelBuilder.Entity<LnsLayout>(entity =>
            {
                entity.HasKey(e => e.LayoutCode);

                entity.ToTable("LNS_Layout");

                entity.Property(e => e.LayoutCode)
                    .HasMaxLength(50)
                    .HasColumnName("LAYOUT_CODE");

                entity.Property(e => e.LayoutHeight).HasColumnName("LAYOUT_HEIGHT");

                entity.Property(e => e.LayoutName)
                    .HasMaxLength(150)
                    .HasColumnName("LAYOUT_NAME");

                entity.Property(e => e.LayoutWidth).HasColumnName("LAYOUT_WIDTH");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
