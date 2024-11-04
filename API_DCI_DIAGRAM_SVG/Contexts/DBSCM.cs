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

        public virtual DbSet<ApsProductionPlan> ApsProductionPlans { get; set; } = null!;
        public virtual DbSet<ApsProductionPlanNotice> ApsProductionPlanNotices { get; set; } = null!;
        public virtual DbSet<ApsProductionPlanNotify> ApsProductionPlanNotifies { get; set; } = null!;
        public virtual DbSet<ApsSublineStockBalance> ApsSublineStockBalances { get; set; } = null!;
        public virtual DbSet<DcrunNbr> DcrunNbrs { get; set; } = null!;
        public virtual DbSet<DictMstr> DictMstrs { get; set; } = null!;
        public virtual DbSet<EkbWipPartStock> EkbWipPartStocks { get; set; } = null!;
        public virtual DbSet<EkbWipPartStockTransaction> EkbWipPartStockTransactions { get; set; } = null!;
        public virtual DbSet<MpckCheckInLog> MpckCheckInLogs { get; set; } = null!;
        public virtual DbSet<MpckDictionary> MpckDictionaries { get; set; } = null!;
        public virtual DbSet<MpckLayout> MpckLayouts { get; set; } = null!;
        public virtual DbSet<MpckObject> MpckObjects { get; set; } = null!;
        public virtual DbSet<MpckObjectMaster> MpckObjectMasters { get; set; } = null!;
        public virtual DbSet<PdBackflushFormulaDatum> PdBackflushFormulaData { get; set; } = null!;
        public virtual DbSet<SkcDictMstr> SkcDictMstrs { get; set; } = null!;
        public virtual DbSet<SkcLicenseTraining> SkcLicenseTrainings { get; set; } = null!;
        public virtual DbSet<ViApsPartMaster> ViApsPartMasters { get; set; } = null!;
        public virtual DbSet<ViApsPartStockScr> ViApsPartStockScrs { get; set; } = null!;
        public virtual DbSet<ViApsPartStockScrCasing> ViApsPartStockScrCasings { get; set; } = null!;
        public virtual DbSet<ViMpckCheckInOutLog> ViMpckCheckInOutLogs { get; set; } = null!;
        public virtual DbSet<ViMpckDictionary> ViMpckDictionaries { get; set; } = null!;
        public virtual DbSet<ViMpckObjectList> ViMpckObjectLists { get; set; } = null!;
        public virtual DbSet<WmsMdw27ModelMaster> WmsMdw27ModelMasters { get; set; } = null!;
        public virtual DbSet<SpDCRunNbr> SpDCRunNbr { get; set; } = null!;
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

            modelBuilder.Entity<ApsProductionPlan>(entity =>
            {
                entity.HasKey(e => e.PrdPlanCode);

                entity.ToTable("APS_ProductionPlan");

                entity.HasIndex(e => new { e.Lrev, e.ApsPlanDate, e.Wcno, e.Subline }, "IX_APS_ProductionPlan");

                entity.HasIndex(e => new { e.ApsPlanDate, e.Lrev, e.Wcno, e.Subline, e.PartNo, e.Cm }, "IX_APS_ProductionPlan_1");

                entity.HasIndex(e => new { e.PrdPlanCode, e.Lrev, e.PartNo, e.Cm }, "IX_APS_ProductionPlan_2");

                entity.Property(e => e.PrdPlanCode)
                    .HasMaxLength(50)
                    .HasColumnName("PRD_PlanCode");

                entity.Property(e => e.ApsCurrent)
                    .HasMaxLength(10)
                    .HasColumnName("APS_Current");

                entity.Property(e => e.ApsDistribute)
                    .HasMaxLength(8)
                    .HasColumnName("APS_Distribute");

                entity.Property(e => e.ApsPlanDate)
                    .HasColumnType("date")
                    .HasColumnName("APS_PlanDate");

                entity.Property(e => e.ApsPlanQty).HasColumnName("APS_PlanQty");

                entity.Property(e => e.ApsSeq)
                    .HasMaxLength(2)
                    .HasColumnName("APS_SEQ");

                entity.Property(e => e.Cm)
                    .HasMaxLength(2)
                    .HasColumnName("CM");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(50)
                    .HasColumnName("CRE_BY");

                entity.Property(e => e.CreDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Lrev)
                    .HasMaxLength(3)
                    .HasColumnName("LREV")
                    .HasDefaultValueSql("(N'000')");

                entity.Property(e => e.PartNo).HasMaxLength(25);

                entity.Property(e => e.PrdPlanQty).HasColumnName("PRD_PlanQty");

                entity.Property(e => e.PrdSeq)
                    .HasMaxLength(2)
                    .HasColumnName("PRD_SEQ");

                entity.Property(e => e.Rev)
                    .HasMaxLength(3)
                    .HasColumnName("REV")
                    .HasDefaultValueSql("(N'000')");

                entity.Property(e => e.Subline)
                    .HasMaxLength(70)
                    .HasColumnName("SUBLINE");

                entity.Property(e => e.UpdBy)
                    .HasMaxLength(50)
                    .HasColumnName("UPD_BY");

                entity.Property(e => e.UpdDt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPD_DT");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");
            });

            modelBuilder.Entity<ApsProductionPlanNotice>(entity =>
            {
                entity.HasKey(e => e.NtNbr);

                entity.ToTable("APS_ProductionPlan_Notice");

                entity.HasIndex(e => e.PrdPlanCode, "IX_APS_ProductionPlan_Notice");

                entity.HasIndex(e => new { e.PrdPlanCode, e.NtCode }, "IX_APS_ProductionPlan_Notice_1");

                entity.Property(e => e.NtNbr)
                    .HasMaxLength(50)
                    .HasColumnName("NT_Nbr");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(50)
                    .HasColumnName("CRE_BY");

                entity.Property(e => e.CreDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NtCode)
                    .HasMaxLength(50)
                    .HasColumnName("NT_Code");

                entity.Property(e => e.NtNotice)
                    .HasMaxLength(250)
                    .HasColumnName("NT_Notice");

                entity.Property(e => e.NtObjectiveType)
                    .HasMaxLength(50)
                    .HasColumnName("NT_ObjectiveType");

                entity.Property(e => e.NtType)
                    .HasMaxLength(10)
                    .HasColumnName("NT_TYPE");

                entity.Property(e => e.PrdPlanCode)
                    .HasMaxLength(50)
                    .HasColumnName("PRD_PlanCode");
            });

            modelBuilder.Entity<ApsProductionPlanNotify>(entity =>
            {
                entity.HasKey(e => new { e.Wcno, e.LineType, e.ChangeDt, e.SubLine });

                entity.ToTable("APS_ProductionPlan_Notify");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");

                entity.Property(e => e.LineType)
                    .HasMaxLength(50)
                    .HasColumnName("LINE_TYPE");

                entity.Property(e => e.ChangeDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CHANGE_DT");

                entity.Property(e => e.SubLine)
                    .HasMaxLength(50)
                    .HasColumnName("SUB_LINE");

                entity.Property(e => e.AckBy)
                    .HasMaxLength(50)
                    .HasColumnName("ACK_BY");

                entity.Property(e => e.AckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("ACK_DT");

                entity.Property(e => e.AckStatus)
                    .HasMaxLength(50)
                    .HasColumnName("ACK_STATUS");

                entity.Property(e => e.NotifyBy)
                    .HasMaxLength(50)
                    .HasColumnName("NOTIFY_BY");

                entity.Property(e => e.NotifyDt)
                    .HasColumnType("datetime")
                    .HasColumnName("NOTIFY_DT");
            });

            modelBuilder.Entity<ApsSublineStockBalance>(entity =>
            {
                entity.HasKey(e => new { e.Ym, e.Ymd, e.Wcno, e.Hhmm, e.ApsSeq, e.Modelcode, e.Modelname })
                    .HasName("PK_APS_SUBLINE_STOCK_BALANCE_1");

                entity.ToTable("APS_SUBLINE_STOCK_BALANCE");

                entity.Property(e => e.Ym)
                    .HasMaxLength(6)
                    .HasColumnName("YM");

                entity.Property(e => e.Ymd)
                    .HasMaxLength(8)
                    .HasColumnName("YMD");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");

                entity.Property(e => e.Hhmm)
                    .HasMaxLength(5)
                    .HasColumnName("HHMM");

                entity.Property(e => e.ApsSeq)
                    .HasMaxLength(2)
                    .HasColumnName("APS_Seq");

                entity.Property(e => e.Modelcode)
                    .HasMaxLength(4)
                    .HasColumnName("MODELCODE");

                entity.Property(e => e.Modelname)
                    .HasMaxLength(30)
                    .HasColumnName("MODELNAME");

                entity.Property(e => e.ApsCurrent)
                    .HasMaxLength(10)
                    .HasColumnName("APS_Current");

                entity.Property(e => e.ApsPlan)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("APS_Plan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ApsRemainPlan)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("APS_RemainPlan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ApsResult)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("APS_Result")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BodyMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("BODY_MAIN");

                entity.Property(e => e.BodySubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("BODY_SUBLINE");

                entity.Property(e => e.BottomMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("BOTTOM_MAIN");

                entity.Property(e => e.BottomSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("BOTTOM_SUBLINE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CsMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("CS_MAIN");

                entity.Property(e => e.CsSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("CS_SUBLINE");

                entity.Property(e => e.FsMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("FS_MAIN");

                entity.Property(e => e.FsSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("FS_SUBLINE");

                entity.Property(e => e.HsMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("HS_MAIN");

                entity.Property(e => e.HsSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("HS_SUBLINE");

                entity.Property(e => e.LwMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("LW_MAIN");

                entity.Property(e => e.LwSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("LW_SUBLINE");

                entity.Property(e => e.RotorMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("ROTOR_MAIN");

                entity.Property(e => e.RotorSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("ROTOR_SUBLINE");

                entity.Property(e => e.StatorMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("STATOR_MAIN");

                entity.Property(e => e.StatorSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("STATOR_SUBLINE");

                entity.Property(e => e.TopMain)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TOP_MAIN");

                entity.Property(e => e.TopSubline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TOP_SUBLINE");
            });

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

            modelBuilder.Entity<DictMstr>(entity =>
            {
                entity.HasKey(e => e.DictId);

                entity.ToTable("DictMstr");

                entity.Property(e => e.DictId).HasColumnName("DICT_ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DictStatus)
                    .HasMaxLength(20)
                    .HasColumnName("DICT_STATUS");

                entity.Property(e => e.DictSystem)
                    .HasMaxLength(20)
                    .HasColumnName("DICT_SYSTEM");

                entity.Property(e => e.DictType)
                    .HasMaxLength(50)
                    .HasColumnName("DICT_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("NOTE");

                entity.Property(e => e.Ref1)
                    .HasMaxLength(20)
                    .HasColumnName("REF1");

                entity.Property(e => e.Ref2)
                    .HasMaxLength(20)
                    .HasColumnName("REF2");

                entity.Property(e => e.Ref3)
                    .HasMaxLength(20)
                    .HasColumnName("REF3");

                entity.Property(e => e.Ref4)
                    .HasMaxLength(20)
                    .HasColumnName("REF4");

                entity.Property(e => e.RefCode)
                    .HasMaxLength(200)
                    .HasColumnName("REF_CODE");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EkbWipPartStock>(entity =>
            {
                entity.HasKey(e => new { e.Ym, e.Wcno, e.Partno, e.Cm })
                    .HasName("PK_EKB_LINE_STOCK_MONIOTR");

                entity.ToTable("EKB_WIP_PART_STOCK");

                entity.Property(e => e.Ym)
                    .HasMaxLength(8)
                    .HasColumnName("YM");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");

                entity.Property(e => e.Partno)
                    .HasMaxLength(25)
                    .HasColumnName("PARTNO");

                entity.Property(e => e.Cm)
                    .HasMaxLength(2)
                    .HasColumnName("CM");

                entity.Property(e => e.Bal)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("BAL");

                entity.Property(e => e.Issqty)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("ISSQTY");

                entity.Property(e => e.Lbal)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("LBAL");

                entity.Property(e => e.Ptype).HasMaxLength(15);

                entity.Property(e => e.Recqty)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RECQTY");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EkbWipPartStockTransaction>(entity =>
            {
                entity.HasKey(e => e.Nbr)
                    .HasName("PK_EKB_WIP_Part_Stock_Transaction");

                entity.ToTable("EKB_WIP_PART_STOCK_TRANSACTION");

                entity.Property(e => e.Nbr)
                    .HasMaxLength(50)
                    .HasColumnName("nbr");

                entity.Property(e => e.Cm)
                    .HasMaxLength(2)
                    .HasColumnName("CM");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Partno)
                    .HasMaxLength(20)
                    .HasColumnName("PARTNO");

                entity.Property(e => e.QrcodeData)
                    .HasMaxLength(150)
                    .HasColumnName("QRCodeData");

                entity.Property(e => e.RefNo).HasMaxLength(150);

                entity.Property(e => e.Shift)
                    .HasMaxLength(1)
                    .HasColumnName("SHIFT");

                entity.Property(e => e.TransQty).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TransType).HasMaxLength(50);

                entity.Property(e => e.Wcno)
                    .HasMaxLength(3)
                    .HasColumnName("WCNO");

                entity.Property(e => e.Ym)
                    .HasMaxLength(6)
                    .HasColumnName("YM");

                entity.Property(e => e.Ymd)
                    .HasMaxLength(8)
                    .HasColumnName("YMD");
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

                entity.Property(e => e.BoardId).HasMaxLength(200);

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
                    .HasDefaultValueSql("(getdate())")
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

                entity.Property(e => e.ObjBackgroundColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_BackgroundColor");

                entity.Property(e => e.ObjBorderColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_BorderColor");

                entity.Property(e => e.ObjBorderWidth)
                    .HasColumnName("Obj_BorderWidth")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ObjFontColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_FontColor")
                    .HasDefaultValueSql("(N'#000000')");

                entity.Property(e => e.ObjFontSize)
                    .HasColumnName("Obj_FontSize")
                    .HasDefaultValueSql("((14))");

                entity.Property(e => e.ObjHeight)
                    .HasColumnName("Obj_Height")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ObjPicture)
                    .HasMaxLength(200)
                    .HasColumnName("Obj_Picture");

                entity.Property(e => e.ObjPosition)
                    .HasMaxLength(2)
                    .HasColumnName("Obj_Position");

                entity.Property(e => e.ObjPriority)
                    .HasColumnName("Obj_Priority")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjStatus)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Status");

                entity.Property(e => e.ObjSubtitle)
                    .HasMaxLength(200)
                    .HasColumnName("Obj_Subtitle");

                entity.Property(e => e.ObjTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Obj_Title");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Type");

                entity.Property(e => e.ObjWidth)
                    .HasColumnName("Obj_Width")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.LayoutCode).HasMaxLength(50);

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

            modelBuilder.Entity<PdBackflushFormulaDatum>(entity =>
            {
                entity.HasKey(e => new { e.Pddate, e.Shift, e.Wcno, e.Drawing, e.Cm, e.Ftype, e.Fno });

                entity.ToTable("PD_Backflush_FormulaData");

                entity.HasIndex(e => new { e.Pddate, e.Drawing, e.Cm, e.Wcno }, "IX_PD_Backflush_FormulaData");

                entity.HasIndex(e => new { e.Pddate, e.Drawing, e.Cm, e.Shift, e.Ftype, e.Wcno, e.Fno }, "IX_PD_Backflush_FormulaData_1");

                entity.HasIndex(e => new { e.Pddate, e.Shift, e.Wcno, e.Drawing, e.Cm, e.Ftype }, "IX_PD_Backflush_FormulaData_2");

                entity.HasIndex(e => new { e.Pddate, e.Wcno, e.Shift }, "IX_PD_Backflush_FormulaData_3");

                entity.HasIndex(e => e.UpdateDate, "NonClusteredIndex-20210623-121726");

                entity.Property(e => e.Pddate)
                    .HasColumnType("date")
                    .HasColumnName("PDDate");

                entity.Property(e => e.Shift).HasMaxLength(50);

                entity.Property(e => e.Wcno)
                    .HasMaxLength(50)
                    .HasColumnName("WCNO");

                entity.Property(e => e.Drawing).HasMaxLength(50);

                entity.Property(e => e.Cm)
                    .HasMaxLength(50)
                    .HasColumnName("CM");

                entity.Property(e => e.Ftype)
                    .HasMaxLength(1)
                    .HasColumnName("FTYPE");

                entity.Property(e => e.Fno)
                    .HasMaxLength(2)
                    .HasColumnName("FNO");

                entity.Property(e => e.Alpha)
                    .HasMaxLength(50)
                    .HasColumnName("ALPHA");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
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

            modelBuilder.Entity<ViApsPartStockScr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_APS_PartStock_SCR");

                entity.Property(e => e.BodyMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BODY-MAIN");

                entity.Property(e => e.BodySubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BODY-SUBLINE");

                entity.Property(e => e.BottomMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BOTTOM-MAIN");

                entity.Property(e => e.BottomSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BOTTOM-SUBLINE");

                entity.Property(e => e.CsMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("CS-MAIN");

                entity.Property(e => e.CsSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("CS-SUBLINE");

                entity.Property(e => e.FsMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("FS-MAIN");

                entity.Property(e => e.FsSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("FS-SUBLINE");

                entity.Property(e => e.HsMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("HS-MAIN");

                entity.Property(e => e.HsSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("HS-SUBLINE");

                entity.Property(e => e.LwMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("LW-MAIN");

                entity.Property(e => e.LwSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("LW-SUBLINE");

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(250);

                entity.Property(e => e.Pwcno)
                    .HasMaxLength(20)
                    .HasColumnName("PWCNO");

                entity.Property(e => e.RotorMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("ROTOR-MAIN");

                entity.Property(e => e.RotorSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("ROTOR-SUBLINE");

                entity.Property(e => e.StatorMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("STATOR-MAIN");

                entity.Property(e => e.StatorSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("STATOR-SUBLINE");

                entity.Property(e => e.TopMain)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TOP-MAIN");

                entity.Property(e => e.TopSubline)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TOP-SUBLINE");

                entity.Property(e => e.Ym)
                    .HasMaxLength(8)
                    .HasColumnName("YM");
            });

            modelBuilder.Entity<ViApsPartStockScrCasing>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_APS_PartStock_SCR_CASING");

                entity.Property(e => e.BdALine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BD-A-LINE");

                entity.Property(e => e.BdAPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BD-A-PS");

                entity.Property(e => e.BdLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BD-LINE");

                entity.Property(e => e.BdPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("BD-PS");

                entity.Property(e => e.DisChaTJLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("DIS-CHA-T-J-LINE");

                entity.Property(e => e.DisChaTJPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("DIS-CHA-T-J-PS");

                entity.Property(e => e.DisChaTLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("DIS-CHA-T-LINE");

                entity.Property(e => e.DisChaTPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("DIS-CHA-T-PS");

                entity.Property(e => e.FeelBLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("FEEL-B-LINE");

                entity.Property(e => e.FeelBPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("FEEL-B-PS");

                entity.Property(e => e.GgLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("GG-LINE");

                entity.Property(e => e.GgPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("GG-PS");

                entity.Property(e => e.GtaLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("GTA-LINE");

                entity.Property(e => e.GtaPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("GTA-PS");

                entity.Property(e => e.Model)
                    .HasMaxLength(250)
                    .HasColumnName("MODEL");

                entity.Property(e => e.OretPLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("ORET-P-LINE");

                entity.Property(e => e.OretPPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("ORET-P-PS");

                entity.Property(e => e.PanHLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("PAN-H-LINE");

                entity.Property(e => e.PanHPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("PAN-H-PS");

                entity.Property(e => e.TmnGdALine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TMN-GD-A-LINE");

                entity.Property(e => e.TmnGdAPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TMN-GD-A-PS");

                entity.Property(e => e.TmnGdLine)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TMN-GD-LINE");

                entity.Property(e => e.TmnGdPs)
                    .HasColumnType("decimal(38, 4)")
                    .HasColumnName("TMN-GD-PS");

                entity.Property(e => e.Wcno)
                    .HasMaxLength(20)
                    .HasColumnName("WCNO");

                entity.Property(e => e.Ym)
                    .HasMaxLength(8)
                    .HasColumnName("YM");
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

                entity.Property(e => e.ObjBackgroundColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_BackgroundColor");

                entity.Property(e => e.ObjBorderColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_BorderColor");

                entity.Property(e => e.ObjBorderWidth).HasColumnName("Obj_BorderWidth");

                entity.Property(e => e.ObjCode)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_Code");

                entity.Property(e => e.ObjFontColor)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_FontColor");

                entity.Property(e => e.ObjFontSize).HasColumnName("Obj_FontSize");

                entity.Property(e => e.ObjHeight).HasColumnName("Obj_Height");

                entity.Property(e => e.ObjLastCheckDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Obj_LastCheckDT");

                entity.Property(e => e.ObjMasterId)
                    .HasMaxLength(20)
                    .HasColumnName("Obj_MasterID");

                entity.Property(e => e.ObjPath)
                    .HasColumnType("text")
                    .HasColumnName("Obj_Path");

                entity.Property(e => e.ObjPicture)
                    .HasMaxLength(200)
                    .HasColumnName("Obj_Picture");

                entity.Property(e => e.ObjPosition)
                    .HasMaxLength(2)
                    .HasColumnName("Obj_Position");

                entity.Property(e => e.ObjPriority).HasColumnName("Obj_Priority");

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
                    .HasMaxLength(100)
                    .HasColumnName("Obj_Title");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(10)
                    .HasColumnName("Obj_Type");

                entity.Property(e => e.ObjWidth).HasColumnName("Obj_Width");

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

            modelBuilder.Entity<WmsMdw27ModelMaster>(entity =>
            {
                entity.HasKey(e => new { e.Model, e.Modelgroup, e.Pltype, e.Strloc, e.Rev, e.Lrev, e.Strdate, e.Enddate, e.Remark, e.Sebango, e.Diameter })
                    .HasName("PK_WMS_MDW27_MODEL_MASTER_1");

                entity.ToTable("WMS_MDW27_MODEL_MASTER");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Modelgroup)
                    .HasMaxLength(3)
                    .HasColumnName("MODELGROUP");

                entity.Property(e => e.Pltype)
                    .HasMaxLength(50)
                    .HasColumnName("PLTYPE");

                entity.Property(e => e.Strloc)
                    .HasMaxLength(50)
                    .HasColumnName("STRLOC");

                entity.Property(e => e.Rev).HasColumnName("REV");

                entity.Property(e => e.Lrev).HasColumnName("LREV");

                entity.Property(e => e.Strdate)
                    .HasMaxLength(8)
                    .HasColumnName("STRDATE");

                entity.Property(e => e.Enddate)
                    .HasMaxLength(8)
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Sebango)
                    .HasMaxLength(50)
                    .HasColumnName("SEBANGO");

                entity.Property(e => e.Diameter)
                    .HasMaxLength(50)
                    .HasColumnName("DIAMETER");

                entity.Property(e => e.Active)
                    .HasMaxLength(20)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("(N'INACTIVE')");

                entity.Property(e => e.Area)
                    .HasMaxLength(20)
                    .HasColumnName("AREA");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(N'every 8.30 AM')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .HasColumnName("CUSTOMER");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
