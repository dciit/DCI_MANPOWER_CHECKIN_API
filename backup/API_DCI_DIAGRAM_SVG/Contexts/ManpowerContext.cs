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

        public virtual DbSet<DcrunNbr> DcrunNbrs { get; set; } = null!;
        public virtual DbSet<MpckCheckInLog> MpckCheckInLogs { get; set; } = null!;
        public virtual DbSet<MpckDictionary> MpckDictionaries { get; set; } = null!;
        public virtual DbSet<MpckLayout> MpckLayouts { get; set; } = null!;
        public virtual DbSet<MpckObject> MpckObjects { get; set; } = null!;
        public virtual DbSet<MpckObjectMaster> MpckObjectMasters { get; set; } = null!;
        public virtual DbSet<SkcCheckInOutLog> SkcCheckInOutLogs { get; set; } = null!;
        public virtual DbSet<SkcDictMstr> SkcDictMstrs { get; set; } = null!;
        public virtual DbSet<SkcLicenseTraining> SkcLicenseTrainings { get; set; } = null!;
        public virtual DbSet<SkcPrivilege> SkcPrivileges { get; set; } = null!;
        public virtual DbSet<SkcUserInRole> SkcUserInRoles { get; set; } = null!;
        public virtual DbSet<ViMpckCheckInOutLog> ViMpckCheckInOutLogs { get; set; } = null!;
        public virtual DbSet<ViMpckDictionary> ViMpckDictionaries { get; set; } = null!;
        public virtual DbSet<ViMpckObjectList> ViMpckObjectLists { get; set; } = null!;

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

            modelBuilder.Entity<DcrunNbr>(entity =>
            {
                entity.HasKey(e => e.FormatId);

                entity.ToTable("DCRunNbr");

                entity.Property(e => e.ActiveDate).HasColumnType("datetime");

                entity.Property(e => e.DocKey).HasMaxLength(25);

                entity.Property(e => e.DocPrefix).HasMaxLength(25);

                entity.Property(e => e.NextId).HasColumnName("NextID");

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.ResetOption).HasMaxLength(25);
            });

            modelBuilder.Entity<MpckCheckInLog>(entity =>
            {
                entity.HasKey(e => e.Nbr);

                entity.ToTable("MPCK_CheckInLog");

                entity.HasIndex(e => new { e.ObjCode, e.Ckdate, e.Cktype }, "IX_MPCK_CheckInLog");

                entity.HasIndex(e => new { e.ObjCode, e.CkdateTime, e.Cktype }, "IX_MPCK_CheckInLog_1");

                entity.Property(e => e.Nbr).HasMaxLength(50);

                entity.Property(e => e.Ckdate)
                    .HasMaxLength(8)
                    .HasColumnName("CKDate");

                entity.Property(e => e.CkdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CKDateTime");

                entity.Property(e => e.Ckshift)
                    .HasMaxLength(5)
                    .HasColumnName("CKShift");

                entity.Property(e => e.Cktype)
                    .HasMaxLength(10)
                    .HasColumnName("CKType");

                entity.Property(e => e.EmpCode).HasMaxLength(5);

                entity.Property(e => e.ObjCode)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_Code");
            });

            modelBuilder.Entity<MpckDictionary>(entity =>
            {
                entity.HasKey(e => new { e.DictType, e.DictCode, e.DictRefCode });

                entity.ToTable("MPCK_Dictionary");

                entity.HasIndex(e => e.DictType, "IX_MPCK_Dictionary");

                entity.HasIndex(e => new { e.DictType, e.DictRefCode }, "IX_MPCK_Dictionary_1");

                entity.Property(e => e.DictType)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_Type");

                entity.Property(e => e.DictCode)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_Code");

                entity.Property(e => e.DictRefCode)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_RefCode");

                entity.Property(e => e.DictName)
                    .HasMaxLength(250)
                    .HasColumnName("Dict_Name");

                entity.Property(e => e.DictRefCode2)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_RefCode2");

                entity.Property(e => e.DictRefName)
                    .HasMaxLength(250)
                    .HasColumnName("Dict_RefName");

                entity.Property(e => e.DictRefSubName)
                    .HasMaxLength(250)
                    .HasColumnName("Dict_RefSubName");

                entity.Property(e => e.DictSubName)
                    .HasMaxLength(250)
                    .HasColumnName("Dict_SubName");
            });

            modelBuilder.Entity<MpckLayout>(entity =>
            {
                entity.HasKey(e => e.LayoutCode);

                entity.ToTable("MPCK_Layout");

                entity.HasIndex(e => new { e.Factory, e.Line, e.SubLine }, "IX_MPCK_Layout");

                entity.Property(e => e.LayoutCode).HasMaxLength(20);

                entity.Property(e => e.BypassMq)
                    .HasMaxLength(10)
                    .HasColumnName("BypassMQ");

                entity.Property(e => e.BypassSa)
                    .HasMaxLength(10)
                    .HasColumnName("BypassSA");

                entity.Property(e => e.Factory).HasMaxLength(10);

                entity.Property(e => e.LayoutName).HasMaxLength(50);

                entity.Property(e => e.LayoutStatus).HasMaxLength(10);

                entity.Property(e => e.LayoutSubName).HasMaxLength(100);

                entity.Property(e => e.Line).HasMaxLength(10);

                entity.Property(e => e.SubLine).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(5);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasComment("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MpckObject>(entity =>
            {
                entity.HasKey(e => e.ObjCode);

                entity.ToTable("MPCK_Object");

                entity.HasIndex(e => e.LayoutCode, "IX_MPCK_Object");

                entity.HasIndex(e => new { e.EmpCode, e.LayoutCode }, "IX_MPCK_Object_1");

                entity.HasIndex(e => e.EmpCode, "IX_MPCK_Object_2");

                entity.HasIndex(e => new { e.LayoutCode, e.ObjType }, "IX_MPCK_Object_3");

                entity.Property(e => e.ObjCode)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_Code");

                entity.Property(e => e.EmpCode).HasMaxLength(5);

                entity.Property(e => e.LayoutCode).HasMaxLength(20);

                entity.Property(e => e.ObjInsertDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Obj_InsertDT");

                entity.Property(e => e.ObjLastCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Obj_LastCheckDT");

                entity.Property(e => e.ObjMasterId)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_MasterID");

                entity.Property(e => e.ObjPath)
                    .HasColumnType("text")
                    .HasColumnName("Obj_Path");

                entity.Property(e => e.ObjStatus)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Status");

                entity.Property(e => e.ObjSubtitle)
                    .HasMaxLength(200)
                    .HasColumnName("Obj_Subtitle");

                entity.Property(e => e.ObjTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Obj_Title");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Type");

                entity.Property(e => e.ObjX).HasColumnName("Obj_X");

                entity.Property(e => e.ObjY).HasColumnName("Obj_Y");
            });

            modelBuilder.Entity<MpckObjectMaster>(entity =>
            {
                entity.HasKey(e => e.ObjMasterId)
                    .HasName("PK_LNS_OBJECT_MASTER");

                entity.ToTable("MPCK_Object_Master");

                entity.Property(e => e.ObjMasterId)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_MasterID");

                entity.Property(e => e.MstName)
                    .HasMaxLength(50)
                    .HasColumnName("Mst_Name");

                entity.Property(e => e.MstOrder)
                    .HasColumnName("Mst_Order")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MstStatus)
                    .HasMaxLength(20)
                    .HasColumnName("Mst_Status");

                entity.Property(e => e.ObjSvg)
                    .HasColumnType("text")
                    .HasColumnName("OBJ_SVG");
            });

            modelBuilder.Entity<SkcCheckInOutLog>(entity =>
            {
                entity.HasKey(e => e.ChkId);

                entity.ToTable("SKC_CheckInOutLog");

                entity.Property(e => e.ChkId).HasColumnName("CHK_ID");

                entity.Property(e => e.ChkDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHK_DATE");

                entity.Property(e => e.ChkEmpcode)
                    .HasMaxLength(50)
                    .HasColumnName("CHK_EMPCODE");

                entity.Property(e => e.ChkState)
                    .HasMaxLength(50)
                    .HasColumnName("CHK_STATE")
                    .HasComment("in or out");

                entity.Property(e => e.DictCode)
                    .HasMaxLength(50)
                    .HasColumnName("DICT_CODE");
            });

            modelBuilder.Entity<SkcDictMstr>(entity =>
            {
                entity.HasKey(e => e.DictId);

                entity.ToTable("SKC_DictMstr");

                entity.HasIndex(e => e.DictType, "IX_SKC_DictMstr");

                entity.HasIndex(e => new { e.DictType, e.Code }, "IX_SKC_DictMstr_1");

                entity.HasIndex(e => new { e.DictType, e.Code, e.RefCode }, "IX_SKC_DictMstr_2");

                entity.Property(e => e.DictId).HasColumnName("DICT_ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DictDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DICT_DESC");

                entity.Property(e => e.DictStatus).HasColumnName("DICT_STATUS");

                entity.Property(e => e.DictType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DICT_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.RefCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REF_CODE");

                entity.Property(e => e.RefItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REF_ITEM");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<SkcLicenseTraining>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("PK_SKC_LicenseTraning");

                entity.ToTable("SKC_LicenseTraining");

                entity.Property(e => e.TrId).HasColumnName("TR_ID");

                entity.Property(e => e.AlertDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ALERT_DATE");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(30)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DictCode)
                    .HasMaxLength(30)
                    .HasColumnName("DICT_CODE");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_DATE");

                entity.Property(e => e.Empcode)
                    .HasMaxLength(10)
                    .HasColumnName("EMPCODE");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.RefCode)
                    .HasMaxLength(10)
                    .HasColumnName("REF_CODE");

                entity.Property(e => e.TrStatus).HasColumnName("TR_STATUS");
            });

            modelBuilder.Entity<SkcPrivilege>(entity =>
            {
                entity.HasKey(e => new { e.PriRole, e.PriProgram })
                    .HasName("PK_SKC_Privilege_1");

                entity.ToTable("SKC_Privilege");

                entity.Property(e => e.PriRole)
                    .HasMaxLength(10)
                    .HasColumnName("PRI_ROLE");

                entity.Property(e => e.PriProgram)
                    .HasMaxLength(50)
                    .HasColumnName("PRI_PROGRAM");

                entity.Property(e => e.PriAdd)
                    .HasMaxLength(1)
                    .HasColumnName("PRI_ADD");

                entity.Property(e => e.PriCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("PRI_CREATE_BY");

                entity.Property(e => e.PriCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRI_CREATE_DATE");

                entity.Property(e => e.PriDelete)
                    .HasMaxLength(1)
                    .HasColumnName("PRI_DELETE");

                entity.Property(e => e.PriModify)
                    .HasMaxLength(1)
                    .HasColumnName("PRI_MODIFY");

                entity.Property(e => e.PriSearch)
                    .HasMaxLength(1)
                    .HasColumnName("PRI_SEARCH");
            });

            modelBuilder.Entity<SkcUserInRole>(entity =>
            {
                entity.HasKey(e => new { e.PriRole, e.PriEmpcode });

                entity.ToTable("SKC_UserInRole");

                entity.Property(e => e.PriRole)
                    .HasMaxLength(50)
                    .HasColumnName("PRI_ROLE");

                entity.Property(e => e.PriEmpcode)
                    .HasMaxLength(20)
                    .HasColumnName("PRI_EMPCODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");
            });

            modelBuilder.Entity<ViMpckCheckInOutLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_MPCK_CheckInOutLog");

                entity.Property(e => e.Ckdate)
                    .HasMaxLength(8)
                    .HasColumnName("CKDate");

                entity.Property(e => e.CkdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CKDateTime");

                entity.Property(e => e.Ckshift)
                    .HasMaxLength(5)
                    .HasColumnName("CKShift");

                entity.Property(e => e.Cktype)
                    .HasMaxLength(10)
                    .HasColumnName("CKType");

                entity.Property(e => e.EmpCode).HasMaxLength(5);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(202)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Nbr).HasMaxLength(50);

                entity.Property(e => e.ObjCode)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_Code");

                entity.Property(e => e.Posit)
                    .HasMaxLength(50)
                    .HasColumnName("POSIT")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<ViMpckDictionary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_MPCK_Dictionary");

                entity.Property(e => e.BypassMq)
                    .HasMaxLength(10)
                    .HasColumnName("BypassMQ");

                entity.Property(e => e.BypassSa)
                    .HasMaxLength(10)
                    .HasColumnName("BypassSA");

                entity.Property(e => e.DictCode)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_Code");

                entity.Property(e => e.DictName)
                    .HasMaxLength(250)
                    .HasColumnName("Dict_Name");

                entity.Property(e => e.DictRefCode)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_RefCode");

                entity.Property(e => e.DictType)
                    .HasMaxLength(50)
                    .HasColumnName("Dict_Type");

                entity.Property(e => e.Factory).HasMaxLength(10);

                entity.Property(e => e.LayoutName).HasMaxLength(50);

                entity.Property(e => e.LayoutStatus).HasMaxLength(10);

                entity.Property(e => e.LayoutSubName).HasMaxLength(50);

                entity.Property(e => e.Line).HasMaxLength(10);

                entity.Property(e => e.SubLine).HasMaxLength(20);
            });

            modelBuilder.Entity<ViMpckObjectList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_MPCK_ObjectList");

                entity.Property(e => e.BypassMq)
                    .HasMaxLength(10)
                    .HasColumnName("BypassMQ");

                entity.Property(e => e.BypassSa)
                    .HasMaxLength(10)
                    .HasColumnName("BypassSA");

                entity.Property(e => e.EmpCode).HasMaxLength(5);

                entity.Property(e => e.EmpImage).HasMaxLength(48);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(202)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Factory).HasMaxLength(10);

                entity.Property(e => e.LayoutCode).HasMaxLength(20);

                entity.Property(e => e.LayoutName).HasMaxLength(50);

                entity.Property(e => e.LayoutStatus).HasMaxLength(10);

                entity.Property(e => e.LayoutSubName).HasMaxLength(100);

                entity.Property(e => e.Line).HasMaxLength(10);

                entity.Property(e => e.Mq)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MQ");

                entity.Property(e => e.MstOrder).HasColumnName("Mst_Order");

                entity.Property(e => e.ObjCode)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_Code");

                entity.Property(e => e.ObjLastCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Obj_LastCheckDT");

                entity.Property(e => e.ObjMasterId)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_MasterID");

                entity.Property(e => e.ObjPath)
                    .HasColumnType("text")
                    .HasColumnName("Obj_Path");

                entity.Property(e => e.ObjStatus)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Status");

                entity.Property(e => e.ObjSubtitle)
                    .HasMaxLength(200)
                    .HasColumnName("Obj_Subtitle");

                entity.Property(e => e.ObjSvg)
                    .HasColumnType("text")
                    .HasColumnName("OBJ_SVG");

                entity.Property(e => e.ObjTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Obj_Title");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Type");

                entity.Property(e => e.ObjX).HasColumnName("Obj_X");

                entity.Property(e => e.ObjY).HasColumnName("Obj_Y");

                entity.Property(e => e.Ot)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("OT");

                entity.Property(e => e.Sa)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SA");

                entity.Property(e => e.SubLine).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
