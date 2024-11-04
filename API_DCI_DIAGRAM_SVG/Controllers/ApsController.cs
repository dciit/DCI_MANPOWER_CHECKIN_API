using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Interfaces;
using API_DCI_DIAGRAM_SVG.Models;
using API_DCI_DIAGRAM_SVG.Params;
using API_DCI_DIAGRAM_SVG.Props;
using EKBPartStock.service.runningNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class ApsController : Controller
    {
        ManpowerServices oSrvMP = new ManpowerServices();
        ClsHelper oHelper = new ClsHelper();
        ApsServices oApsService = new ApsServices();
        private readonly DBSCM efSCM;
        private readonly COSTYIOT efCostyIoT;
        private readonly SqlConnectDB dbSCM = new SqlConnectDB("dbSCM");
        private readonly SqlConnectDB dbHRM = new SqlConnectDB("dbHRM");
        private readonly SqlConnectDB dbIOT = new SqlConnectDB("dbIoT");
        public Service oServ = new Service();
        public ApsController(DBSCM efSCM, COSTYIOT efCostyIoT, HRMContext efHRM, DBDCI efDCI)
        {
            this.efSCM = efSCM;
            this.efCostyIoT = efCostyIoT;
        }

        //[HttpGet]
        //[Route("/aps/data/maininout")]
        //public IActionResult ApsData()
        //{
        //    List<ViApsPartMaster> rApsPartMaster = efSCM.ViApsPartMasters.Where(x => x.Model != null && x.Wcno == "904").OrderBy(x => x.Model).ToList();
        //    return Ok(rApsPartMaster);
        //}

        //        [HttpGet]
        //        [Route("/ApsMainGetData/{dateStart}")]
        //        public IActionResult ApsMainGetData(string dateStart)
        //        {
        //            DateTime dtNow = DateTime.Now.AddDays(-1);
        //            int yyyy = Convert.ToInt16(dateStart.Substring(0, 4));
        //            int mm = Convert.ToInt16(dateStart.Substring(4, 2));
        //            int dd = Convert.ToInt16(dateStart.Substring(6, 2));
        //            //DateTime dtFilter = new DateTime(yyyy, mm, dd);
        //            List<ApsModelInterActiveProps> rApsModelInteractive = new List<ApsModelInterActiveProps>();
        //            SqlCommand sqlGetDataInteractive = new SqlCommand();
        //            sqlGetDataInteractive.CommandText = @"SELECT  DATEPART(hour, DATEADD(hour,-8,Insert_Date))+8 [hour], SUBSTRING(Serial,1,4)  modelCode, m.model as modelName, COUNT(Serial) cnt
        //FROM [dbIoT].[dbo].[SCR_GasTight]
        //LEFT JOIN (SELECT MODELCODE, MODEL FROM [192.168.226.86].dbSCM.dbo.PN_Compressor WHERE [Status]='ACTIVE' GROUP BY [ModelCode],[Model] ) m ON m.modelcode = SUBSTRING(Serial,1,4)
        //WHERE CAST(DATEADD(hour,-8, Insert_Date) AS DATE) >= @CURR_DATE
        //   and Serial != 'ERROR'
        //GROUP BY  SUBSTRING(Serial,1,4), m.model, DATEPART(hour, DATEADD(hour,-8,Insert_Date))
        //ORDER BY DATEPART(hour, DATEADD(hour,-8,Insert_Date)) ASC  
        //";
        //            sqlGetDataInteractive.Parameters.Add(new SqlParameter("@CURR_DATE", dtNow.ToString("yyyy-MM-dd")));
        //            DataTable dtDataInterActive = dbIOT.Query(sqlGetDataInteractive);
        //            foreach (DataRow drInteractive in dtDataInterActive.Rows)
        //            {
        //                ApsModelInterActiveProps mApsModelInterActive = new ApsModelInterActiveProps();
        //                mApsModelInterActive.time = drInteractive["hour"].ToString() != "" ? Convert.ToInt16(drInteractive["hour"].ToString()).ToString("D2:00") : "-";
        //                mApsModelInterActive.modelCode = drInteractive["modelCode"].ToString();
        //                mApsModelInterActive.modelName = drInteractive["modelName"].ToString();
        //                mApsModelInterActive.result = Convert.ToInt16(drInteractive["cnt"].ToString());
        //                rApsModelInteractive.Add(mApsModelInterActive);
        //            }

        //            //List<string> rSubline = new List<string>() { "ASSEMBLY LINE4 (SCR)", "FINAL-ASSEMBLY LINE4 (SCR)" };
        //            List<string> rSubline = new List<string>() { "ASSEMBLY LINE4 (SCR)" };
        //            List<PriorityPlanInfo> planList = new List<PriorityPlanInfo>();
        //            string plan_startDate = dateStart;
        //            string plan_endDate = dateStart;
        //            Random rnd = new Random();
        //            string pid = rnd.Next().ToString();

        //            string wcno = "904";


        //            foreach (string subline in rSubline)
        //            {
        //                SqlCommand sqlStore = new SqlCommand();
        //                sqlStore.CommandText = "sp_APS_WK_DailyPlan";
        //                sqlStore.CommandType = CommandType.StoredProcedure;
        //                sqlStore.Parameters.Add(new SqlParameter("@pPID", pid));
        //                sqlStore.Parameters.Add(new SqlParameter("@pWCNO", wcno));
        //                sqlStore.Parameters.Add(new SqlParameter("@pLINENAME", subline));
        //                sqlStore.CommandTimeout = 180;
        //                dbSCM.ExecuteCommand(sqlStore);

        //                DataTable dtSequencePlan = new DataTable();
        //                dtSequencePlan.Columns.Add("PLANDATE", typeof(string));
        //                dtSequencePlan.Columns.Add("SEQUENCE", typeof(string));
        //                dtSequencePlan.Columns.Add("WCNO", typeof(string));
        //                dtSequencePlan.Columns.Add("WCNAME", typeof(string));
        //                dtSequencePlan.Columns.Add("MODEL", typeof(string));
        //                dtSequencePlan.Columns.Add("MODELCODE", typeof(string));
        //                dtSequencePlan.Columns.Add("PARTNO", typeof(string));
        //                dtSequencePlan.Columns.Add("PLANQTY", typeof(double));
        //                dtSequencePlan.Columns.Add("PLANCODE", typeof(string));
        //                dtSequencePlan.Columns.Add("PACKPLANCODE", typeof(string));
        //                dtSequencePlan.Columns.Add("PACK_PLTYPE", typeof(string));
        //                dtSequencePlan.Columns.Add("PACK_PLQTY", typeof(string));
        //                dtSequencePlan.Columns.Add("PACK_PLANQTY", typeof(string));
        //                dtSequencePlan.Columns.Add("PACK_PALLETQTY", typeof(string));
        //                dtSequencePlan.Columns.Add("REPORT_QTY", typeof(string));
        //                SqlCommand sqlSelect = new SqlCommand();
        //                sqlSelect.CommandText = @"SELECT gt.*, PN.ModelCode, REPLACE(REPLACE(gt.PlanCode,':20','Pack:30'),':10','Pack:30') PackPlanCode, 
        //                                    ISNULL(pk.PLTYPE,'') PLTYPE, ISNULL(pk.PlanQty,0) PlanQty, ISNULL(pk.PLQty,0) PLQty, ISNULL(pk.PalletQTy,0) PalletQTy
        //                FROM vi_APS_PlanReport gt
        //                LEFT JOIN (
        //	                SELECT  (CASE  WHEN CHARINDEX('Pack-',PlanCode) > 0 THEN CONCAT(SUBSTRING(plancode,0,CHARINDEX('Pack-',PlanCode)),'Pack:30') ELSE PlanCode  END) as plancode, REPLACE(MainCode, CONCAT(Model,'-'),'') PLTYPE, PlanQty, PL.PLQty , CEILING(PlanQty/PL.PLQty) PalletQTy
        //	                FROM vi_APS_PlanReport pc
        //	                LEFT JOIN AL_PalletTypeMapping AS PL ON  PL.[PLTYPE] = REPLACE(MainCode, CONCAT(Model,'-'),'')
        //	                WHERE MasterOperationCode like 'Packing'
        //                ) pk ON REPLACE(REPLACE(gt.PlanCode,':20','Pack:30'),':10','Pack:30') = pk.plancode 
        //                LEFT JOIN [PN_Compressor] AS PN ON gt.MODEL = PN.[rmk1] AND RIGHT(gt.WCNO, 1) = PN.Line 
        //                WHERE MainResource = @MainResource AND WCNO = @WCNO  ORDER BY StartDT ASC   ";
        //                sqlSelect.Parameters.Add(new SqlParameter("@MainResource", subline));
        //                sqlSelect.Parameters.Add(new SqlParameter("@WCNO", "904"));


        //                //sqlSelect.Parameters.Add(new SqlParameter("@Status", "'" + paramStatus + "'"));
        //                sqlSelect.CommandTimeout = 180;
        //                DataTable dtPlan = dbSCM.Query(sqlSelect);

        //                if (dtPlan.Rows.Count > 0)
        //                {
        //                    // LOOP EACH OPERATION PLAN TO FIND DAILY PLAN
        //                    foreach (DataRow drow in dtPlan.Rows)
        //                    {
        //                        DateTime statDate = new DateTime();
        //                        DateTime endDate = new DateTime();
        //                        double total_gantt_plan = 0;
        //                        string model = "";
        //                        string modelCode = "";
        //                        string planCode = "";
        //                        string mainCode = "";
        //                        string packplancode = "";
        //                        string pack_pltype = "";
        //                        string pack_plqty = "";
        //                        string pack_palletqty = "";
        //                        string pack_planqty = "";
        //                        double report_qty = 0;

        //                        statDate = Convert.ToDateTime(drow["ShiftDateStart"].ToString());
        //                        endDate = Convert.ToDateTime(drow["ShiftDateEnd"].ToString());

        //                        total_gantt_plan = Convert.ToDouble(drow["PlanQty"].ToString());
        //                        mainCode = drow["MainCode"].ToString();
        //                        model = drow["Model"].ToString();
        //                        planCode = drow["PlanCode"].ToString();
        //                        modelCode = drow["ModelCode"].ToString();
        //                        packplancode = drow["PackPlanCode"].ToString();
        //                        pack_pltype = drow["PLTYPE"].ToString();
        //                        pack_plqty = drow["PLQty"].ToString();
        //                        pack_palletqty = drow["PalletQTy"].ToString();
        //                        pack_planqty = drow["PlanQty"].ToString();
        //                        report_qty = Convert.ToDouble(drow["ReportQty"].ToString() != "" ? drow["ReportQty"].ToString() : "0");

        //                        // FIND DAILY PLAN
        //                        for (DateTime i = statDate; i <= endDate; i = i.AddDays(1))
        //                        {
        //                            SqlCommand sqlSelectDaily = new SqlCommand();
        //                            sqlSelectDaily.CommandText = @"SELECT ISNULL(D" + i.ToString("dd") + @", 0) AS PLAN_QTY 
        //                            FROM vi_WK_APS_PlanDailyReport 
        //                            WHERE WCNO = @WCNO AND LineName = @LineName AND Model = @Model AND YM = @YM AND PID = @PID";
        //                            sqlSelectDaily.Parameters.Add(new SqlParameter("@WCNO", wcno));
        //                            sqlSelectDaily.Parameters.Add(new SqlParameter("@LineName", subline));
        //                            sqlSelectDaily.Parameters.Add(new SqlParameter("@Model", mainCode));
        //                            sqlSelectDaily.Parameters.Add(new SqlParameter("@YM", i.ToString("yyyyMM")));
        //                            sqlSelectDaily.Parameters.Add(new SqlParameter("@PID", pid));
        //                            sqlSelectDaily.CommandTimeout = 180;
        //                            //if (mainCode == "JT100GCVDK@T-10" && (i.Date.ToString("ddMMyyyy") == "18062024" || i.Date.ToString("ddMMyyyy") == "19062024"))
        //                            //{
        //                            //    Console.WriteLine("asds");
        //                            //}
        //                            DataTable dtDailyPlan = dbSCM.Query(sqlSelectDaily);
        //                            if (dtDailyPlan.Rows.Count > 0)
        //                            {
        //                                foreach (DataRow ddrow in dtDailyPlan.Rows)
        //                                {
        //                                    double dailyplan = 0;
        //                                    double sequenceplan = 0;
        //                                    dailyplan = Convert.ToDouble(ddrow["PLAN_QTY"].ToString());

        //                                    if (total_gantt_plan >= dailyplan)
        //                                    {
        //                                        sequenceplan = dailyplan;
        //                                    }
        //                                    else
        //                                    {
        //                                        sequenceplan = total_gantt_plan;
        //                                    }

        //                                    total_gantt_plan = total_gantt_plan - sequenceplan;

        //                                    // UPDATE DAILY PLAN
        //                                    DateTime prdMonth = new DateTime(i.Year, i.Month, 1);
        //                                    SqlCommand sqlUpdate = new SqlCommand();
        //                                    sqlUpdate.CommandText = @"UPDATE WK_APS_PlanDailyReport SET Day" + i.Day + @" -= @SEQUENCEPLAN 
        //                                    WHERE WCNO = @WCNO AND LineName = @LineName AND Model = @Model AND PlanDate = @PlanDate AND PID = @PID";
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@SEQUENCEPLAN", sequenceplan));
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@WCNO", wcno));
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@PlanDate", prdMonth));
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@LineName", subline));
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@Model", mainCode));
        //                                    sqlUpdate.Parameters.Add(new SqlParameter("@PID", pid));
        //                                    dbSCM.ExecuteCommand(sqlUpdate);

        //                                    // INSERT SEQUENCE PLAN TABLE
        //                                    if (sequenceplan > 0)
        //                                    {
        //                                        DataRow[] sequence = dtSequencePlan.Select("PLANDATE = '" + i.ToString("yyyyMMdd") + "'");
        //                                        if (sequence.Length > 0)
        //                                        {
        //                                            DataRow drowSeq = dtSequencePlan.NewRow();
        //                                            drowSeq["PLANDATE"] = i.ToString("yyyyMMdd");
        //                                            drowSeq["SEQUENCE"] = (sequence.Length + 1).ToString("00000");
        //                                            drowSeq["WCNO"] = wcno;
        //                                            drowSeq["WCNAME"] = subline;
        //                                            drowSeq["MODEL"] = model;
        //                                            drowSeq["MODELCODE"] = modelCode;
        //                                            drowSeq["PARTNO"] = mainCode;
        //                                            drowSeq["PLANQTY"] = sequenceplan;
        //                                            drowSeq["PLANCODE"] = planCode;
        //                                            drowSeq["PACKPLANCODE"] = packplancode;
        //                                            drowSeq["PACK_PLTYPE"] = pack_pltype;
        //                                            drowSeq["PACK_PLQTY"] = pack_plqty;
        //                                            drowSeq["PACK_PLANQTY"] = pack_planqty;
        //                                            drowSeq["PACK_PALLETQTY"] = pack_palletqty;
        //                                            drowSeq["REPORT_QTY"] = report_qty;
        //                                            dtSequencePlan.Rows.Add(drowSeq);
        //                                        }
        //                                        else
        //                                        {
        //                                            DataRow drowSeq = dtSequencePlan.NewRow();
        //                                            drowSeq["PLANDATE"] = i.ToString("yyyyMMdd");
        //                                            drowSeq["SEQUENCE"] = "00001";
        //                                            drowSeq["WCNO"] = wcno;
        //                                            drowSeq["WCNAME"] = subline;
        //                                            drowSeq["MODEL"] = model;
        //                                            drowSeq["MODELCODE"] = modelCode;
        //                                            drowSeq["PARTNO"] = mainCode;
        //                                            drowSeq["PLANQTY"] = sequenceplan;
        //                                            drowSeq["PLANCODE"] = planCode;
        //                                            drowSeq["PACK_PLTYPE"] = pack_pltype;
        //                                            drowSeq["PACK_PLQTY"] = pack_plqty;
        //                                            drowSeq["PACK_PLANQTY"] = pack_planqty;
        //                                            drowSeq["PACK_PALLETQTY"] = pack_palletqty;
        //                                            drowSeq["REPORT_QTY"] = report_qty;
        //                                            dtSequencePlan.Rows.Add(drowSeq);
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                SqlCommand sqlDelete = new SqlCommand();
        //                sqlDelete.CommandText = @"DELETE FROM WK_APS_PlanDailyReport WHERE PID = @PID";
        //                sqlDelete.Parameters.Add(new SqlParameter("@PID", pid));
        //                sqlDelete.CommandTimeout = 180;
        //                dbSCM.ExecuteCommand(sqlDelete);

        //                if (dtSequencePlan.Rows.Count > 0)
        //                {
        //                    DataRow[] drowPlan = dtSequencePlan.Select("PLANDATE >= '" + plan_startDate + "' AND PLANDATE <= '" + plan_endDate + "'");
        //                    if (drowPlan.Length > 0)
        //                    {
        //                        foreach (DataRow pnrow in drowPlan)
        //                        {
        //                            DateTime loopDate = DateTime.ParseExact(pnrow["PLANDATE"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
        //                            string _model = pnrow["MODEL"].ToString();

        //                            PriorityPlanInfo planinfo = new PriorityPlanInfo();
        //                            planinfo.P_startdate = pnrow["PLANDATE"].ToString();
        //                            planinfo.P_StartDateT = loopDate;
        //                            planinfo.P_starttime = pnrow["SEQUENCE"].ToString();
        //                            planinfo.P_wcno = wcno;
        //                            planinfo.P_group = subline;
        //                            planinfo.P_mc = pnrow["PARTNO"].ToString();
        //                            planinfo.P_modelcode = pnrow["MODELCODE"].ToString();
        //                            planinfo.P_model = pnrow["MODEL"].ToString();
        //                            planinfo.P_planqty = Convert.ToDouble(pnrow["PLANQTY"].ToString());
        //                            planinfo.subline = subline;

        //                            decimal plnPalletQty = 0, plqty = 0;
        //                            int palletcount = 0;
        //                            try
        //                            {
        //                                plnPalletQty = Convert.ToDecimal(pnrow["PLANQTY"].ToString());
        //                            }
        //                            catch { }

        //                            try
        //                            {
        //                                plqty = Convert.ToDecimal(pnrow["PACK_PLQTY"].ToString());
        //                            }
        //                            catch { }

        //                            try
        //                            {
        //                                palletcount = (int)Math.Ceiling(plnPalletQty / plqty);

        //                            }
        //                            catch { }


        //                            List<PackingData> packingList = new List<PackingData>();
        //                            PackingData pck = new PackingData();
        //                            pck.P_MODEL = _model;
        //                            pck.P_PACKING = pnrow["PACK_PLTYPE"].ToString(); // +" ["+ pnrow["PACK_PLQTY"].ToString() + "]";
        //                            pck.P_QTYPLAN = Convert.ToDecimal(pnrow["PACK_PLANQTY"].ToString());
        //                            pck.P_QTYSTD = Convert.ToDecimal(pnrow["PACK_PLQTY"].ToString());
        //                            pck.P_PALLETQTY = Convert.ToDecimal(palletcount.ToString());
        //                            pck.P_REPORT_QTY = Convert.ToDecimal(pnrow["REPORT_QTY"].ToString());
        //                            pck.P_comment = "";
        //                            packingList.Add(pck);
        //                            planinfo.PackingList = packingList;

        //                            planList.Add(planinfo);
        //                        }
        //                    }
        //                }
        //            }
        //            return Ok(new
        //            {
        //                sequence = planList,
        //                interactive = rApsModelInteractive
        //            });
        //        }

        //[HttpPost]
        //[Route("/Aps/GetProdPlan")]
        //public IActionResult GetApsProductionPlan([FromBody] ParamGetProductionPlan param)
        //{
        //    DateTime ymd = DateTime.ParseExact(param.ymd, "yyyyMMdd", CultureInfo.InvariantCulture);

        //    SqlCommand sqlGetDictPart = new SqlCommand();
        //    sqlGetDictPart.CommandText = @"  SELECT [DESCRIPTION] AS MODEL,  CODE AS PARTNO,REF2 AS PARTNAME,REF1 AS WCNO,REF3 AS CM,NOTE AS PART_GROUP FROM [dbSCM].[dbo].[DictMstr]  where  DICT_SYSTEM = 'WIP_STOCK' AND DICT_TYPE LIKE 'PART_SET_IN%'  AND DICT_STATUS = 'ACTIVE' GROUP BY [DESCRIPTION],CODE,REF2,REF1,REF3,NOTE";
        //    DataTable dtDictPart = dbSCM.Query(sqlGetDictPart);

        //    string subLine = param.subLine != null ? param.subLine : "";
        //    string CondSubLine = $" AND SUBLINE = '{subLine}'";

        //    //=======================================//
        //    //================ GET WIP ==============//
        //    //=======================================//
        //    List<EkbWipPartStock> rWip = new List<EkbWipPartStock>();
        //    SqlCommand sqlGetWip = new SqlCommand();
        //    sqlGetWip.CommandText = $@"SELECT A.[WCNO] ,A.[PARTNO] ,A.[CM] ,A.[BAL] ,B.PART_GROUP FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK]  A LEFT JOIN (SELECT   REF2 AS PARTNO,REF3 AS CM,NOTE AS PART_GROUP  FROM [dbSCM].[dbo].[DictMstr]  where DICT_SYSTEM = 'WIP_STOCK' and DICT_TYPE LIKE 'PART_SET_%' AND DICT_STATUS = 'ACTIVE' GROUP BY  REF2,REF3,NOTE ) B ON B.PARTNO = A.PARTNO WHERE A.Ptype IS NULL AND A.YM = '{ymd.ToString("yyyyMM")}' AND A.WCNO = '904' ";
        //    DataTable dtWip = dbSCM.Query(sqlGetWip);
        //    foreach (DataRow dr in dtWip.Rows)
        //    {
        //        EkbWipPartStock mWip = new EkbWipPartStock();
        //        mWip.Wcno = dr["WCNO"].ToString();
        //        mWip.Partno = dr["PARTNO"].ToString();
        //        mWip.Cm = dr["CM"].ToString();
        //        mWip.Ptype = dr["PART_GROUP"].ToString();
        //        mWip.Bal = oHelper.ConvStr2Dec(dr["BAL"].ToString()!);
        //        rWip.Add(mWip);
        //    }

        //    //=======================================//
        //    //============ GET APS PLAN =============//
        //    //=======================================//
        //    List<PropsProducionPlan> rPlan = new List<PropsProducionPlan>();
        //    SqlCommand sqlGetProdPlan = new SqlCommand();
        //    sqlGetProdPlan.CommandText = $@"SELECT * FROM [dbSCM].[dbo].[APS_ProductionPlan] WHERE LREV = '999' AND APS_PlanDate = '{ymd.ToString("yyyy-MM-dd")}' AND WCNO = '904' {CondSubLine}";
        //    DataTable dtProdPlan = dbSCM.Query(sqlGetProdPlan);
        //    foreach (DataRow dr in dtProdPlan.Rows)
        //    {
        //        PropsProducionPlan mPlan = new PropsProducionPlan();
        //        mPlan.wcno = dr["WCNO"].ToString()!;
        //        mPlan.prdPlanCode = dr["PRD_PlanCode"].ToString()!;
        //        mPlan.partNo = dr["PartNo"].ToString()!;
        //        mPlan.cm = dr["CM"].ToString()!;
        //        mPlan.subLine = dr["SUBLINE"].ToString()!;
        //        mPlan.apsSeq = dr["APS_SEQ"].ToString()!;
        //        mPlan.apsPlanQty = oHelper.ConvStr2Dec(dr["APS_PlanQty"].ToString()!);
        //        mPlan.prdSeq = dr["PRD_SEQ"].ToString()!;
        //        mPlan.prdPlanQty = oHelper.ConvStr2Dec(dr["PRD_PlanQty"].ToString()!);


        //        string modelName = mPlan.partNo;
        //        string input = modelName;
        //        char character = '-';
        //        int lastIndex = input.LastIndexOf(character);
        //        if (lastIndex != -1)
        //        {
        //            modelName = input.Substring(0, lastIndex);
        //        }

        //        var PartOfModel = dtDictPart.AsEnumerable().Where(row => (string)row["MODEL"] == modelName);
        //        List<string> rPartOfModel = new List<string>();
        //        foreach (var oPart in PartOfModel)
        //        {
        //            rPartOfModel.Add(oPart["PARTNAME"].ToString());
        //        }
        //        List<EkbWipPartStock> rWipOfModel = rWip.Where(x => x.Wcno == mPlan.wcno && rPartOfModel.Contains(x.Partno)).ToList();

        //        // GET & SET ==> STATOR
        //        EkbWipPartStock oStator = rWipOfModel.FirstOrDefault(x => x.Ptype == "STATOR")!;
        //        if (oStator != null)
        //        {
        //            mPlan.statorMain = Convert.ToDecimal(oStator.Bal!);
        //        }
        //        // GET & SET ==> ROTOR
        //        EkbWipPartStock oRotor = rWipOfModel.FirstOrDefault(x => x.Ptype == "ROTOR")!;
        //        if (oRotor != null)
        //        {
        //            mPlan.rotorMain = Convert.ToDecimal(oRotor.Bal!);
        //        }
        //        // GET & SET ==> HS
        //        EkbWipPartStock oHousing = rWipOfModel.FirstOrDefault(x => x.Ptype == "HS")!;
        //        if (oHousing != null)
        //        {
        //            mPlan.housingMain = Convert.ToDecimal(oHousing.Bal!);
        //        }

        //        EkbWipPartStock oCs = rWipOfModel.FirstOrDefault(x => x.Ptype == "CS")!;
        //        if (oCs != null)
        //        {
        //            mPlan.housingMain = Convert.ToDecimal(oCs.Bal!);
        //        }


        //        //// GET & SET ==> CS
        //        //EkbWipPartStock oCrankShaft = rWip.FirstOrDefault(x => x.Wcno == mPlan.wcno && x.Partno == mPlan.partNo && x.Ptype == "STATOR")!;
        //        //if (oCrankShaft != null)
        //        //{
        //        //    mPlan.statorMain = Convert.ToDecimal(oCrankShaft.Bal!);
        //        //}
        //        //// GET & SET ==> FS/OS
        //        //mPlan.statorMain = Convert.ToDecimal(rWip.Where(x => x.Wcno == mPlan.wcno && x.Partno == mPlan.partNo && (x.Ptype == "OF" || x.Ptype == "OS")).ToList().Sum(x => x.Bal));
        //        //// GET & SET ==> LW
        //        //EkbWipPartStock oLW = rWip.FirstOrDefault(x => x.Wcno == mPlan.wcno && x.Partno == mPlan.partNo && x.Ptype == "LW")!;
        //        //if (oLW != null)
        //        //{
        //        //    mPlan.statorMain = Convert.ToDecimal(oLW.Bal!);
        //        //}


        //        rPlan.Add(mPlan);
        //    }
        //    return Ok(rPlan);
        //}

        //[HttpGet]
        //[Route("/ApsProductionPlan/get/{ymd}")]
        //public IActionResult GetApsProductionPlan(string ymd)
        //{
        //    //DateTime dtNow = oHelper.ConvStrToDate(ymd);
        //    //List<ApsProductionPlan> rApsProdPlan = efSCM.ApsProductionPlans.Where(x => x.Subline == "ASSEMBLY LINE4 (SCR)" && x.Lrev == "999" && x.ApsPlanDate >= dtNow.Date && x.ApsPlanDate <= dtNow.AddDays(2).Date).OrderBy(x => x.ApsPlanDate).ThenBy(x => x.PrdSeq).ToList();
        //    List<ApsSublineStockBalance> StockBalances = efSCM.ApsSublineStockBalances.FromSqlRaw($"SELECT  *  FROM [dbSCM].[dbo].[APS_SUBLINE_STOCK_BALANCE] WHERE YM = '{ymd.Substring(0, 6)}' AND YMD = '{ymd}' AND APS_Result > 0 ").ToList();
        //    List<FGPlanInfo> MainPlans = oSrvMP.getMainPlan(ymd, "904", StockBalances);
        //    return Ok(MainPlans);
        //}

        [HttpGet]
        [Route("/aps/dictmstr/reason")]
        public IActionResult GetReason()
        {
            List<DictMstr> rReason = efSCM.DictMstrs.Where(x => x.DictSystem == "APS" && x.DictType == "REASON" && x.DictStatus == "ACTIVE").ToList();
            return Ok(rReason);
        }

        [HttpGet]
        [Route("/aps/gastight/get/{date}")]
        public IActionResult GetApsGasTight(string date)
        {
            DateTime dtNow = oHelper.ConvStrToDate(date);
            List<string> rPartAchieve = new List<string>();
            List<WipProps> rData = new List<WipProps>();

            // ========================== //
            // ======== GET DICT ======== //
            // ========================== //
            List<DictMstr> rDict = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType.StartsWith("PART_SET_IN")).ToList();

            // ===========================//
            // ======= GET STOCK WIP =====//
            // ===========================//
            List<EkbWipPartStock> rWip = new List<EkbWipPartStock>();
            SqlCommand sqlGetStockWip = new SqlCommand();
            sqlGetStockWip.CommandText = @"SELECT [WCNO],TRIM([PARTNO]) AS PARTNO,[CM],[BAL] FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK] where ym = @YM";
            sqlGetStockWip.Parameters.Add(new SqlParameter("@YM", dtNow.ToString("yyyyMM")));
            DataTable dtStockWip = dbSCM.Query(sqlGetStockWip);
            foreach (DataRow drWip in dtStockWip.Rows)
            {
                EkbWipPartStock oWip = new EkbWipPartStock();
                oWip.Partno = drWip["PARTNO"].ToString();
                oWip.Cm = drWip["CM"].ToString();
                oWip.Wcno = drWip["WCNO"].ToString();
                oWip.Bal = drWip["BAL"].ToString() != "" ? decimal.Parse(drWip["BAL"].ToString()) : 0;
                rWip.Add(oWip);
            }

            // ===========================//
            // ======= GET GASTIGTH ======//
            // ===========================//
            SqlCommand sqlGasTight = new SqlCommand();
            sqlGasTight.CommandText = @"SELECT * FROM (SELECT COUNT(Serial) AS CNT,SUBSTRING(GAS.serial,1,4) AS SEBANGO,DATEPART(hour, DATEADD(hour,-8,Insert_Date))+8 [HOUR] FROM [192.168.226.145].[dbIoT].[dbo].[SCR_GasTight] GAS
  WHERE  FORMAT(DATEADD(hour,-8, GAS.Insert_Date), 'yyyyMMdd') = @DATE_START_M AND GAS.serial != 'ERROR'
  GROUP BY SUBSTRING(GAS.serial,1,4) ,DATEPART(hour, DATEADD(hour,-8,Insert_Date))+8 ) A
  order by A.HOUR DESC";
            sqlGasTight.Parameters.Add(new SqlParameter("@DATE_START_M", dtNow.ToString("yyyyMMdd")));
            DataTable dtGasTight = dbSCM.Query(sqlGasTight);
            foreach (DataRow drGasTight in dtGasTight.Rows)
            {

                string sebango = drGasTight["SEBANGO"].ToString();
                string time = drGasTight["HOUR"].ToString();
                double cnt = double.Parse(drGasTight["CNT"].ToString());

                WipProps oData = new WipProps();
                oData.sebango = sebango;
                oData.hour = time;
                oData.cnt = cnt;
                // ================================//
                // ======= GET PART BY MODEL ======//
                // ================================//
                List<DictMstr> rPartOfModel = rDict.Where(x => x.Code == sebango).ToList();
                if (rPartOfModel.Count > 0)
                {
                    oData.model = rPartOfModel[0].Description.Trim();
                    foreach (DictMstr oPart in rPartOfModel)
                    {
                        string wcno = oPart.Ref1;
                        string partno = oPart.Ref2;
                        string cm = oPart.Ref3;
                        string model = oPart.Description;
                        int indexWip = rWip.FindIndex(x => x.Partno == partno);
                        if (indexWip != -1)
                        {
                            //rWip[indexWip].qty += cnt;
                            oData.wip.Add(new PartProps()
                            {
                                wcno = wcno,
                                model = model,
                                partno = partno,
                                parttype = oPart.Note,
                                stock = rWip[indexWip].Bal
                            });
                        }
                    }
                }
                rData.Add(oData);
            }
            return Ok(rData);




            //            List<EkbWipPartStock> rWipBal = new List<EkbWipPartStock>();
            //            SqlCommand sqlWipBalance = new SqlCommand();
            //            sqlWipBalance.CommandText = @"SELECT TOP (1000) [DICT_ID]
            //      ,[DICT_SYSTEM]
            //      ,[DICT_TYPE]
            //      ,[CODE]
            //      ,[DESCRIPTION]
            //      ,[REF_CODE]
            //      ,[REF1]
            //      ,[REF2]
            //      ,[REF3]
            //      ,[REF4]
            //      ,[NOTE]
            //      ,[CREATE_DATE]
            //      ,[UPDATE_DATE]
            //      ,[DICT_STATUS]
            //  FROM [dbSCM].[dbo].[DictMstr]
            //  where DICT_SYSTEM = 'WIP_STOCK' and DICT_TYPE LIKE 'PART_SET_IN%' ";
            //            sqlWipBalance.Parameters.Add(new SqlParameter("@YM", dtNow.ToString("yyyyMM")));
            //            DataTable dtWipBal = dbSCM.Query(sqlWipBalance);
            //            foreach (DataRow drWipBal in dtWipBal.Rows)
            //            {
            //                EkbWipPartStock oWipBal = new EkbWipPartStock();
            //                oWipBal.wcno = drWipBal["WCNO"].ToString();
            //                oWipBal.ym = drWipBal["YM"].ToString();
            //                oWipBal.partno = drWipBal["PARTNO"].ToString();
            //                oWipBal.cm = drWipBal["CM"].ToString();
            //                oWipBal.qty = drWipBal["QTY"].ToString() != "" ? drWipBal["QTY"].ToString() : "0";
            //                rWipBal.Add(oWipBal);
            //            }


            //            DateTime dtFilter = DateTime.Now.AddDays(-2);
            //            //DateTime dtFilter = new DateTime(2024, 6, 24);
            //            List<ApsModelInterActiveProps> rApsModelInteractive = new List<ApsModelInterActiveProps>();
            //            SqlCommand sqlGetDataInteractive = new SqlCommand();
            //            sqlGetDataInteractive.CommandText = @"SELECT  DATEPART(hour, DATEADD(hour,-8,Insert_Date))+8 [hour], SUBSTRING(Serial,1,4)  modelCode, m.model as modelName, COUNT(Serial) cnt
            //FROM [dbIoT].[dbo].[SCR_GasTight]
            //LEFT JOIN (SELECT MODELCODE, MODEL FROM [192.168.226.86].dbSCM.dbo.PN_Compressor WHERE [Status]='ACTIVE' GROUP BY [ModelCode],[Model] ) m ON m.modelcode = SUBSTRING(Serial,1,4)
            //WHERE CAST(DATEADD(hour,-8, Insert_Date) AS DATE) >= @CURR_DATE
            //   and Serial != 'ERROR'
            //GROUP BY  SUBSTRING(Serial,1,4), m.model, DATEPART(hour, DATEADD(hour,-8,Insert_Date))
            //ORDER BY DATEPART(hour, DATEADD(hour,-8,Insert_Date)) ASC  
            //";
            //            sqlGetDataInteractive.Parameters.Add(new SqlParameter("@CURR_DATE", dtFilter.ToString("yyyy-MM-dd")));
            //            DataTable dtDataInterActive = dbIOT.Query(sqlGetDataInteractive);
            //            foreach (DataRow drInteractive in dtDataInterActive.Rows)
            //            {
            //                string model = drInteractive["modelName"].ToString();
            //                string sebango = drInteractive["modelCode"].ToString();
            //                string hour = drInteractive["hour"].ToString();
            //                ApsModelInterActiveProps mApsModelInterActive = new ApsModelInterActiveProps();
            //                mApsModelInterActive.time = drInteractive["hour"].ToString() != "" ? (Convert.ToInt16(drInteractive["hour"].ToString()).ToString("D2") + ":00") : "-";
            //                mApsModelInterActive.modelCode = drInteractive["modelCode"].ToString();
            //                mApsModelInterActive.modelName = drInteractive["modelName"].ToString();
            //                mApsModelInterActive.result = Convert.ToInt16(drInteractive["cnt"].ToString());
            //                // stator main & motor 
            //                EkbWipPartStock oStatorStock = rWipBal.FirstOrDefault(x => x.partno == model);
            //                double StockStator = oStatorStock != null ? double.Parse(oStatorStock.qty) : 0;
            //                //List<WipProps> rWipStatorMain = rWip.Where(x => x.sebango == sebango && x.hour == hour && x.parttype == "STATOR").ToList();
            //                //mApsModelInterActive.stator.main = StockStator - rWipStatorMain.Count;
            //                mApsModelInterActive.stator.main = StockStator;

            //                // rotor  main & motor
            //                //List<WipProps> rWipRotor = rWip.Where(x => x.sebango == sebango && x.hour == hour && x.parttype == "ROTOR").ToList();
            //                //mApsModelInterActive.rotor.main = rWipRotor.Count;

            //                // housing main & mc
            //                // cs main & mc
            //                // fs main & mc
            //                // os main & mc
            //                // lower main & mc
            //                // pipe main & casing 
            //                // top main & casing
            //                // bottom && casing
            //                rApsModelInteractive.Add(mApsModelInterActive);

            //            }
            //return Ok(rApsModelInteractive);
        }

        //[HttpPost]
        //[Route("/ApsPlanChangePrioriry")]
        //public IActionResult ApsPlanChangePrioriry([FromBody] List<ApsProductionPlan> ApsPlans)
        //{
        //    int action = 0;
        //    bool canUpdate = true;
        //    foreach (ApsProductionPlan ItemPlan in ApsPlans)
        //    {
        //        ApsProductionPlan oPlan = efSCM.ApsProductionPlans.FirstOrDefault(x => x.PrdPlanCode == ItemPlan.PrdPlanCode);
        //        if (oPlan != null)
        //        {
        //            oPlan.PrdSeq = ItemPlan.PrdSeq;
        //            oPlan.UpdBy = "System";
        //            oPlan.UpdDt = DateTime.Now;
        //            efSCM.Update(oPlan);
        //        }
        //        else
        //        {
        //            canUpdate = false;
        //        }
        //    }
        //    if (canUpdate == true)
        //    {
        //        action = efSCM.SaveChanges();
        //    }
        //    return Ok(new
        //    {
        //        status = action > 0 ? true : false
        //    });
        //}

        [HttpPost]
        [Route("/ApsUpdatePlan")]
        public IActionResult ApsUpdatePlan([FromBody] ApsUpdatePlanProps param)
        {
            int action = 0;
            string prdPlanCode = param.prdPlanCode;
            string reason = param.reasonCode;
            string remark = param.remark;
            ApsProductionPlan oPrdPlan = efSCM.ApsProductionPlans.FirstOrDefault(x => x.PrdPlanCode == prdPlanCode);
            if (oPrdPlan != null)
            {
                oPrdPlan.PrdPlanQty = param.prdPlanQty;
                efSCM.ApsProductionPlans.Update(oPrdPlan);
                action = efSCM.SaveChanges();
                if (action > 0 && (reason != "" || remark != "'"))
                {
                    ApsProductionPlanNotice lastNotice = efSCM.ApsProductionPlanNotices.Where(x => x.PrdPlanCode == prdPlanCode).ToList().OrderByDescending(x => x.CreDt).FirstOrDefault();
                    string nbr = "";

                    if (lastNotice != null)
                    {
                        int runningNum = Convert.ToInt16(lastNotice.NtNbr.Substring(lastNotice.NtNbr.Length - 3));
                        nbr = $"NOTICE{DateTime.Now.ToString("yyyyMMdd")}-{prdPlanCode}-{(runningNum + 1).ToString("D3")}";

                    }
                    else
                    {
                        nbr = $"NOTICE{DateTime.Now.ToString("yyyyMMdd")}-{prdPlanCode}-00001";
                    }
                    ApsProductionPlanNotice newNotice = new ApsProductionPlanNotice();
                    newNotice.NtNbr = nbr;
                    newNotice.PrdPlanCode = prdPlanCode;
                    newNotice.NtType = "NOTICE";
                    newNotice.NtCode = reason;
                    newNotice.NtObjectiveType = "";
                    newNotice.NtNotice = remark;
                    newNotice.CreBy = "SYSTEM";
                    newNotice.CreDt = DateTime.Now;
                    efSCM.ApsProductionPlanNotices.Add(newNotice);
                    efSCM.SaveChanges();
                }
            }
            return Ok(new
            {
                status = action > 0 ? true : false
            });
        }

        //[HttpPost]
        //[Route("/ApsInsertPlan")]
        //public IActionResult ApsInsertPlan([FromBody] ApsInsertPlanProps props)
        //{
        //    Random rnd = new Random();
        //    int action = 0;
        //    string message = "";
        //    string modelCode = props.modelCode;
        //    string prdPlanCodeRef = props.prdPlanCode;
        //    string empcode = props.empcode;
        //    int prdQty = props.prdQty;
        //    WmsMdw27ModelMaster modelDetail = efSCM.WmsMdw27ModelMasters.FirstOrDefault(x => x.Sebango == oHelper.ConvStr2Int(modelCode).ToString("D4"));
        //    if (modelDetail != null)
        //    {
        //        ApsProductionPlan lastPrdPlan = efSCM.ApsProductionPlans.OrderBy(x => x.ApsPlanDate).ThenBy(x => x.PrdSeq).FirstOrDefault(x => x.PrdPlanCode == prdPlanCodeRef);
        //        if (lastPrdPlan != null)
        //        {
        //            ApsProductionPlan LastSeqOfDate = efSCM.ApsProductionPlans.OrderBy(x => x.ApsPlanDate).ThenBy(x => x.PrdSeq).FirstOrDefault(x => x.ApsPlanDate == lastPrdPlan.ApsPlanDate && x.Wcno == lastPrdPlan.Wcno && x.Subline == lastPrdPlan.Subline && x.ApsDistribute == lastPrdPlan.ApsDistribute && x.Rev == lastPrdPlan.Rev && x.Lrev == lastPrdPlan.Lrev);
        //            string wcno = lastPrdPlan.Wcno;
        //            int prdSequence = Convert.ToInt16(LastSeqOfDate.PrdSeq) + 1;
        //            string modelName = modelDetail.Model;
        //            ApsProductionPlan newProductionPlan = new ApsProductionPlan();
        //            newProductionPlan.PrdPlanCode = $"APS{DateTime.Now.ToString("yyyyMMdd")}-{rnd.Next(1, 10000).ToString("D5")}-{prdSequence.ToString("D5")}";
        //            newProductionPlan.Wcno = wcno;
        //            newProductionPlan.Subline = lastPrdPlan.Subline;
        //            newProductionPlan.ApsSeq = "0";
        //            newProductionPlan.ApsPlanDate = lastPrdPlan.ApsPlanDate;
        //            newProductionPlan.ApsDistribute = lastPrdPlan.ApsDistribute;
        //            newProductionPlan.PrdSeq = prdSequence.ToString();
        //            newProductionPlan.PartNo = modelName;
        //            newProductionPlan.Cm = "";
        //            newProductionPlan.ApsPlanQty = 0;
        //            newProductionPlan.PrdPlanQty = prdQty;
        //            newProductionPlan.Rev = lastPrdPlan.Rev;
        //            newProductionPlan.Lrev = lastPrdPlan.Lrev;
        //            newProductionPlan.CreBy = "PRD";
        //            newProductionPlan.CreDt = DateTime.Now;
        //            newProductionPlan.UpdBy = "PRD";
        //            newProductionPlan.UpdDt = DateTime.Now;
        //            efSCM.ApsProductionPlans.Add(newProductionPlan);
        //            action = efSCM.SaveChanges();
        //            if (action > 0)
        //            {
        //                ApsProductionPlanNotify newNotify = new ApsProductionPlanNotify();
        //                newNotify.Wcno = wcno;
        //                newNotify.LineType = "SUBLINE";
        //                newNotify.ChangeDt = DateTime.Now;
        //                newNotify.SubLine = lastPrdPlan.Subline;
        //                newNotify.NotifyDt = DateTime.Now;
        //                newNotify.AckBy = empcode;
        //                newNotify.AckStatus = "NOTIFY";
        //                efSCM.ApsProductionPlanNotifies.Add(newNotify);
        //            }
        //        }
        //        else
        //        {
        //            action = 0;
        //            message = $"ไม่พบข้อมูล PrdPlanCode : {prdPlanCodeRef} ที่ใช้สำหรับอ้างอิงการสร้างแผนการผลิต ";
        //        }
        //    }
        //    else
        //    {
        //        action = 0;
        //        message = $"ไม่พบข้อมูล model : {modelCode} ที่ฐานข้อมูล [SCM].[WmsMdw27ModelMasters] ";
        //    }
        //    return Ok(new
        //    {
        //        status = action > 0 ? true : false,
        //        message = message
        //    });
        //}

        [HttpPost]
        [Route("/ApsGetDrawing")]
        public IActionResult ApsGetPart([FromBody] ParamGetPart param)
        {
            string type = param.type;
            string group = param.group.ToUpper();
            if (type == "MAIN")
            {
                var rModels = efSCM.WmsMdw27ModelMasters.Where(x => x.Active == "ACTIVE" && (group != "" ? x.Modelgroup == group : true)).OrderBy(x => x.Model).GroupBy(x => new
                {
                    modelName = x.Model,
                    modelCode = x.Sebango
                }).Select(o => new
                {
                    o.Key.modelName,
                    o.Key.modelCode,
                }).ToList();
                return Ok(rModels);
            }
            else if (type == "SUBLINE")
            {
                string COND_GROUP = group != "" ? (group == "FS" ? (" AND (NOTE = 'FS' OR NOTE = 'OS')") : (" AND NOTE = '" + group + "'")) : "";
                List<PropsPart> rPart = new List<PropsPart>();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = $@"SELECT  [REF2] AS PARTNO ,[REF3]  AS CM,DESCRIPTION AS WCNO FROM [dbSCM].[dbo].[DictMstr] WHERE DICT_SYSTEM = 'WIP_STOCK' AND DICT_TYPE ='WC_MASTER' {COND_GROUP} AND DICT_STATUS = 'ACTIVE' GROUP BY REF2,REF3,DESCRIPTION ORDER BY REF2";
                DataTable dt = dbSCM.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    PropsPart oPart = new PropsPart();
                    oPart.wcno = dr["WCNO"].ToString();
                    oPart.modelName = dr["CM"].ToString();
                    oPart.modelCode = dr["PARTNO"].ToString();
                    rPart.Add(oPart);
                }
                return Ok(rPart);
            }
            return Ok();
        }
        [HttpPost]
        [Route("/Aps/GetBackflush")]
        public IActionResult ApsResult([FromBody] PropsGetBackflashData param)
        {
            string wc = param.wc;
            string ym = DateTime.ParseExact(param.ymd, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyyMM");
            string ymd = param.ymd;

            List<DictMstr> rDictMstr = new List<DictMstr>();
            SqlCommand sqlGetDictModel = new SqlCommand();
            sqlGetDictModel.CommandText = @"SELECT CODE ,REF2 FROM [dbSCM].[dbo].[DictMstr] WHERE DICT_SYSTEM = 'WIP_STOCK'  AND  DICT_TYPE like 'PART_SET_IN%' AND DICT_STATUS = 'ACTIVE'  AND REF1 = '904' AND CODE IS NOT NULL  GROUP  BY CODE,REF2";
            DataTable dtDictModel = dbSCM.Query(sqlGetDictModel);

            //List<EkbWipPartStockTransaction> rEkbTransaction = efSCM.EkbWipPartStockTransactions.Where(x => x.Ym == ymd.Substring(0, 6) && x.Ymd == ymd && x.RefNo == "UploadResult (IT)").ToList();
            List<EkbWipPartStockTransaction> rEkbTransaction = new List<EkbWipPartStockTransaction>();
            SqlCommand sqlGetWIP = new SqlCommand();
            sqlGetWIP.CommandText = $@"SELECT A.* FROM (SELECT *,PARTNO+CM PCM FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]
  WHERE YM = '{ym}' AND YMD = '{ymd}' AND RefNo = 'UploadResult (IT)' AND PARTNO+CM IN ( SELECT REF2+REF3 PCM FROM DictMstr WHERE (DICT_TYPE  LIKE 'PART_SET%' OR DICT_TYPE LIKE 'WC_MASTER')  
  GROUP BY REF2+REF3)) A";
            DataTable dtWip = dbSCM.Query(sqlGetWIP);
            foreach (DataRow dr in dtWip.Rows)
            {
                EkbWipPartStockTransaction oWip = new EkbWipPartStockTransaction()
                {
                    Nbr = dr["nbr"].ToString(),
                    Ym = dr["YM"].ToString(),
                    Ymd = dr["YMD"].ToString(),
                    Shift = dr["SHIFT"].ToString(),
                    Wcno = dr["WCNO"].ToString(),
                    Partno = dr["PARTNO"].ToString(),
                    Cm = dr["CM"].ToString(),
                    TransType = dr["TransType"].ToString(),
                    TransQty = oHelper.ConvStr2Dec(dr["TransQty"].ToString()),
                    QrcodeData = dr["QRCodeData"].ToString(),
                    CreateBy = dr["CreateBy"].ToString(),
                    CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString()),
                    RefNo = dr["RefNo"].ToString(),
                };
                rEkbTransaction.Add(oWip);
            }
            List<PartGroupMaster> rPartGroup = new List<PartGroupMaster>();
            List<string> rLine = new List<string>();
            SqlCommand sqlSplitLine = new SqlCommand();
            sqlSplitLine.CommandText = @"SELECT DISTINCT [LineSub] AS PART_GROUP FROM [dbSCM].[dbo].[AL_WC_Master] where grpCode IN ('2200','2300') AND LineType = @WC and LineSub != ''";
            sqlSplitLine.Parameters.Add(new SqlParameter("@WC", wc));
            DataTable dtLine = dbSCM.Query(sqlSplitLine);
            foreach (DataRow drLine in dtLine.Rows)
            {
                rLine.Add(drLine["PART_GROUP"].ToString());
            }
            List<DictMstr> rModelStandard = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "MODEL_STANDARD").ToList();
            if (rLine.Count > 0)
            {
                SqlCommand sqlGetPartGroup = new SqlCommand();
                string commaSeparatedString = string.Join(", ", rLine.Select(line => $"'{line}'"));
                sqlGetPartGroup.CommandText = $@"SELECT A.[DESCRIPTION] AS WCNO,A.REF2 AS PARTNO,A.REF3 AS CM ,B.DESCRIPTION AS PART_GROUP_NAME,A.REF4 AS MODEL_COMMON,A.NOTE AS PART_GROUP ,C.NOTE
FROM [dbSCM].[dbo].[DictMstr]  A
LEFT JOIN [dbSCM].[dbo].[DictMstr] B
ON B.CODE = A.NOTE 
LEFT JOIN (SELECT REF_CODE,NOTE FROM [dbSCM].[dbo].[DictMstr] WHERE DICT_TYPE = 'SUB_LINE_SORT' AND  REF_CODE IN ({commaSeparatedString})) C
ON C.REF_CODE = A.NOTE
WHERE  A.DICT_type = 'WC_MASTER' AND A.NOTE != ''  AND A.NOTE IN ({commaSeparatedString})  AND B.DICT_SYSTEM = 'WIP_STOCK' AND B.DICT_TYPE = 'PART_GROUP_MASTER'
ORDER BY C.NOTE ASC";
                DataTable dtPartGroup = dbSCM.Query(sqlGetPartGroup);
                foreach (DataRow drPartGroup in dtPartGroup.Rows)
                {
                    PartGroupMaster oPartGroup = new PartGroupMaster();
                    oPartGroup.wcno = drPartGroup["WCNO"].ToString();
                    oPartGroup.model_common = drPartGroup["MODEL_COMMON"].ToString();
                    oPartGroup.partno = drPartGroup["PARTNO"].ToString();
                    oPartGroup.cm = drPartGroup["CM"].ToString();
                    oPartGroup.part_group = drPartGroup["PART_GROUP"].ToString();
                    oPartGroup.part_group_name = drPartGroup["PART_GROUP_NAME"].ToString();

                    string JoinModel = "";
                    try
                    {
                        DataRow[] rRowModel = dtDictModel.Select($" REF2 LIKE '%{oPartGroup.partno}%'");
                        JoinModel = string.Join(", ", rRowModel.Select(row => row["CODE"].ToString()));
                    }
                    catch
                    {
                        JoinModel = "";
                    }
                    oPartGroup.modelcode = JoinModel;

                    List<DictMstr> oModelStandard = rModelStandard.Where(x => x.Code == oPartGroup.model_common && x.Note == oPartGroup.partno).ToList();
                    if (oModelStandard.Count > 0)
                    {
                        oPartGroup.stdMC = oModelStandard.FirstOrDefault(x => x.RefCode == "MC") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "MC").Ref1) : 0;
                        oPartGroup.stdCTMC = oModelStandard.FirstOrDefault(x => x.RefCode == "CT/MC") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CT/MC").Ref1) : 0;
                        oPartGroup.stdCT = oModelStandard.FirstOrDefault(x => x.RefCode == "CT") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CT").Ref1) : 0;
                        oPartGroup.stdCapHR = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "HR") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "HR").Ref1) : 0;
                        oPartGroup.stdCapShift = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "SHIFT") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "SHIFT").Ref1) : 0;
                        oPartGroup.stdCapDay = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "DAY") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "DAY").Ref1) : 0;
                        oPartGroup.stdNeedDay = oModelStandard.FirstOrDefault(x => x.RefCode == "NEEDDAY") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "NEEDDAY").Ref1) : 0;
                    }
                    rPartGroup.Add(oPartGroup);
                }
            }
            List<EkbWipPartStock> rStockMain = efSCM.EkbWipPartStocks.Where(x => x.Ym == ym).ToList();
            return Ok(new
            {
                partGroupMaster = rPartGroup.GroupBy(x => new
                {
                    part = x.part_group,
                    partName = x.part_group_name,
                }).Select(x => new
                {
                    x.Key.part,
                    x.Key.partName
                }),
                parts = rPartGroup,
                data = rEkbTransaction,
                stockMain = rStockMain,
                modelStandard = rModelStandard
            });
        }

        //[HttpGet]
        //[Route("/ApsGetPartGroupMaster")]
        //public IActionResult ApsGetPartGroupMaster()
        //{
        //    List<DictMstr> rPartGroup = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "PART_GROUP_MASTER" && x.DictStatus == "ACTIVE").ToList();
        //    List<DictMstr> rPartSort = efSCM.DictMstrs.Where(x => x.DictType == "SUB_LINE_SORT" && x.DictStatus == "ACTIVE").OrderBy(x => x.Note).ToList();
        //    List<DictMstr> rPartMaster = (from a in rPartSort
        //                                  join b in rPartGroup
        //                                  on a.RefCode equals b.Code
        //                                  select b).ToList();
        //    return Ok(rPartMaster);
        //}

        [HttpPost]
        [Route("/Aps/UpdateBackflush")]
        public IActionResult ApsResultUpdate([FromBody] ApsUpdateResultParam param)
        {
            bool action = false;
            string createBy = param.createBy;
            string message = "";
            string period = param.period;
            string ym = param.ym;
            string wcno = param.wcno;
            string shift = param.shift;
            string partno = param.partno;
            DateTime ymd = DateTime.ParseExact(param.ymd, "yyyyMMdd", CultureInfo.InvariantCulture);
            string cm = param.cm;
            decimal qty = param.qty;
            decimal newQty = 0;
            List<EkbWipPartStockTransaction> rTransaction = efSCM.EkbWipPartStockTransactions.Where(x => x.Ym == ym && x.Ymd == ymd.ToString("yyyyMMdd") && x.Shift == param.shift && x.Wcno == wcno && x.Partno == partno && x.Cm == param.cm && x.TransType == param.type).ToList();
            EkbWipPartStockTransaction oTransaction = rTransaction.FirstOrDefault(x => x.QrcodeData == period.ToString());
            if (oTransaction != null)
            {
                newQty = qty - Convert.ToDecimal(oTransaction.TransQty);

                decimal TotalTransaction = oHelper.ConvStr2Dec(rTransaction.Sum(x => x.TransQty).ToString()) + newQty;


                string nbr = oTransaction.Nbr;
                try
                {
                    if (oTransaction.TransQty != qty)
                    {
                        decimal? beforeQty = oTransaction.TransQty;
                        oTransaction.TransQty = qty;
                        efSCM.EkbWipPartStockTransactions.Update(oTransaction);
                        int update = efSCM.SaveChanges();
                        if (update > 0)
                        {
                            action = true;
                            EkbWipPartStock oWipStock = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Ym == ym && x.Wcno == wcno && x.Partno == partno && x.Cm == cm);
                            if (oWipStock != null)
                            {
                                oWipStock.Recqty = oWipStock.Recqty + newQty;
                                oWipStock.Bal = oWipStock.Bal + newQty;
                                oWipStock.UpdateBy = createBy;
                                oWipStock.UpdateDate = DateTime.Now;
                                efSCM.EkbWipPartStocks.Update(oWipStock);
                                int UpdateWip = efSCM.SaveChanges();
                            }
                            else
                            {
                                EkbWipPartStock newWipStock = new EkbWipPartStock();
                                newWipStock.Ym = ym;
                                newWipStock.Wcno = wcno;
                                newWipStock.Partno = partno;
                                newWipStock.Cm = cm;
                                newWipStock.PartDesc = "";
                                newWipStock.Lbal = 0;
                                newWipStock.Recqty = newQty;
                                newWipStock.Issqty = 0;
                                newWipStock.Bal = newQty;
                                newWipStock.UpdateBy = "APS BACKFLUSH UPLOAD";
                                newWipStock.UpdateBy = createBy;
                                efSCM.EkbWipPartStocks.Add(newWipStock);
                                int InsertWip = efSCM.SaveChanges();
                            }

                            PdBackflushFormulaDatum oBackflshTotal = efSCM.PdBackflushFormulaData.FirstOrDefault(x => x.Wcno == wcno && x.Pddate.Date == ymd.Date && x.Shift == shift && x.Drawing == partno && x.Cm == cm);
                            if (oBackflshTotal != null)
                            {
                                oBackflshTotal.Qty = oHelper.ConvDec2Int(TotalTransaction);
                                efSCM.PdBackflushFormulaData.Update(oBackflshTotal);
                                int UpdateBackflushTotal = efSCM.SaveChanges();
                            }
                            else
                            {

                                PdBackflushFormulaDatum newBackflushTotal = new PdBackflushFormulaDatum();
                                newBackflushTotal.Pddate = ymd;
                                newBackflushTotal.Shift = shift;
                                newBackflushTotal.Wcno = wcno;
                                newBackflushTotal.Drawing = partno;
                                newBackflushTotal.Cm = cm;
                                newBackflushTotal.UpdateDate = DateTime.Now;
                                newBackflushTotal.Ftype = "N";
                                newBackflushTotal.Fno = "";
                                newBackflushTotal.Qty = oHelper.ConvDec2Int(TotalTransaction);
                                newBackflushTotal.UpdateBy = "AUTO IOT";
                                newBackflushTotal.Alpha = "";
                                newBackflushTotal.Remark = "";
                                efSCM.PdBackflushFormulaData.Add(newBackflushTotal);
                                int InsertBackflushTotal = efSCM.SaveChanges();
                            }
                        }
                        else
                        {
                            action = false;
                            message = "APS-UPDATE-RESULT-001 (UPDATE)";
                        }
                    }
                    else // ไม่มีการเปลี่ยนแปลง
                    {
                        action = true;
                    }
                }
                catch (Exception e)
                {
                    action = false;
                    message = "APS-UPDATE-RESULT-002 (CATCH)" + e.Message;
                }
            }
            else
            {
                RunNumberService svrRunning = new RunNumberService();
                string nbr = svrRunning.LoadUnique("EKB").ToString(true);
                svrRunning.NextId("EKB");
                EkbWipPartStockTransaction mTransaction = new EkbWipPartStockTransaction();
                mTransaction.Nbr = nbr;
                mTransaction.Ym = param.ym;
                mTransaction.Ymd = param.ymd;
                mTransaction.Wcno = param.wcno;
                mTransaction.Shift = param.shift;
                mTransaction.Partno = param.partno;
                mTransaction.Cm = param.cm;
                mTransaction.TransQty = param.qty;
                mTransaction.TransType = param.type;
                mTransaction.QrcodeData = param.period.ToString();
                mTransaction.CreateBy = param.createBy;
                mTransaction.CreateDate = DateTime.Now;
                mTransaction.RefNo = "UploadResult (IT)";
                efSCM.EkbWipPartStockTransactions.Add(mTransaction);
                int insert = efSCM.SaveChanges();
                if (insert > 0)
                {
                    newQty = param.qty;
                    action = true;
                    EkbWipPartStock oWipStock = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Ym == ym && x.Wcno == wcno && x.Partno == partno && x.Cm == cm);
                    if (oWipStock != null)
                    {
                        oWipStock.Recqty = oWipStock.Recqty + newQty;
                        oWipStock.Bal = oWipStock.Bal + newQty;
                        oWipStock.UpdateBy = createBy;
                        oWipStock.UpdateDate = DateTime.Now;
                        efSCM.EkbWipPartStocks.Update(oWipStock);
                        int UpdateWip = efSCM.SaveChanges();
                    }
                    else
                    {
                        EkbWipPartStock newWipStock = new EkbWipPartStock();
                        newWipStock.Ym = ym;
                        newWipStock.Wcno = wcno;
                        newWipStock.Partno = partno;
                        newWipStock.Cm = cm;
                        newWipStock.PartDesc = "";
                        newWipStock.Lbal = 0;
                        newWipStock.Recqty = newQty;
                        newWipStock.Issqty = 0;
                        newWipStock.Bal = newQty;
                        newWipStock.UpdateBy = "APS BACKFLUSH UPLOAD";
                        newWipStock.UpdateBy = createBy;
                        efSCM.EkbWipPartStocks.Add(newWipStock);
                        int InsertWip = efSCM.SaveChanges();
                    }
                    List<EkbWipPartStockTransaction> oTransactions = efSCM.EkbWipPartStockTransactions.Where(x => x.Ym == ym && x.Ymd == ymd.ToString("yyyyMMdd") && x.Shift == param.shift && x.Wcno == wcno && x.Partno == partno && x.Cm == param.cm && x.TransType == param.type).ToList();

                    decimal TotalTransaction = oHelper.ConvStr2Dec(oTransactions.Sum(x => x.TransQty).ToString());
                    PdBackflushFormulaDatum oBackflshTotal = efSCM.PdBackflushFormulaData.FirstOrDefault(x => x.Wcno == wcno && x.Pddate.Date == ymd.Date && x.Shift == shift && x.Drawing == partno && x.Cm == cm);
                    if (oBackflshTotal != null)
                    {
                        oBackflshTotal.Qty = oHelper.ConvDec2Int(TotalTransaction);
                        efSCM.PdBackflushFormulaData.Update(oBackflshTotal);
                        int UpdateBackflushTotal = efSCM.SaveChanges();
                    }
                    else
                    {

                        PdBackflushFormulaDatum newBackflushTotal = new PdBackflushFormulaDatum();
                        newBackflushTotal.Pddate = ymd;
                        newBackflushTotal.Shift = shift;
                        newBackflushTotal.Wcno = wcno;
                        newBackflushTotal.Drawing = partno;
                        newBackflushTotal.Cm = cm;
                        newBackflushTotal.UpdateDate = DateTime.Now;
                        newBackflushTotal.Ftype = "N";
                        newBackflushTotal.Fno = "";
                        newBackflushTotal.Qty = oHelper.ConvDec2Int(TotalTransaction);
                        newBackflushTotal.UpdateBy = "AUTO IOT";
                        newBackflushTotal.Alpha = "";
                        newBackflushTotal.Remark = "";
                        efSCM.PdBackflushFormulaData.Add(newBackflushTotal);
                        int InsertBackflushTotal = efSCM.SaveChanges();
                    }
                }
                else
                {
                    action = false;
                    message = "APS-UPDATE-RESULT-003(INSERT)";
                }
            }

            return Ok(new
            {
                status = action,
                message = message
            });
        }

        [HttpPost]
        [Route("/ApsWipAdjust")]
        public IActionResult ApsWIPAdject([FromBody] ParamsWIpAdjustInfo param)
        {
            string message = "";
            int res = -1;
            string remark = param.remark!;
            string shift = DateTime.Now.AddHours(-8).Hour >= 12 ? "N" : "D";
            decimal _tranAdj = 0;
            decimal? WipBefore = param.wipBefore;
            DateTime dtNow = DateTime.Now.AddHours(-8);
            EkbWipPartStock oWipPartStk = efSCM.EkbWipPartStocks.FirstOrDefault((d) => d.Ym == dtNow.ToString("yyyyMM") && d.Wcno == param.wcno
                                                        && d.Partno == param.partno && d.Cm == param.cm)!;
            if (oWipPartStk != null)
            {
                _tranAdj = oHelper.ConvStr2Dec(oWipPartStk.Bal.ToString()) - param.adj_qty;

                //============= WIP Stock Adjust ==============
                oWipPartStk.Issqty = oWipPartStk.Issqty + _tranAdj;
                oWipPartStk.Bal = oWipPartStk.Bal - _tranAdj;
                oWipPartStk.UpdateBy = param.adj_by;
                oWipPartStk.UpdateDate = DateTime.Now;
                efSCM.EkbWipPartStocks.Update(oWipPartStk);
                res = efSCM.SaveChanges();
                if (res > 0)
                {
                    //============= Trans WIP Stock Adjust ==============
                    RunNumberService svrRunning = new RunNumberService();
                    string nbr = svrRunning.LoadUnique("EKB-ADJ").ToString(true);
                    svrRunning.NextId("EKB-ADJ");
                    EkbWipPartStockTransaction mTransaction = new EkbWipPartStockTransaction();
                    mTransaction.Nbr = nbr;
                    mTransaction.Ym = dtNow.ToString("yyyyMM");
                    mTransaction.Ymd = dtNow.ToString("yyyyMMdd");
                    mTransaction.Wcno = param.wcno;
                    mTransaction.Shift = (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20) ? "D" : "N";
                    mTransaction.Partno = param.partno;
                    mTransaction.Cm = param.cm;
                    mTransaction.TransQty = _tranAdj;
                    mTransaction.TransType = "OUT";
                    mTransaction.QrcodeData = "ADJUST";
                    mTransaction.CreateBy = param.adj_by;
                    mTransaction.CreateDate = DateTime.Now;
                    mTransaction.RefNo = "ADJUST";
                    efSCM.EkbWipPartStockTransactions.Add(mTransaction);
                    res = efSCM.SaveChanges();

                    SqlCommand sqlInsertRark = new SqlCommand();
                    sqlInsertRark.CommandText = $@"INSERT INTO [dbo].[DICT_SYSTEM_LOGS]
                                               ([DICT_SYSTEM],[DICT_TYPE],[CODE],[REF_CODE],[DESCRIPTION],[REF1],[REF2],[REF3],[REF4],[REF5],[NOTE],[CREATE_DATE],[UPDATE_BY],[UPDATE_DATE],[DICT_STATUS])
                                         VALUES
                                               ('APS_WIP_STOCK','FAC2_SCR','{dtNow.ToString("yyyyMM")}','{dtNow.ToString("yyyyMMdd")}','{shift}','{param.wcno}','{param.partno}','{param.cm}','{WipBefore}','{param.adj_qty}','{remark}',GETDATE(),'{param.adj_by}' ,GETDATE(),'ACTIVE')";
                    int insertRemark = dbSCM.ExecuteNonCommand(sqlInsertRark);
                }
            }
            else
            {
                message = "ไม่พบข้อมูลของ Stock รบกวนกรอกข้อมูล Backflush ";
            }
            return Ok(new { status = (res > 0), message = message });
        }


        [HttpPost]
        [Route("/ApsGetNotify")]
        public IActionResult ApsGetNotify([FromBody] ParamGetNotify param)
        {
            string wcno = param.wcno;
            string date = param.date;
            List<ApsProductionPlanNotify> rNotify = new List<ApsProductionPlanNotify>();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT WCNO,LINE_TYPE,CONVERT(varchar,CAST(CHANGE_DT AS DATE),112) AS CHANGE_DATE,SUB_LINE,NOTIFY_DT,NOTIFY_BY,ACK_STATUS,ACK_BY,ACK_DT FROM [dbSCM].[dbo].[APS_ProductionPlan_Notify]
  WHERE  ACK_STATUS = 'NOTIFY'  AND CONVERT(varchar,CAST(CHANGE_DT AS DATE),112) = '{date}' ";
            //AND WCNO = '{wcno}'
            DataTable dt = dbSCM.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                ApsProductionPlanNotify oNotify = new ApsProductionPlanNotify();
                oNotify.Wcno = dr["WCNO"].ToString();
                oNotify.LineType = dr["LINE_TYPE"].ToString();
                oNotify.ChangeDt = DateTime.ParseExact(dr["CHANGE_DATE"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                oNotify.SubLine = dr["SUB_LINE"].ToString();
                oNotify.NotifyDt = DateTime.Parse(dr["NOTIFY_DT"].ToString());
                oNotify.NotifyBy = dr["NOTIFY_BY"].ToString();
                oNotify.AckStatus = dr["ACK_STATUS"].ToString();
                oNotify.AckBy = dr["ACK_BY"].ToString();
                //oNotify.AckDt = dr["ACK_DT"] != null ? DateTime.Parse(dr["ACK_DT"].ToString()) : null;
                oNotify.SubLine = dr["SUB_LINE"].ToString();
                rNotify.Add(oNotify);
            }
            //List<ApsProductionPlanNotify> rNotify = efSCM.ApsProductionPlanNotifies.Where(x => x.Wcno == wcno && (x.NotifyDt.HasValue ? ) && x.AckStatus == "NOTIFY" && x.LineType == "MAIN").ToList();
            return Ok(rNotify);
        }

        [HttpGet]
        [Route("/ApsLoginByEmpcode/{empcode}")]
        public IActionResult ApsNotifyLogin(string empcode)
        {
            EmpProps empProp = new EmpProps();
            //Employee employee = efHRM.Employee.FirstOrDefault(x => x.Code == empcode);
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT * FROM [dbHRM].[dbo].[Employee] WHERE CODE = @CODE";
            sql.Parameters.Add(new SqlParameter("@CODE", empcode));
            DataTable dtEmp = dbHRM.Query(sql);
            if (dtEmp.Rows.Count > 0)
            {
                empProp.code = dtEmp.Rows[0]["CODE"].ToString();
                empProp.name = dtEmp.Rows[0]["NAME"].ToString();
                empProp.surn = dtEmp.Rows[0]["SURN"].ToString();
                empProp.img = $"http://dcidmc.dci.daikin.co.jp/PICTURE/{dtEmp.Rows[0]["CODE"].ToString()}.JPG";
                empProp.fullName = $"{empProp.name}.{empProp.surn.Substring(0, 1)}";
            }
            return Ok(empProp);
        }

        [HttpPost]
        [Route("/aps/GetPlanMachine")]
        public IActionResult ApsGetPlanMachine([FromBody] ParamGetPlanMachine param)
        {
            string ymd = param.ymd;
            string ym = DateTime.ParseExact(ymd, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyyMM");
            string partGroup = null;
            try
            {
                partGroup = param.partGroup;
            }
            catch { partGroup = null; }

            string condPartGroup = partGroup != null && partGroup.Length > 0 ? $" AND DICT.PART_GROUP = '{partGroup}'" : "";
            DateTime ApsYmd = DateTime.ParseExact(ymd, "yyyyMMdd", CultureInfo.InvariantCulture);
            List<PdBackflushFormulaDatum> rResult = efSCM.PdBackflushFormulaData.Where(x => x.Pddate.Date == ApsYmd.Date).ToList();
            List<PropsStockMachine> rStockMachine = new List<PropsStockMachine>();
            SqlCommand sqlGetStockMachine = new SqlCommand();
            sqlGetStockMachine.CommandText = @"
  SELECT A.WCNO,A.PARTNO,A.BAL,A.CM FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK] A
	LEFT JOIN ( SELECT [PWCNO],[APARTNO] AS PPARTNO, ACM PCM 
    FROM [dbSCM].[dbo].[AL_PD_Formula]    
  WHERE [STRYMN] <= @YMD AND [ENDYMN] >= @YMD  and PWCNO != '904' AND SUBSTRING(APARTNO,1,1) != 'J' 
  AND SUBSTRING(APARTNO,1,2) NOT IN('1Y','2Y')
UNION ALL
    SELECT [PWCNO],[PPARTNO], PCM 
    FROM [dbSCM].[dbo].[AL_PD_Formula_Multi]
  WHERE [STRYMD] <= @YMD AND [ENDYMD] >= @YMD and PWCNO != '904' AND SUBSTRING(PPARTNO,1,1) != 'J'
  AND  SUBSTRING(PPARTNO,1,2) NOT IN('1Y','2Y')) B
  ON B.PPARTNO = A.WCNO
  where A.YM = @YM  AND A.Ptype IS NULL AND A.WCNO != '904' AND A.WCNO LIKE '2%'";
            sqlGetStockMachine.Parameters.Add(new SqlParameter("@YM", ym));
            sqlGetStockMachine.Parameters.Add(new SqlParameter("@YMD", ymd));
            DataTable dtStockMachine = dbSCM.Query(sqlGetStockMachine);
            foreach (DataRow drStockMachine in dtStockMachine.Rows)
            {
                PropsStockMachine mStock = new PropsStockMachine();
                mStock.wcno = drStockMachine["WCNO"].ToString();
                mStock.partNo = drStockMachine["PARTNO"].ToString();
                mStock.cm = drStockMachine["CM"].ToString();
                mStock.bal = oHelper.ConvStr2Dec(drStockMachine["BAL"].ToString());
                rStockMachine.Add(mStock);
            }

            List<PropsApsPlanMachine> rPlanMachine = new List<PropsApsPlanMachine>();
            SqlCommand sqlGetPlanMachine = new SqlCommand();
            sqlGetPlanMachine.CommandText = $@"  SELECT  A.PRD_PlanCode ,A.[WCNO],A.SUBLINE  ,A.[APS_SEQ]  ,A.[APS_PlanDate]  ,A.[PRD_SEQ] ,A.[PartNo] ,A.[CM] ,A.[APS_PlanQty] ,A.[PRD_PlanQty]  ,C.BAL AS STOCK_MAIN,DICT.PART_GROUP
  FROM [dbSCM].[dbo].[APS_ProductionPlan] A
  LEFT JOIN (  SELECT [PWCNO],[PPARTNO], PCM, ISNULL(BAL,0) AS BAL FROM (
    SELECT [PWCNO],[APARTNO] AS PPARTNO, ACM PCM
    FROM [dbSCM].[dbo].[AL_PD_Formula]    
  WHERE [STRYMN] <= '{ymd}' AND [ENDYMN] >= '{ymd}' and PWCNO != '900' AND SUBSTRING(APARTNO,1,1) != 'J' 
  AND SUBSTRING(APARTNO,1,2) NOT IN('1Y','2Y')
UNION ALL
    SELECT [PWCNO],[PPARTNO], PCM
    FROM [dbSCM].[dbo].[AL_PD_Formula_Multi]
  WHERE [STRYMD] <= '{ymd}' AND [ENDYMD] >= '{ymd}'  and PWCNO != '900' AND SUBSTRING(PPARTNO,1,1) != 'J'
  AND  SUBSTRING(PPARTNO,1,2) NOT IN('1Y','2Y')
) AS t1
LEFT JOIN [dbSCM].[dbo].[EKB_WIP_PART_STOCK] ST
ON ST.PARTNO = t1.PPARTNO AND ST.CM = t1.PCM AND YM = '{ym}' AND ST.WCNO = '904'
WHERE [PWCNO] IN (SELECT  WCNO FROM [dbSCM].[dbo].[AL_WC_Master] WHERE GrpCode IN ('2200','2300') AND Product = 'SCR' AND WCNO NOT IN ('907') )
  AND PPARTNO NOT LIKE 'J%' 
GROUP BY [PWCNO],[PPARTNO], PCM,ST.BAL ) C
  ON C.PPARTNO = A.PartNo
  LEFT JOIN (SELECT  [REF1] AS WCNO ,[REF2] AS PARTNO   ,[NOTE] AS PART_GROUP FROM [dbSCM].[dbo].[DictMstr]
  where DICT_SYSTEM  = 'WIP_STOCK'  and DICT_TYPE like 'PART_SET_%' AND DICT_STATUS = 'ACTIVE'
  GROUP BY [REF1] ,[REF2]  ,[NOTE]) DICT
  ON DICT.PARTNO = A.PartNo  
  where A.WCNO != '904' and lrev = '999'
and APS_PlanDate  = '{ApsYmd.ToString("yyyy-MM-dd")}' {condPartGroup}
  order by APS_PlanDate asc,CAST(PRD_SEQ AS INT) asc
";
            //sqlGetPlanMachine.Parameters.Add(new SqlParameter("@YMD", ymd));
            //sqlGetPlanMachine.Parameters.Add(new SqlParameter("@YM", ym));
            //sqlGetPlanMachine.Parameters.Add(new SqlParameter("@APS_YMD", ApsYmd.ToString("yyyy-MM-dd")));
            DataTable dtPlanMachine = dbSCM.Query(sqlGetPlanMachine);
            foreach (DataRow drPlan in dtPlanMachine.Rows)
            {
                PropsApsPlanMachine oPlanMachine = new PropsApsPlanMachine();
                oPlanMachine.prdPlanCode = drPlan["PRD_PlanCode"].ToString();
                oPlanMachine.wcno = drPlan["WCNO"].ToString();
                oPlanMachine.apsSeq = oHelper.ConvStr2Int(drPlan["APS_SEQ"].ToString());
                oPlanMachine.apsPlanDate = drPlan["APS_PlanDate"].ToString();
                oPlanMachine.prdSeq = oHelper.ConvStr2Int(drPlan["PRD_SEQ"].ToString());
                oPlanMachine.partNo = drPlan["PartNo"].ToString();
                oPlanMachine.cm = drPlan["CM"].ToString();
                oPlanMachine.apsPlanQty = oHelper.ConvStr2Int(drPlan["APS_PlanQty"].ToString());
                oPlanMachine.prdPlanQty = oHelper.ConvStr2Int(drPlan["PRD_PlanQty"].ToString());
                oPlanMachine.partGroup = drPlan["PART_GROUP"].ToString();
                oPlanMachine.stockMain = oHelper.ConvStr2Dec(drPlan["STOCK_MAIN"].ToString());
                oPlanMachine.subLine = drPlan["SUBLINE"].ToString();
                decimal valResult = 0;
                List<PdBackflushFormulaDatum> oResult = rResult.Where(x => x.Drawing == oPlanMachine.partNo).ToList();
                //&& x.Cm == oPlanMachine.cm
                if (oResult.Count > 0)
                {
                    int TotalResult = Convert.ToInt32(oResult.Sum(x => x.Qty));
                    valResult = TotalResult;
                }

                oPlanMachine.result = valResult;
                PropsStockMachine oStockMachine = rStockMachine.FirstOrDefault(x => x.partNo == oPlanMachine.partNo);
                if (oStockMachine != null)
                {
                    oPlanMachine.stockMachine = oStockMachine.bal;
                }
                rPlanMachine.Add(oPlanMachine);

            }

            return Ok(rPlanMachine);
        }

        [HttpPost]
        [Route("/Aps/UpdateSequencePlan")]
        public IActionResult ApsUpdateSequencePlan([FromBody] ParamUpdateSequencePlan param)
        {
            string empcode = param.empcode;
            string partGroup = param.partGroup;
            List<PropsApsPlanMachine> rPlan = param.plan;
            foreach (PropsApsPlanMachine oPlan in rPlan)
            {
                ApsProductionPlan mPlan = efSCM.ApsProductionPlans.FirstOrDefault(x => x.PrdPlanCode == oPlan.prdPlanCode);
                if (mPlan != null)
                {
                    mPlan.PrdPlanQty = oPlan.prdPlanQty;
                    mPlan.PrdSeq = oPlan.prdSeq.ToString();
                    mPlan.UpdBy = empcode;
                    mPlan.UpdDt = DateTime.Now;
                    efSCM.ApsProductionPlans.Update(mPlan);
                    int update = efSCM.SaveChanges();
                    if (update == 1)
                    {
                        if (partGroup != "")
                        {
                            ApsProductionPlanNotify oNotify = efSCM.ApsProductionPlanNotifies.FirstOrDefault(x => x.SubLine == partGroup && x.Wcno == "904" && x.LineType == "MAIN" && x.AckStatus == "NOTIFY");
                            if (oNotify != null)
                            {
                                oNotify.AckStatus = "ACTION";
                                oNotify.AckBy = empcode;
                                oNotify.AckDt = DateTime.Now;
                                efSCM.ApsProductionPlanNotifies.Update(oNotify);
                            }
                        }
                        if (oPlan.reason != null && oPlan.reason != "")
                        {
                            ApsProductionPlanNotice newNotice = new ApsProductionPlanNotice();
                            Random rnd = new Random();
                            newNotice.NtNbr = $"{rnd.Next(0, 9999)}-{oPlan.prdPlanCode}";
                            newNotice.PrdPlanCode = oPlan.prdPlanCode;
                            newNotice.NtType = "NOTICE";
                            newNotice.NtNotice = oPlan.remark;
                            newNotice.CreBy = empcode;
                            newNotice.CreDt = DateTime.Now;
                            newNotice.NtCode = oPlan.reason;
                            efSCM.ApsProductionPlanNotices.Add(newNotice);
                        }
                    }
                }
            }
            int action = efSCM.SaveChanges();
            return Ok(new
            {
                status = true
            });
        }

        [HttpGet]
        [Route("/Aps/GetPartMaster")]
        public IActionResult ApsGetPartMaster()
        {
            List<PartGroupMaster> rPartGroup = new List<PartGroupMaster>();
            SqlCommand sql = new SqlCommand();
            List<DictMstr> rModelStandard = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "MODEL_STANDARD").ToList();
            sql.CommandText = $@"SELECT A.[DESCRIPTION] AS WCNO,A.REF2 AS PARTNO,A.REF3 AS CM ,A.REF4 AS MODEL_COMMON,A.NOTE AS PART_GROUP ,B.DESCRIPTION AS PART_GROUP_NAME
FROM [dbSCM].[dbo].[DictMstr]  A
LEFT JOIN [dbSCM].[dbo].[DictMstr] B
ON B.CODE = A.NOTE 
WHERE  A.DICT_type = 'WC_MASTER' AND A.NOTE != ''  AND A.REF4 != ''  
and B.DICT_SYSTEM = 'WIP_STOCK' AND B.DICT_TYPE = 'PART_GROUP_MASTER' AND B.DICT_STATUS = 'ACTIVE'
ORDER BY PART_GROUP ASC";
            DataTable dtPartGroup = dbSCM.Query(sql);
            foreach (DataRow dr in dtPartGroup.Rows)
            {
                PartGroupMaster oPartGroup = new PartGroupMaster();
                oPartGroup.wcno = dr["WCNO"].ToString();
                oPartGroup.model_common = dr["MODEL_COMMON"].ToString();
                oPartGroup.partno = dr["PARTNO"].ToString();
                oPartGroup.cm = dr["CM"].ToString();
                oPartGroup.part_group = dr["PART_GROUP"].ToString();
                oPartGroup.part_group_name = dr["PART_GROUP_NAME"].ToString();
                List<DictMstr> oModelStandard = rModelStandard.Where(x => x.Code == oPartGroup.model_common && x.Note == oPartGroup.partno).ToList();
                if (oModelStandard.Count > 0)
                {
                    oPartGroup.stdMC = oModelStandard.FirstOrDefault(x => x.RefCode == "MC") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "MC").Ref1) : 0;
                    oPartGroup.stdCTMC = oModelStandard.FirstOrDefault(x => x.RefCode == "CT/MC") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CT/MC").Ref1) : 0;
                    oPartGroup.stdCT = oModelStandard.FirstOrDefault(x => x.RefCode == "CT") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CT").Ref1) : 0;
                    oPartGroup.stdCapHR = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "HR") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "HR").Ref1) : 0;
                    oPartGroup.stdCapShift = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "SHIFT") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "SHIFT").Ref1) : 0;
                    oPartGroup.stdCapDay = oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "DAY") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "CAPACITY" && x.Description == "DAY").Ref1) : 0;
                    oPartGroup.stdNeedDay = oModelStandard.FirstOrDefault(x => x.RefCode == "NEEDDAY") != null ? Convert.ToInt16(oModelStandard.FirstOrDefault(x => x.RefCode == "NEEDDAY").Ref1) : 0;
                }
                rPartGroup.Add(oPartGroup);
            }
            return Ok(rPartGroup);
        }
        [HttpPost]
        [Route("/Aps/InsertPlan")]
        public IActionResult ApsInsertPlan([FromBody] PropsApsInsertPlan param)
        {
            try
            {
                bool status = false;
                string message = "";
                string type = param.type;
                Random rnd = new Random();
                string date = param.date;
                string wcno = param.wcno;
                string model = param.model;
                decimal qty = param.qty;
                string empcode = param.empcode;
                string subLine = type == "MAIN" ? "ASSEMBLY LINE4 (SCR)" : "";
                string partGroup = param.partGroup;
                DateTime ymd = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                string nbr = $"APS{ymd.ToString("yyyyMMdd")}-{rnd.Next(0, 10000).ToString("D5")}-{rnd.Next(0, 10000).ToString("D5")}";
                int sequence = 1;
                try
                {
                    if (type == "MAIN")
                    {
                        List<ApsProductionPlan> rProdPlan = efSCM.ApsProductionPlans.Where(x => x.Wcno == wcno && x.ApsPlanDate == ymd.Date && x.Subline == subLine && x.Lrev == "999").OrderBy(x => x.PrdSeq).ToList();
                        ApsProductionPlan oProdPlan = new ApsProductionPlan();
                        if (rProdPlan.Count > 0)
                        {
                            oProdPlan = rProdPlan.LastOrDefault()!;
                            if (oProdPlan != null)
                            {
                                sequence = oHelper.ConvStr2Int(oProdPlan.PrdSeq!) + 1;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            sequence = param.seq != null ? (int)param.seq : 1;
                        }
                        catch
                        {
                            sequence = 1;
                        }
                    }
                }
                catch
                {
                    sequence = 0;
                }
                ApsProductionPlan newPlan = new ApsProductionPlan();
                newPlan.PrdPlanCode = nbr;
                newPlan.Wcno = wcno;
                newPlan.Subline = subLine;
                newPlan.ApsSeq = "0";
                newPlan.ApsPlanDate = ymd;
                newPlan.ApsDistribute = ymd.ToString("yyyyMMdd");
                newPlan.PrdSeq = sequence.ToString();
                newPlan.PartNo = model;
                newPlan.Cm = "";
                newPlan.PrdPlanQty = oHelper.ConvDec2Int(qty);
                newPlan.Rev = "0";
                newPlan.Lrev = "999";
                newPlan.CreBy = empcode;
                newPlan.CreDt = DateTime.Now;
                newPlan.UpdBy = empcode;
                newPlan.UpdDt = DateTime.Now;
                efSCM.ApsProductionPlans.Add(newPlan);
                int insertPlan = efSCM.SaveChanges();
                if (insertPlan > 0)
                {
                    status = true;
                    if (partGroup != "")
                    {
                        ApsProductionPlanNotify newNotify = new ApsProductionPlanNotify();
                        newNotify.Wcno = wcno;
                        newNotify.LineType = "SUBLINE";
                        newNotify.ChangeDt = DateTime.Now;
                        newNotify.SubLine = partGroup;
                        newNotify.NotifyDt = DateTime.Now;
                        newNotify.NotifyBy = empcode;
                        newNotify.AckStatus = "NOTIFY";
                        efSCM.ApsProductionPlanNotifies.Add(newNotify);
                        int insertNotify = efSCM.SaveChanges();
                    }
                }
                return Ok(new
                {
                    status,
                    message
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    status = false,
                    message = e.Message
                });

            }
        }

        [HttpPost]
        [Route("/aps/mp_title")]
        public IActionResult GetAPSMPTitle(paramLineInfo param)
        {
            var content = oSrvMP.getManpowerTitle(param.lineNo);

            return Ok(content);
        }

        [HttpPost]
        [Route("/aps/mp")]
        public IActionResult GetAPSMP()
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            var content = oSrvMP.getManpower(dtNow, (dtNow.Hour < 12) ? "D" : "N");

            return Ok(content);
        }

        [HttpPost]
        [Route("/aps/emp_ot")]
        public IActionResult GetEmployeeWithOTList()
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            var content = oSrvMP.getEmployeeWithOT(dtNow);

            return Ok(content);
        }

        [HttpPost]
        [Route("/aps/mp_history")]
        public IActionResult GetAPSMPHistory(paramDateShiftInfo paramData)
        {
            var content = oSrvMP.getManpower(paramData.paramDate, paramData.paramShift);

            return Ok(content);
        }


        [HttpPost]
        [Route("/aps/authenALPHA")]
        public IActionResult AuthenALPHA(paramAuthenInfo paramData)
        {
            var content = oSrvMP.authenALPHA(paramData.userName, paramData.passWord);

            return Ok(content);
        }


        [HttpPost]
        [Route("/aps/plan")]
        public IActionResult GetAPSPlan([FromBody] paramDateWCNOInfo paramData)
        {
            try
            {
                string paramDate = paramData.paramDate;
                int SeqCurrent = 0;
                int CntGastight = 0;
                List<ApsSublineStockBalance> oResults = new List<ApsSublineStockBalance>();
                PropShrinkGage oShrinkGage = new PropShrinkGage();
                DateTime PeriodHour = DateTime.Now;
                DateTime dtNow = DateTime.Now;
                List<FGPlanInfo> MainPlanRelocate = new List<FGPlanInfo>();
                //string shift = PeriodHour.Hour >= 20 ? "N" : "D";
                int year = Convert.ToInt16(paramDate.Substring(0, 4));
                int mm = Convert.ToInt16(paramDate.Substring(4, 2));
                int dd = Convert.ToInt16(paramDate.Substring(6, 2));
                DateTime DTCurrent = new DateTime(year, mm, dd);
                DateTime DTOfShiftStart = new DateTime(year, mm, dd, 8, 0, 0);
                List<PropLineAndProcess> ListLineAndProcess = new List<PropLineAndProcess>();
                List<ApsSublineStockBalance> res = new List<ApsSublineStockBalance>();
                List<ApsSublineStockBalance> oResMainPeriod = efSCM.ApsSublineStockBalances.FromSqlRaw($"SELECT  *  FROM [dbSCM].[dbo].[APS_SUBLINE_STOCK_BALANCE] WHERE YM = '{DTCurrent.ToString("yyyyMM")}' AND YMD = '{DTCurrent.ToString("yyyyMMdd")}' AND APS_Result > 1   ORDER BY YMD asc, CreateDate asc ,CAST(Aps_seq as int) asc").ToList();
                List<FGPlanInfo> MainPlans = oSrvMP.getMainPlan(paramData.paramDate, paramData.paramWCNO, oResMainPeriod);
                List<string> ModelsInMainPlan = MainPlans.Where(x => x.APSPlanDate.ToString("yyyyMMdd") == DTCurrent.ToString("yyyyMMdd")).GroupBy(x => x.ModelCode).Select(o => o.Key).ToList();
                List<ScrGasTight> GasTights = efCostyIoT.ScrGasTights.Where(x => x.InsertDate.Value.AddHours(-8).Date == DTCurrent.Date).OrderByDescending(x => x.InsertDate).ToList();
                try
                {
                    var GastightCounter = GasTights.GroupBy(x => x.ModelCode).Select(n => new { modelCode = n.Key, cnt = n.Count() }).ToList();
                    GasTights = GasTights.Where(x => GastightCounter.Where(o => o.cnt > 1).Select(n => n.modelCode).Contains(x.ModelCode)).ToList();
                }
                catch (Exception e)
                {
                    GasTights = efCostyIoT.ScrGasTights.Where(x => x.InsertDate.Value.AddHours(-8).Date == DTCurrent.Date && ModelsInMainPlan.Contains(x.ModelCode)).OrderByDescending(x => x.InsertDate).ToList();
                }
                SqlCommand sqlGetLineProcess = new SqlCommand();
                sqlGetLineProcess.CommandText = $@"SELECT  A.[REF4] LINE, A.[REF_CODE] PROCESS,B.REF_CODE FROM [dbSCM].[dbo].[DictMstr]  A
LEFT JOIN (SELECT DESCRIPTION,REF_CODE  FROM [dbSCM].[dbo].[DictMstr]  WHERE DICT_TYPE = 'LINE_TITLE') B
ON B.DESCRIPTION = A.REF_CODE
WHERE A.DICT_SYSTEM = 'WIP_STOCK'  AND A.DICT_TYPE = 'SUB_LINE_SORT' AND  A.REF_CODE != 'OS'  
ORDER BY CAST(A.NOTE AS INT) ASC";
                DataTable dt = dbSCM.Query(sqlGetLineProcess);
                foreach (DataRow dr in dt.Rows)
                {
                    PropLineAndProcess item = new PropLineAndProcess();
                    item.line = dr["LINE"].ToString();
                    item.process = dr["PROCESS"].ToString();
                    ListLineAndProcess.Add(item);
                }

                // ======= GET LIST GASTIGHT ONLY MODEL IN MAIN PLAN ===== //
                List<ParamStringInt> ResultOfModels = oResMainPeriod.GroupBy(x => x.Modelcode).Select(x => new ParamStringInt()
                {
                    modelCode = x.Key,
                    result = oHelper.ConvUnDec2Int(x.Sum(o => o.ApsResult))
                }).ToList();
                List<FGPlanInfo> MainPlanOfDay = new List<FGPlanInfo>();
                foreach (FGPlanInfo newPlan in MainPlans.Where(x => x.APSPlanDate.ToString("yyyyMMdd") == DTCurrent.ToString("yyyyMMdd")).ToList())
                {
                    MainPlanOfDay.Add(new FGPlanInfo
                    {
                        PrdPlanCode = newPlan.PrdPlanCode,
                        APSSeq = newPlan.APSSeq,
                        PrdSeq = newPlan.PrdSeq,
                        ModelCode = newPlan.ModelCode,
                        PartNo = newPlan.PartNo,
                        PrdPlanQty = newPlan.PrdPlanQty,
                        ApsCurrent = "",
                        dataWIP = new FGWIPInfo()
                        {
                            StatorMain = newPlan.dataWIP.StatorMain
                        }
                    });
                }
                foreach (FGPlanInfo oPlan in MainPlanOfDay)
                {
                    int indexResult = ResultOfModels.Where(x => x.result > 0).ToList().FindIndex(x => x.modelCode == oPlan.ModelCode && x.result > 0);
                    if (indexResult != -1)
                    {
                        int oResult = oHelper.ConvUnDec2Int(ResultOfModels[indexResult].result);
                        if (oResult >= oPlan.PrdPlanQty)
                        {
                            oPlan.PrdPlanQty = 0;
                            ResultOfModels[indexResult].result = oPlan.PrdPlanQty;
                        }
                        else
                        {
                            oPlan.PrdPlanQty -= oResult;
                            ResultOfModels[indexResult].result -= oResult;
                        }
                    }
                }


                // ============= [S] เรียกข้อมูล Wip ปัจจุบัน จาก model ในเฉพาะ Plan ============ //
                List<string> Model3Day = MainPlans.GroupBy(x => x.ModelCode).Select(o => o.Key).ToList();
                //List<ViApsPartStockScr> WipCurrent = efSCM.ViApsPartStockScrs.Where(x => x.Ym == DTCurrent.ToString("yyyyMM") && Model3Day.Contains(x.ModelCode != null ? x.ModelCode : "")).ToList();
                List<PropWIP> WIPSublines = oServ.GetWIPSublines();
                List<PropWIP> WIPMains = oServ.GetWIPMains();

                // ============= [S] คำนวนหาชั่วโมงปัจจุบัน ช่วงละ 2 ชม ========//
                int Hour = PeriodHour.Hour;
                int Mod = Hour % 2;
                if (Mod != 0)
                {
                    PeriodHour = PeriodHour.AddHours(1);
                }
                string modelCodeCurrent = "";
                // ======== เรียกรายการล่าสุดของ Gastight ========= //
                ScrGasTight oLastGasTight = GasTights.FirstOrDefault();
                if (oLastGasTight != null)
                {
                    modelCodeCurrent = oLastGasTight.ModelCode;
                    if (MainPlans.Where(x => x.APSPlanDate.ToString("yyyyMMdd") == DTCurrent.ToString("yyyyMMdd") && x.ModelCode == modelCodeCurrent).ToList().Count == 0)
                    {
                        modelCodeCurrent = null;
                    }
                }

                string JoinModelInPlan = string.Join(", ", ModelsInMainPlan.Select(item => $"'{item}'"));
                string CondModelInPlan = $" AND A.Model IN ({JoinModelInPlan})";
                SqlCommand sqlShinkGate = new SqlCommand();
                sqlShinkGate.CommandText = $@"SELECT TOP(1) B.MODEL,B.SEBANGO,A.Insert_date AS INSERT_DATE  FROM [dbIoT].[dbo].[SCR_Body_Shink_Fitting] A LEFT JOIN (SELECT MODEL,SEBANGO  FROM [192.168.226.86].[dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE MODELGROUP = 'SCR' GROUP BY MODEL,SEBANGO) B ON B.SEBANGO = A.Model WHERE A.Model != 'ERRO'  AND A.Insert_date >= '{DTOfShiftStart.ToString("yyyy-MM-dd HH:mm")}' ORDER BY Insert_date desc ";
                DataTable dtShinkGate = dbIOT.Query(sqlShinkGate);
                if (dtShinkGate.Rows.Count > 0)
                {
                    if (modelCodeCurrent == null)
                    {
                        modelCodeCurrent = dtShinkGate.Rows[0]["SEBANGO"].ToString();
                    }
                    oShrinkGage = new PropShrinkGage()
                    {
                        model = dtShinkGate.Rows[0]["MODEL"].ToString(),
                        sebango = dtShinkGate.Rows[0]["SEBANGO"].ToString(),
                        insertDate = dtShinkGate.Rows[0]["INSERT_DATE"].ToString()
                    };
                }
                //if (oLastGasTight != null)
                //{
                DateTime DateTimeCurrent = DateTime.Now;
                int HourCurrent = DateTime.Now.Hour;
                int ModCurrent = Hour % 2;
                if (ModCurrent != 0)
                {
                    DateTimeCurrent = DateTimeCurrent.AddHours(-1);
                }
                DateTime CurrentHourCycle = new DateTime(year, mm, dd, DateTimeCurrent.Hour, 0, 0);
                if (modelCodeCurrent != "") // ========= GAS มี Record ============ //
                {
                    CntGastight = GasTights.Where(x => x.InsertDate >= CurrentHourCycle && x.ModelCode == modelCodeCurrent).ToList().Count();
                }
                MainPlans.ForEach(x => x.ApsCurrent = "");
                foreach (string oModelCode in MainPlans.Where(x => x.APSPlanDate.Date == DTCurrent.Date).GroupBy(x => x.ModelCode).Select(x => x.Key))
                {
                    if (oModelCode == modelCodeCurrent)
                    {
                        int CntResultOfModel = GasTights.Where(x => x.ModelCode == modelCodeCurrent).Count();
                        //if (CntResultOfModel > 0)
                        //{
                        List<FGPlanInfo> ListPlanOfModel = MainPlans.OrderBy(x => x.PrdSeq).Where(x => x.APSPlanDate.Date == DTCurrent.Date && x.ModelCode == oModelCode).ToList();
                        if (ListPlanOfModel.Count > 0) // Gastight เดิมตามแผน
                        {
                            if (ListPlanOfModel.Count == 1) // มีแผนเดียว จะให้เป็น Current ทันที
                            {
                                ListPlanOfModel[0].ApsCurrent = "CURRENT";
                                ListPlanOfModel[0].StatusPlan = "process";
                                SeqCurrent = ListPlanOfModel[0].PrdSeq;
                            }
                            else // หา Current จากจำนวนการ [PLAN - RESULT]
                            {
                                int TempPlan = 0;
                                bool HaveCurrent = false;
                                foreach (FGPlanInfo objPlan in ListPlanOfModel)
                                {
                                    int PlanQty = objPlan.PrdPlanQty;
                                    TempPlan += PlanQty;
                                    if (CntResultOfModel > PlanQty) // RESULT > Plan จะไปต่อในรายการถัดไป
                                    {
                                        objPlan.ApsCurrent = "SUCCESS";
                                        objPlan.StatusPlan = "success";
                                    }
                                    else if (CntResultOfModel <= TempPlan)
                                    {
                                        if (HaveCurrent == false)
                                        {
                                            objPlan.ApsCurrent = "CURRENT";
                                            objPlan.StatusPlan = "process";
                                            SeqCurrent = objPlan.PrdSeq;
                                            HaveCurrent = true;
                                        }
                                    }
                                }
                            }
                        }
                        //}
                    }
                    else
                    {
                        int CntResultOfModel = GasTights.Where(x => x.ModelCode == oModelCode).Count();
                        if (CntResultOfModel > 0)
                        {
                            List<FGPlanInfo> ListPlanOfModel = MainPlans.OrderBy(x => x.PrdSeq).Where(x => x.APSPlanDate.Date == DTCurrent.Date && x.ModelCode == oModelCode).ToList();
                            if (ListPlanOfModel.Count > 0) // Gastight เดิมตามแผน
                            {
                                if (ListPlanOfModel.Count == 1) // มีแผนเดียว จะให้เป็น Current ทันที
                                {
                                    int Plan = ListPlanOfModel[0].PrdPlanQty;
                                    if (CntResultOfModel >= Plan)
                                    {
                                        ListPlanOfModel[0].ApsCurrent = "SUCCESS";
                                        ListPlanOfModel[0].StatusPlan = "success";
                                    }
                                    else if (CntResultOfModel < Plan)
                                    {
                                        ListPlanOfModel[0].ApsCurrent = "SOME";
                                        ListPlanOfModel[0].StatusPlan = "some";
                                    }
                                }
                                else // หา Current จากจำนวนการ [PLAN - RESULT]
                                {
                                    int TempPlan = 0;
                                    foreach (FGPlanInfo objPlan in ListPlanOfModel)
                                    {
                                        int PlanQty = objPlan.PrdPlanQty;
                                        TempPlan += PlanQty;
                                        if (CntResultOfModel >= PlanQty) // RESULT > Plan จะไปต่อในรายการถัดไป
                                        {
                                            objPlan.ApsCurrent = "SUCCESS";
                                            objPlan.StatusPlan = "success";
                                        }
                                        else if (CntResultOfModel < TempPlan)
                                        {
                                            objPlan.ApsCurrent = "SOME";
                                            objPlan.StatusPlan = "some";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                MainPlanOfDay.ForEach(x => x.ApsCurrent = "");
                foreach (FGPlanInfo item in MainPlanOfDay)
                {
                    if (item.PrdSeq == SeqCurrent)
                    {
                        item.ApsCurrent = "CURRENT";
                    }
                }

                foreach (FGPlanInfo item in MainPlans.Where(x => x.ApsCurrent != "CURRENT" && x.APSPlanDate.Date == DTOfShiftStart.Date).ToList())
                {
                    int CntResultOfModel = oHelper.ConvUnDec2Int(oResMainPeriod.Where(x => x.Modelcode == item.ModelCode).Sum(x => x.ApsResult));
                    int CntPlan = item.PrdPlanQty;
                    if (CntResultOfModel != 0 && CntResultOfModel < CntPlan)
                    {
                        item.StatusPlan = "some";
                    }
                    else if (CntResultOfModel == CntPlan)
                    {
                        item.StatusPlan = "success";
                    }
                    else
                    {
                        item.StatusPlan = "";
                    }
                }


                // ======= [S] นำเข้าข้อมูล Result History  ========= //
                foreach (ApsSublineStockBalance oResult in oResMainPeriod)
                {
                    int oHour = oHelper.ConvStr2Int(oResult.Hhmm.Substring(0, 2));
                    oResult.ApsRemainPlan = 0;
                    oResult.ApsCurrent = "HISTORY";
                    oResult.Hhmm = $"{(oHour == 0 ? (24 - 2) : (oHour - 2)).ToString("D2")}-{oHour.ToString("D2")}";
                    oResults.Add(oResult);
                }

                // ==============================================//
                // ======= สลับตำแหน่ง Current ไปตำแหน่งแรก  =========//
                // ==============================================//

                //foreach (FGPlanInfo item in MainPlanOfDay.Where(x => x.ApsCurrent == "CURRENT" && x.PrdPlanQty > 0).ToList())
                foreach (FGPlanInfo item in MainPlanOfDay.Where(x => x.ApsCurrent == "CURRENT").ToList())
                {
                    MainPlanRelocate.Add(item);
                }
                // ====== เอาเฉพาะที่ไม่ใช่ตัว Current และยังเหลือ Plan Qty ===== //
                foreach (FGPlanInfo item in MainPlanOfDay.Where(x => x.ApsCurrent != "CURRENT").ToList())
                {
                    MainPlanRelocate.Add(item);
                }
                // =============== SET APS CURRENT = NEXT ===============//
                FGPlanInfo PlanCurrent = null;
                foreach (FGPlanInfo item in MainPlanRelocate)
                {
                    if (item.ApsCurrent == "CURRENT")
                    {
                        PlanCurrent = item;
                    }
                    else
                    {
                        if (PlanCurrent != null)
                        {
                            int index = MainPlanRelocate.FindIndex(x => x.PrdPlanCode == PlanCurrent.PrdPlanCode);
                            if (index != -1)
                            {
                                int indexLoop = MainPlanRelocate.FindIndex(x => x.PrdPlanCode == item.PrdPlanCode);
                                if ((indexLoop - 1) == index)
                                {
                                    item.ApsCurrent = "NEXT";
                                }
                                else if ((indexLoop - 1) > index)
                                {
                                    item.ApsCurrent = "SOME";
                                }
                            }
                        }
                    }
                }


                int HourCur = dtNow.Hour;
                int ModLoop = HourCur % 2;
                if (ModLoop != 0)
                {
                    HourCur = HourCur - 1;
                }
                DateTime Tomorrow = dtNow.AddHours(-8).AddDays(1);
                DateTime DTStart = new DateTime(year, mm, dd, HourCur, 0, 0);
                DateTime DTEnd = new DateTime(Tomorrow.Year, Tomorrow.Month, Tomorrow.Day, 8, 0, 0);
                int HourLoop = DTStart.Hour;
                decimal Capacity = 120;

                MainPlanRelocate = MainPlanRelocate.Where(x => x.PrdPlanQty > 0 || x.ApsCurrent == "CURRENT").ToList();

                // =============================================================== //
                // =========== LOOP RESULT APS FOR REMOVE ON GASTIGHT  =========== //
                // =============================================================== //
                try
                {
                    foreach (FGPlanInfo itemPlan in MainPlans.Where(x => x.ApsCurrent == "SUCCESS" && x.APSPlanDate.Date == DTOfShiftStart.Date))
                    {
                        int countResultOfModel = oHelper.ConvUnDec2Int(itemPlan.PrdPlanQty);
                        if (countResultOfModel > 0)
                        {
                            List<ScrGasTight> GasRemoves = GasTights.Where(x => x.ModelCode == itemPlan.ModelCode).ToList();
                            if (GasRemoves.Count > 0)
                            {
                                GasRemoves = GasRemoves.Count >= countResultOfModel ? GasRemoves.Skip(0).Take(countResultOfModel).ToList() : GasRemoves.Skip(0).Take(GasRemoves.Count).ToList();
                                GasTights.RemoveAll(x => GasRemoves.Select(x => x.Id).Contains(x.Id));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // =============================================================== //
                // =============================================================== //

                while (DTStart < DTEnd)
                {
                    FGPlanInfo oPlan = MainPlanRelocate.FirstOrDefault();
                    if (oPlan != null)
                    {
                        bool isCurrent = oPlan.ApsCurrent == "CURRENT" ? true : false;
                        int IndexPlan = MainPlanRelocate.FindIndex(x => x.PrdPlanCode == oPlan.PrdPlanCode);
                        FGPlanInfo oMainPlan = MainPlans.FirstOrDefault(x => x.PrdPlanCode == oPlan.PrdPlanCode);
                        string MainStatus = oMainPlan != null ? oMainPlan.ApsCurrent : "";
                        if (MainStatus == "SUCCESS")
                        {
                            MainPlanRelocate.Remove(oPlan);
                            continue;
                        }
                        decimal CntPrdPlan = oPlan.PrdPlanQty;
                        decimal CntRemainPlan = Capacity - CntPrdPlan;
                        //int CntResultOfModel = oHelper.ConvUnDec2Int(Results.Where(x => x.Modelcode == oMainPlan.ModelCode && x.ApsSeq == oPlan.PrdSeq.ToString()).Sum(x => x.ApsResult));
                        int CntResultOfModel = GasTights.Where(x => x.ModelCode == oMainPlan.ModelCode).Count();
                        int RemainPlan = 0;
                        if (isCurrent == true)
                        {
                            CntResultOfModel = oHelper.ConvUnDec2Int(oResMainPeriod.Where(x => x.Modelcode == oMainPlan.ModelCode && x.ApsSeq == oPlan.PrdSeq.ToString()).Sum(x => x.ApsResult));
                            if ((oMainPlan.PrdPlanQty - (CntGastight + CntResultOfModel)) > 0)
                            {
                                RemainPlan = oMainPlan.PrdPlanQty - (CntGastight + CntResultOfModel);
                            }
                        }
                        else
                        {
                            RemainPlan = oMainPlan.PrdPlanQty - CntResultOfModel;
                            RemainPlan = RemainPlan < 0 ? 0 : RemainPlan;
                        }
                        if (CntRemainPlan > 0)
                        {
                            MainPlanRelocate.Remove(oPlan);
                            Capacity -= CntPrdPlan;
                            if (oPlan.PartNo != "")
                            {
                                //ViApsPartStockScr oWipOfModel = new ViApsPartStockScr();
                                //ViApsPartStockScr oWipOfModel = WipCurrent.FirstOrDefault(x => x.ModelCode == oMainPlan.ModelCode);
                                //if (oWipOfModel == null)
                                //{
                                //    oWipOfModel = new ViApsPartStockScr();
                                //}
                                List<PropWIP> oWIPOfModel = WIPSublines.Where(x => x.sebango == oMainPlan.ModelCode).ToList();
                                List<PropWIP> oWIPofMain = WIPMains.Where(x => x.sebango == oMainPlan.ModelCode).ToList();
                                oResults.Add(new ApsSublineStockBalance()
                                {
                                    ApsSeq = oPlan.PrdSeq.ToString(),
                                    Modelcode = oPlan.ModelCode,
                                    Modelname = oPlan.PartNo,
                                    ApsPlan = oPlan.APSPlanQty,
                                    ApsRemainPlan = RemainPlan,
                                    ApsResult = isCurrent ? CntGastight : CntResultOfModel,
                                    Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}",
                                    ApsCurrent = isCurrent == true ? "CURRENT" : oPlan.ApsCurrent,
                                    StatorMain = oHelper.GetItemWIP(oWIPofMain, "STATOR"),
                                    StatorSubline = oHelper.GetItemWIP(oWIPOfModel, "STATOR"),
                                    RotorMain = oHelper.GetItemWIP(oWIPofMain, "ROTOR"),
                                    RotorSubline = oHelper.GetItemWIP(oWIPOfModel, "ROTOR"),
                                    HsMain = oHelper.GetItemWIP(oWIPofMain, "HS"),
                                    HsSubline = oHelper.GetItemWIP(oWIPOfModel, "HS"),
                                    CsMain = oHelper.GetItemWIP(oWIPofMain, "CS"),
                                    CsSubline = oHelper.GetItemWIP(oWIPOfModel, "CS"),
                                    FsMain = oHelper.GetItemWIP(oWIPofMain, "FS"),
                                    FsSubline = oHelper.GetItemWIP(oWIPOfModel, "FS"),
                                    LwMain = oHelper.GetItemWIP(oWIPofMain, "LW"),
                                    LwSubline = oHelper.GetItemWIP(oWIPOfModel, "LW"),
                                    BodyMain = oHelper.GetItemWIP(oWIPofMain, "BODY"),
                                    BodySubline = oHelper.GetItemWIP(oWIPOfModel, "BODY"),
                                    TopMain = oHelper.GetItemWIP(oWIPofMain, "TOP"),
                                    TopSubline = oHelper.GetItemWIP(oWIPOfModel, "TOP"),
                                    BottomMain = oHelper.GetItemWIP(oWIPofMain, "BOTTOM"),
                                    BottomSubline = oHelper.GetItemWIP(oWIPOfModel, "BOTTOM"),
                                });
                                oPlan.PartNo = "";
                            }
                            else
                            {
                                oResults.Add(new ApsSublineStockBalance() { ApsSeq = "", Modelcode = "", Modelname = "", ApsPlan = 0, ApsRemainPlan = 0, ApsResult = 0, Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}", ApsCurrent = "" });
                            }
                        }
                        else
                        {
                            MainPlanRelocate[IndexPlan].PrdPlanQty -= oHelper.ConvDec2Int(Math.Abs(Capacity));
                            if (oPlan.PartNo != "")
                            {
                                //ViApsPartStockScr oWipOfModel = WipCurrent.FirstOrDefault(x => x.ModelCode == oMainPlan.ModelCode);
                                //if (oWipOfModel == null)
                                //{
                                //    oWipOfModel = new ViApsPartStockScr();
                                //}
                                ViApsPartStockScr oWipOfModel = new ViApsPartStockScr();
                                List<PropWIP> oWIPOfModel = WIPSublines.Where(x => x.sebango == oMainPlan.ModelCode).ToList();
                                List<PropWIP> oWIPofMain = WIPMains.Where(x => x.sebango == oMainPlan.ModelCode).ToList();
                                oResults.Add(new ApsSublineStockBalance()
                                {
                                    ApsSeq = oPlan.PrdSeq.ToString(),
                                    Modelcode = oPlan.ModelCode,
                                    Modelname = oPlan.PartNo,
                                    ApsPlan = oPlan.APSPlanQty,
                                    ApsRemainPlan = isCurrent == true ? (oMainPlan.PrdPlanQty - (CntGastight + CntResultOfModel)) : (oMainPlan.PrdPlanQty - CntResultOfModel),
                                    ApsResult = isCurrent ? CntGastight : CntResultOfModel,
                                    Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}",
                                    ApsCurrent = isCurrent == true ? "CURRENT" : oPlan.ApsCurrent,
                                    StatorMain = oHelper.GetItemWIP(oWIPofMain, "STATOR"),
                                    StatorSubline = oHelper.GetItemWIP(oWIPOfModel, "STATOR"),
                                    RotorMain = oHelper.GetItemWIP(oWIPofMain, "ROTOR"),
                                    RotorSubline = oHelper.GetItemWIP(oWIPOfModel, "ROTOR"),
                                    HsMain = oHelper.GetItemWIP(oWIPofMain, "HS"),
                                    HsSubline = oHelper.GetItemWIP(oWIPOfModel, "HS"),
                                    CsMain = oHelper.GetItemWIP(oWIPofMain, "CS"),
                                    CsSubline = oHelper.GetItemWIP(oWIPOfModel, "CS"),
                                    FsMain = oHelper.GetItemWIP(oWIPofMain, "FS"),
                                    FsSubline = oHelper.GetItemWIP(oWIPOfModel, "FS"),
                                    LwMain = oHelper.GetItemWIP(oWIPofMain, "LW"),
                                    LwSubline = oHelper.GetItemWIP(oWIPOfModel, "LW"),
                                    BodyMain = oHelper.GetItemWIP(oWIPofMain, "BODY"),
                                    BodySubline = oHelper.GetItemWIP(oWIPOfModel, "BODY"),
                                    TopMain = oHelper.GetItemWIP(oWIPofMain, "TOP"),
                                    TopSubline = oHelper.GetItemWIP(oWIPOfModel, "TOP"),
                                    BottomMain = oHelper.GetItemWIP(oWIPofMain, "BOTTOM"),
                                    BottomSubline = oHelper.GetItemWIP(oWIPOfModel, "BOTTOM"),
                                });
                                oPlan.PartNo = "";
                            }
                            else
                            {
                                oResults.Add(new ApsSublineStockBalance() { ApsSeq = "", Modelcode = "", Modelname = "", ApsPlan = 0, ApsRemainPlan = 0, ApsResult = 0, Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}", ApsCurrent = "" });
                            }
                            DTStart = DTStart.AddHours(2);
                            HourLoop = DTStart.Hour;
                            Capacity = 120;
                        }
                    }
                    else
                    {
                        break;
                    }

                }

                var MDW27_MODEL_MASTER = efSCM.WmsMdw27ModelMasters.GroupBy(x => new { sebango = x.Sebango, model = x.Model }).Select(x => new { sebango = x.Key.sebango, model = x.Key.model }).ToList();
                List<ApsProductionPlan> ApsPlanNextDay = efSCM.ApsProductionPlans.Where(x => x.ApsPlanDate.Value.Date >= DTCurrent.Date.AddDays(1) && x.ApsPlanDate.Value.Date <= DTCurrent.Date.AddDays(2) && x.Lrev == "999" && x.Wcno == "904" && x.Subline == "ASSEMBLY LINE4 (SCR)").OrderBy(x => x.ApsPlanDate).ThenBy(x => x.PrdSeq).ToList();
                DateTime DTNext = DTCurrent.AddDays(1);
                bool CanUsedNextDay = true;
                string CanHourNextDay = "";
                foreach (ApsProductionPlan oPlan in ApsPlanNextDay)
                {
                    //int index = ApsPlanNextDay.FindIndex(x=>x.PrdPlanCode == oPlan.PrdPlanCode);
                    //string test = oPlan.ApsPlanDate.Value.ToString("dd/MM/YYYY");

                    decimal PlanQty = oHelper.ConvDec2Int(oPlan.PrdPlanQty);
                    while (PlanQty > 0)
                    {
                        if (HourLoop == 8 && CanUsedNextDay == true)
                        {
                            oResults.Add(new ApsSublineStockBalance() { ApsSeq = "", Modelcode = "", Modelname = "", ApsPlan = 0, ApsRemainPlan = 0, ApsResult = 0, Hhmm = DTNext.ToString("dd/MM/yyyy"), ApsCurrent = "NEXTDAY" });
                            DTNext = DTNext.AddDays(1);
                            CanUsedNextDay = false;
                            CanHourNextDay = HourLoop.ToString();
                        }
                        else if (CanUsedNextDay == false && CanHourNextDay != HourLoop.ToString())
                        {
                            CanUsedNextDay = true;
                        }
                        PlanQty -= Capacity;
                        if (PlanQty > 0)
                        {
                            // INSERT ROW MAIN
                            if (oPlan.PartNo != "")
                            {
                                string sebango = MDW27_MODEL_MASTER.FirstOrDefault(x => x.model == oPlan.PartNo.Replace("-10", "")) != null ? MDW27_MODEL_MASTER.FirstOrDefault(x => x.model == oPlan.PartNo.Replace("-10", "")).sebango : "";
                                //ViApsPartStockScr oWipOfModel = WipCurrent.FirstOrDefault(x => x.ModelCode == sebango);
                                //if (oWipOfModel == null)
                                //{
                                //    oWipOfModel = new ViApsPartStockScr();
                                //}
                                //ViApsPartStockScr oWipOfModel = new ViApsPartStockScr();
                                List<PropWIP> oWIPOfModel = WIPSublines.Where(x => x.sebango == sebango).ToList();
                                List<PropWIP> oWIPofMain = WIPMains.Where(x => x.sebango == sebango).ToList();
                                oResults.Add(new ApsSublineStockBalance()
                                {
                                    ApsSeq = oPlan.PrdSeq.ToString(),
                                    Modelcode = sebango,
                                    Modelname = oPlan.PartNo,
                                    ApsPlan = oPlan.ApsPlanQty,
                                    ApsRemainPlan = oPlan.PrdPlanQty,
                                    ApsResult = 0,
                                    Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}",
                                    ApsCurrent = "",
                                    StatorMain = oHelper.GetItemWIP(oWIPofMain, "STATOR"),
                                    StatorSubline = oHelper.GetItemWIP(oWIPOfModel, "STATOR"),
                                    RotorMain = oHelper.GetItemWIP(oWIPofMain, "ROTOR"),
                                    RotorSubline = oHelper.GetItemWIP(oWIPOfModel, "ROTOR"),
                                    HsMain = oHelper.GetItemWIP(oWIPofMain, "HS"),
                                    HsSubline = oHelper.GetItemWIP(oWIPOfModel, "HS"),
                                    CsMain = oHelper.GetItemWIP(oWIPofMain, "CS"),
                                    CsSubline = oHelper.GetItemWIP(oWIPOfModel, "CS"),
                                    FsMain = oHelper.GetItemWIP(oWIPofMain, "FS"),
                                    FsSubline = oHelper.GetItemWIP(oWIPOfModel, "FS"),
                                    LwMain = oHelper.GetItemWIP(oWIPofMain, "LW"),
                                    LwSubline = oHelper.GetItemWIP(oWIPOfModel, "LW"),
                                    BodyMain = oHelper.GetItemWIP(oWIPofMain, "BODY"),
                                    BodySubline = oHelper.GetItemWIP(oWIPOfModel, "BODY"),
                                    TopMain = oHelper.GetItemWIP(oWIPofMain, "TOP"),
                                    TopSubline = oHelper.GetItemWIP(oWIPOfModel, "TOP"),
                                    BottomMain = oHelper.GetItemWIP(oWIPofMain, "BOTTOM"),
                                    BottomSubline = oHelper.GetItemWIP(oWIPOfModel, "BOTTOM"),
                                });
                                oPlan.PartNo = "";
                            }
                            else
                            {
                                oResults.Add(new ApsSublineStockBalance() { ApsSeq = "", Modelcode = "", Modelname = "", ApsPlan = 0, ApsRemainPlan = 0, ApsResult = 0, Hhmm = $"{DTStart.ToString("HH-")}{DTStart.AddHours(2).ToString("HH")}", ApsCurrent = "" });
                            }
                            DTStart = DTStart.AddHours(2);
                            HourLoop = DTStart.Hour;
                            Capacity = 120;
                        }
                        else
                        {
                            Capacity = Math.Abs(PlanQty);
                        }
                    }
                }
                return Ok(new
                {
                    main = MainPlans,
                    wip = oResults,
                    gastight = oLastGasTight,
                    shrinkgage = oShrinkGage,
                    masterSubline = ListLineAndProcess
                });
            }
            catch (Exception e)
            {
                return Ok();
            }
        }

        [HttpPost]
        [Route("/Aps/MachineChangeSeq")]
        public IActionResult MachineChangeSeq([FromBody] List<ParamMachineChangeSeq> rPlan)
        {
            foreach (ParamMachineChangeSeq oPlan in rPlan)
            {
                ApsProductionPlan mPlan = efSCM.ApsProductionPlans.FirstOrDefault(x => x.Lrev == "999" && x.PrdPlanCode == oPlan.prdPlanCode);
                if (mPlan != null)
                {
                    mPlan.PrdSeq = oPlan.prdSeq.ToString();
                    efSCM.ApsProductionPlans.Update(mPlan);
                }
            }
            int update = efSCM.SaveChanges();
            return Ok(new
            {
                status = update > 0 ? true : false
            });
        }

        [HttpGet]
        [Route("/Aps/GetPrivilegeBackflush/{empcode}")]
        public IActionResult GetPrivilegeBackflushByEmpcode(string empcode = "")
        {
            List<string> wcno = new List<string>();

            try
            {
                List<DictMstr> ListPrivilegeBackflush = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "PRIVILEGE_BACKFLUSH" && x.Code == empcode).ToList();
                if (ListPrivilegeBackflush.Count > 0)
                {
                    wcno = ListPrivilegeBackflush[0].Description.Split(",").ToList<string>();
                }
            }

            catch
            {
                wcno = new List<string>();
            }
            return Ok(wcno);
        }

        [HttpPost]
        [Route("/ApsGetStockSubline")]
        public IActionResult GetMainPlanTest([FromBody] ParamGetStockSubline param)
        {
            #region set param http
            string ymd = param.ymd;
            string ym = ymd.Substring(0, 6);
            #endregion
            #region create param
            List<ViApsPartStockScr> stockCurrent = new List<ViApsPartStockScr>();
            Dictionary<string, string> TempModelStock = new Dictionary<string, string>();
            #endregion

            List<ApsSublineStockBalance> SublineStocks = efSCM.ApsSublineStockBalances.Where(x => x.Ym == ym && x.Ymd == ymd && x.ApsRemainPlan >= 0 && x.ApsResult > 0).ToList();
            string YMD = DateTime.Now.ToString("yyyyMMdd");
            List<FGPlanInfo> oMainPlans = oSrvMP.getMainPlan(ymd, "904", new List<ApsSublineStockBalance>());
            List<string> oModelCode = oMainPlans.Where(x => x.APSPlanDate.ToString("yyyyMMdd") == YMD).GroupBy(x => x.ModelCode).Select(o => o.Key).ToList();
            SublineStocks = SublineStocks.Where(x => oModelCode.Contains(x.Modelcode)).ToList();
            List<ViApsPartStockScr> rCurrentStock = efSCM.ViApsPartStockScrs.Where(x => x.Ym == ym && oModelCode.Contains(x.ModelCode != null ? x.ModelCode : "")).ToList();
            foreach (var item in oMainPlans)
            {
                string planDate = item.APSPlanDate.ToString("yyyyMMdd");
                string wcno = item.WCNO;
                //string modelName = item.PartNo.Replace("-10", "");
                string modelCode = item.ModelCode;
                if (planDate == ymd)
                {
                    if (TempModelStock.ContainsKey(modelCode) == false)
                    {
                        ViApsPartStockScr oStockCurrent = rCurrentStock.FirstOrDefault(x => x.Pwcno == wcno && x.ModelCode == modelCode);
                        if (oStockCurrent != null)
                        {
                            stockCurrent.Add(oStockCurrent);
                            TempModelStock.Add(modelCode, wcno);
                        }
                    }
                }
            }
            return Ok(new
            {
                stockBalance = SublineStocks,
                stockCurrent
            });
        }

        [HttpPost]
        [Route("/ApsAdminUpdateDrawing")]
        public IActionResult ApsAdminUpdateDrawing([FromBody] ParamAdminUpdateDrawing param)
        {
            string drawing = param.drawing;
            string cm = param.cm;
            string updateBy = param.empcode;
            List<DictMstr> DictDrawings = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.Ref2 == drawing).ToList();
            int update = 0;
            if (drawing != "")
            {
                foreach (DictMstr oDrawing in DictDrawings)
                {
                    oDrawing.Ref3 = cm;
                    oDrawing.UpdateDate = DateTime.Now;
                    oDrawing.UpdateBy = updateBy;
                    efSCM.DictMstrs.Update(oDrawing);
                }
                update = efSCM.SaveChanges();
            }

            return Ok(new
            {
                status = update > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("/mpck/layouts")]
        public IActionResult GetNPCKLayouts()
        {
            //            var res = efSCM.MpckLayouts.FromSqlRaw(@"SELECT  LayoutCode,LayoutName,Factory,Width,Height,
            //(CASE WHEN BoardId IS NULL THEN '' ELSE BoardId END ) AS BoardId,
            //(CASE WHEN BypassMQ IS NULL THEN 'FALSE' ELSE BypassMQ END ) AS BypassMQ,
            //(CASE WHEN BypassSA IS NULL THEN 'FALSE' ELSE BypassSA END ) AS BypassSA,
            //LayoutStatus,
            //LayoutSubName,
            //Line
            //FROM [dbSCM].[dbo].[MPCK_Layout] WHERE LayoutStatus = 'ACTIVE'");
            List<MpckLayout> layouts = efSCM.MpckLayouts.Where(x => x.LayoutStatus == "ACTIVE").Select(o => new MpckLayout()
            {
                LayoutCode = o.LayoutCode,
                LayoutName = o.LayoutName,
                Factory = o.Factory,
                Width = o.Width,
                Height = o.Height,
                BoardId = (o.BoardId != null ? o.BoardId : ""),
                BypassMq = (o.BypassMq != null ? o.BypassMq : "FALSE"),
                BypassSa = (o.BypassSa != null ? o.BypassSa : "FALSE")
            }).ToList();
            return Ok(layouts);
        }

        [HttpPost]
        [Route("/ApsEditPrivilege")]
        public IActionResult ApsEditPrivilege([FromBody] ParamApsEditPrivilege param)
        {
            //List<string> Privileges = param.privilege
            return Ok();
        }

        [HttpGet]
        [Route("/ApsPartGroups")]
        public IActionResult ApsPartGroups()
        {
            List<PropsPartGroupMaster> PartGroups = new List<PropsPartGroupMaster>();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT [CODE] ,CASE WHEN [CODE] = 'FS' THEN 'FIXED & ORBITING SCROLL' ELSE [DESCRIPTION] END AS [DESC] FROM [dbSCM].[dbo].[DictMstr] WHERE DICT_TYPE = 'PART_GROUP_MASTER' AND DICT_STATUS = 'ACTIVE' ";
            DataTable dt = dbSCM.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                PropsPartGroupMaster oPartGroup = new PropsPartGroupMaster();
                oPartGroup.code = dr["CODE"].ToString();
                oPartGroup.desc = dr["DESC"].ToString();
                PartGroups.Add(oPartGroup);
            }
            return Ok(PartGroups);
        }

        [HttpPost]
        [Route("/ApsGetInOut")]
        public IActionResult ApsGetInOut([FromBody] ParamApsGetInOut param)
        {
            string ymd = param.ymd;
            string ym = ymd.Substring(0, 6);
            string group = param.group;
            string condGroup = group != "" ? (group != "FS" ? $" AND WC.NOTE IN ('{group}') " : $" AND WC.NOTE IN ('FS','OS') ") : "";
            string drawing = param.drawing != null ? param.drawing : "";
            List<PropsApsInOut> InOuts = new List<PropsApsInOut>();
            SqlCommand sql = new SqlCommand();
            #region string sql get in-out main and sub [line]
            sql.CommandText = $@"SELECT @YMD AS PLAN_DATE,A.WCNO,A.PARTNO,A.CM ,ISNULL(A.SUB_LBAL,0) SUB_LBAL,ISNULL(A.SUB_RECQTY,0) AS SUB_RECQTY,ISNULL(A.SUB_ISSQTY,0) AS SUB_ISSQTY,
ISNULL(ISNULL(SUB_LBAL,0)+ (CASE WHEN ISNULL(A.SUB_ISSQTY,0) >= 0 THEN ISNULL(A.SUB_RECQTY,0) - ISNULL(A.SUB_ISSQTY,0) ELSE ISNULL(A.SUB_RECQTY,0) + ISNULL(A.SUB_ISSQTY,0) END ),0) AS SUB_BAL,
ISNULL(MAIN_LBAL,0) AS MAIN_LBAL,
ISNULL(A.MAIN_RECQTY,0) AS MAIN_RECQTY,ISNULL(A.MAIN_ISSQTY,0) MAIN_ISSQTY,
ISNULL(ISNULL(MAIN_LBAL,0)+ (CASE WHEN ISNULL(A.MAIN_ISSQTY,0) >= 0 THEN ISNULL(A.MAIN_RECQTY,0) - ISNULL(A.MAIN_ISSQTY,0) ELSE ISNULL(A.MAIN_RECQTY,0) + ISNULL(A.MAIN_ISSQTY,0) END ),0) AS MAIN_BAL
FROM (SELECT   WC.[DESCRIPTION] AS WCNO ,WC.[REF2] AS PARTNO,WC.REF3 AS CM ,
(SELECT LBAL + (
(ISNULL((SELECT SUM(ISNULL(TransQty,0))   
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]  
WHERE YMD <=  DATEADD(DAY,-1,@YMD) AND YMD >= SUBSTRING(@YMD,1,6) AND WCNO = WC.[DESCRIPTION] AND  PARTNO =  WC.[REF2] AND CM = WC.REF3 AND  TransType = 'IN'),0)) - 
(ISNULL((SELECT SUM(ISNULL(TransQty,0))  
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]  
WHERE YMD <=  DATEADD(DAY,-1,@YMD) AND YMD >= SUBSTRING(@YMD,1,6) AND WCNO = WC.[DESCRIPTION] AND  PARTNO =  WC.[REF2] AND CM = WC.REF3 AND  TransType = 'OUT'),0))
)
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK] 
WHERE YM = SUBSTRING(CONVERT(varchar,DATEADD(DAY,-1,@YMD),112),1,6) AND  WCNO = WC.[DESCRIPTION] AND PARTNO =  WC.[REF2] AND CM = WC.REF3 AND WCNO != '904') AS SUB_LBAL,

(SELECT LBAL + (
(ISNULL((SELECT SUM(ISNULL(TransQty,0))   
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]  
WHERE YMD <=  DATEADD(DAY,-1,@YMD) AND YMD >= SUBSTRING(@YMD,1,6) AND WCNO =  @WCNO_MAIN AND  PARTNO =  WC.[REF2] AND CM = WC.REF3 AND  TransType = 'IN'),0)) - 
(ISNULL((SELECT SUM(ISNULL(TransQty,0))  
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]  
WHERE YMD <=  DATEADD(DAY,-1,@YMD) AND YMD >= SUBSTRING(@YMD,1,6) AND WCNO =  @WCNO_MAIN AND  PARTNO =  WC.[REF2] AND CM = WC.REF3 AND  TransType = 'OUT'),0))
)
FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK] 
WHERE YM = SUBSTRING(CONVERT(varchar,DATEADD(DAY,-1,@YMD),112),1,6) AND  WCNO =  @WCNO_MAIN AND PARTNO =  WC.[REF2] AND CM = WC.REF3 AND WCNO =  @WCNO_MAIN) AS MAIN_LBAL,

(SELECT  SUM(TransQty) AS RECQTY
  FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]
  WHERE YM =  @YM AND YMD = @YMD AND WCNO = WC.[DESCRIPTION] AND PARTNO = WC.[REF2] AND CM = WC.REF3 AND TransType = 'IN') AS SUB_RECQTY,
  (SELECT  SUM(TransQty) AS RECQTY
  FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]
  WHERE YM =   @YM AND YMD = @YMD AND WCNO = WC.[DESCRIPTION] AND PARTNO = WC.[REF2] AND CM = WC.REF3 AND TransType = 'OUT') AS  SUB_ISSQTY,  
  (SELECT  SUM(TransQty) AS RECQTY
  FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]
  WHERE YM =  @YM AND YMD = @YMD AND WCNO = '904' AND PARTNO = WC.[REF2] AND CM = WC.REF3 AND TransType = 'IN') AS MAIN_RECQTY,
  (SELECT  SUM(TransQty) AS RECQTY
  FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION]
  WHERE YM =   @YM  AND YMD = @YMD AND WCNO = '904' AND PARTNO = WC.[REF2] AND CM = WC.REF3 AND TransType = 'OUT') AS  MAIN_ISSQTY
FROM [dbSCM].[dbo].[DictMstr]  WC 
WHERE WC.DICT_SYSTEM = 'WIP_STOCK' AND DICT_STATUS = 'ACTIVE' AND WC.DICT_TYPE LIKE 'WC_MASTER' {condGroup}
) AS A
";
            sql.Parameters.Add(new SqlParameter("@YM", ym));
            sql.Parameters.Add(new SqlParameter("@YMD", ymd));
            sql.Parameters.Add(new SqlParameter("@WCNO_MAIN", "904"));
            #endregion
            DataTable dt = dbSCM.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                PropsApsInOut oInOut = new PropsApsInOut();
                oInOut.planDate = dr["PLAN_DATE"].ToString();
                oInOut.wcno = dr["WCNO"].ToString();
                oInOut.partno = dr["PARTNO"].ToString();
                oInOut.cm = dr["CM"].ToString();
                oInOut.subLbal = oHelper.ConvStr2Dec(dr["SUB_LBAL"].ToString());
                oInOut.subRecQty = oHelper.ConvStr2Dec(dr["SUB_RECQTY"].ToString());
                oInOut.subIssQty = oHelper.ConvStr2Dec(dr["SUB_ISSQTY"].ToString());
                oInOut.subLbal = oHelper.ConvStr2Dec(dr["SUB_BAL"].ToString());

                oInOut.mainLbal = oHelper.ConvStr2Dec(dr["MAIN_LBAL"].ToString());
                oInOut.mainRecQty = oHelper.ConvStr2Dec(dr["MAIN_RECQTY"].ToString());
                oInOut.mainIssQty = oHelper.ConvStr2Dec(dr["MAIN_ISSQTY"].ToString());
                oInOut.mainBal = oHelper.ConvStr2Dec(dr["MAIN_BAL"].ToString());
                InOuts.Add(oInOut);
            }
            return Ok(InOuts);
        }


        [HttpPost]
        [Route("/ApsGetDrawingAdjust")]
        public IActionResult ApsGetDrawingAdjust([FromBody] ParamApsGetDrawingAdjust param)
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            string type = param.type;
            string group = param.group;
            string sebango = param.sebango;

            List<string> DictWCNO = efSCM.DictMstrs.Where(x => x.DictType == "WC_MASTER").GroupBy(x => x.Description).Select(x => x.Key).ToList();

            SqlCommand sql = new SqlCommand();
            //sql.CommandText = $@"SELECT CODE AS MODEL  ,[REF2] AS PARTNO ,[REF3] AS CM  ,[NOTE] AS PARTGROUP  FROM [dbSCM].[dbo].[DictMstr]  WHERE DICT_SYSTEM = 'WIP_STOCK' AND DICT_TYPE LIKE '%PART_SET_IN%' AND DICT_STATUS = 'ACTIVE' AND CODE = '{sebango}' AND NOTE = '{group}'";
            sql.CommandText = $@"SELECT * FROM (SELECT CODE AS MODEL  ,[REF2] AS PARTNO ,[REF3] AS CM  ,[NOTE] AS PARTGROUP,ROW_NUMBER() OVER (PARTITION BY CODE,[REF2] ORDER BY REF3 DESC) AS rn   FROM [dbSCM].[dbo].[DictMstr]  
WHERE DICT_SYSTEM = 'WIP_STOCK' AND (DICT_TYPE LIKE '%PART_SET_IN%' OR DICT_TYPE LIKE 'PART_SET_OUT') AND DICT_STATUS = 'ACTIVE'
 AND CODE = '{sebango}'
 AND NOTE = '{group}'
AND CODE IS NOT NULL
AND CODE != '' 
GROUP BY  CODE   ,[REF2]  ,[REF3] ,[NOTE]) A
WHERE A.rn =  1";
            DataTable dt = dbSCM.Query(sql);
            if (dt.Rows.Count > 0)
            {
                List<PropDrawings> Drawings = oApsService.GetDrawings();
                string drawing = dt.Rows[0]["PARTNO"].ToString();
                PropDrawings oDrawing = Drawings.FirstOrDefault(x => x.drawing == drawing.Trim());
                if (oDrawing != null)
                {
                    EkbWipPartStock oWipStock = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Ym == dtNow.ToString("yyyyMM") && (type == "main" ? (x.Wcno == "904") : (x.Wcno != "904")) && x.Partno == oDrawing.drawing && x.Cm == oDrawing.cm && (type == "main" ? true : DictWCNO.Contains(x.Wcno)))!;
                    if (oWipStock != null)
                    {
                        oDrawing.adj_qty = oHelper.ConvUnDec2Int(oWipStock.Bal);
                    }
                    else
                    {
                        oDrawing.adj_qty = 0;
                    }
                    if (type == "main")
                    {
                        oDrawing.wcno = "904";
                    }
                    return Ok(oDrawing);
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        [Route("/adjstock/login/{empcode}")]
        public IActionResult LoginAdjStock(string empcode)
        {
            EmpProps empProp = new EmpProps();
            //Employee employee = efHRM.Employee.FirstOrDefault(x => x.Code == empcode);
            DictMstr AdjStockPrivilege = efSCM.DictMstrs.FirstOrDefault(x => x.DictSystem == "WIP_STOCK" && x.DictType == "ADJUST_STOCK" && x.Code == empcode);
            if (AdjStockPrivilege != null)
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = @"SELECT * FROM [dbHRM].[dbo].[Employee] WHERE CODE = @CODE";
                sql.Parameters.Add(new SqlParameter("@CODE", empcode));
                DataTable dtEmp = dbHRM.Query(sql);
                if (dtEmp.Rows.Count > 0)
                {
                    empProp.code = dtEmp.Rows[0]["CODE"].ToString();
                    empProp.name = dtEmp.Rows[0]["NAME"].ToString();
                    empProp.surn = dtEmp.Rows[0]["SURN"].ToString();
                    empProp.img = $"http://dcidmc.dci.daikin.co.jp/PICTURE/{dtEmp.Rows[0]["CODE"].ToString()}.JPG";
                    empProp.fullName = $"{empProp.name}.{empProp.surn.Substring(0, 1)}";
                }
            }
            return Ok(empProp);
        }

        [HttpGet]
        [Route("/GetGastight/{ymd}")]
        public IActionResult GetGastight(string ymd)
        {
            List<PropsGastight> Gastights = new List<PropsGastight>();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT  TRIM(A.[Serial]) as serial,TRIM(A.Model_Code)  as model,B.MODEL AS modelname ,A.Insert_Date as [insertDate] 
FROM [dbIoT].[dbo].[SCR_GasTight]    A
LEFT JOIN [192.168.226.86].[dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] B
ON TRIM(A.Model_Code) = B.SEBANGO
WHERE FORMAT(DATEADD(HOUR,-8,A.[Insert_Date]),'yyyyMMdd') = '{ymd}' AND A.Serial != 'ERROR' AND TRIM(A.[Model_Code]) != 'ERRO'
GROUP BY  TRIM(A.[Serial]),TRIM(A.Model_Code)  ,B.MODEL  ,A.Insert_Date order by A.Insert_Date desc";
            DataTable dt = dbIOT.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                PropsGastight oGas = new PropsGastight();
                oGas.serial = dr["serial"].ToString();
                oGas.model = dr["model"].ToString();
                oGas.insertDate = dr["insertDate"].ToString();
                oGas.modelname = dr["modelname"].ToString();
                Gastights.Add(oGas);
            }
            PropsGastightChart GastightChart = new PropsGastightChart();
            GastightChart.labels = Gastights.OrderBy(x => x.insertDate).GroupBy(x => x.model).Select(x => x.Key).ToList();
            GastightChart.data = Gastights.OrderBy(x => x.insertDate).GroupBy(x => new
            {
                x.model
            }).Select(y => Gastights.Where(o => o.model == y.Key.model).Count().ToString()).ToList();
            return Ok(new
            {
                data = Gastights,
                chart = GastightChart
            });
        }

        [HttpPost]
        [Route("/GetInOut")]
        public IActionResult GetInOut()
        {

            return Ok();
        }

        [HttpGet]
        [Route("GetUserInformation/{empcode}")]
        public IActionResult GetUserInformation(string empcode)
        {
            List<string> ListWCSubline = efSCM.DictMstrs.Where(x => x.DictType == "WC_MASTER").GroupBy(x => x.Description).Select(x => x.Key).ToList();
            List<DictMstr> UserInformation = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "APS_PRIVILEGE" && x.Code == empcode).ToList();
            return Ok(new
            {
                wcno = ListWCSubline,
                userInfo = UserInformation
            });
        }

        [HttpPost]
        [Route("/GetPriorityPlan")]
        public IActionResult GetPriorityPlan()
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            DateTime dtStart = dtNow;
            DateTime dtEnd = dtNow.AddDays(14);
            List<PropPriorityPlan> res = new List<PropPriorityPlan>();
            while (dtStart.Date <= dtEnd.Date)
            {
                SqlCommand sql = new SqlCommand();
                int day = int.Parse(dtStart.ToString("dd"));
                //                sql.CommandText = $@"SELECT A.*,CEILING( CAST(A.PLANQTY AS FLOAT) / CAST(B.PLQty AS FLOAT)) AS PLQTY  FROM (  
                //			SELECT  APSSEQ,  PL.APS_PlanDate,PL.WCNO,PL.LINENAME,PL.MODEL,PL.SEBANGO,PLPK.Day{day.ToString()} PLANQTY, 
                //					SUBSTRING(REPLACE(TRIM(PLPK.Model),REPLACE(PL.MODEL,'-10',''),''),CHARINDEX('-',REPLACE(TRIM(PLPK.Model),REPLACE(PL.MODEL,'-10',''),''))+1,LEN(REPLACE(TRIM(PLPK.Model),REPLACE(PL.MODEL,'-10',''),''))) AS PLTYPE 
                //					FROM (
                //						SELECT MIN(APS_SEQ) APSSEQ, APS.APS_PlanDate,APS.WCNO,APS.SUBLINE LINENAME,APS.PARTNO MODEL,MODEL_MST.SEBANGO   FROM [dbSCM].[dbo].[APS_ProductionPlan] APS
                //						LEFT JOIN (SELECT [SEBANGO],model MODEL FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] GROUP BY SEBANGO,model) MODEL_MST ON MODEL_MST.MODEL = REPLACE(APS.PartNo,'-10','')
                //						WHERE APS.WCNO = '904' AND APS.SUBLINE = 'ASSEMBLY LINE4 (SCR)' AND APS.LREV = '999' AND APS.APS_PlanDate = '{dtStart.ToString("yyyyMMdd")}'
                //						GROUP BY APS.APS_PlanDate , APS.WCNO, APS.SUBLINE,APS.PARTNO ,MODEL_MST.SEBANGO ) PL 
                //				LEFT JOIN [dbSCM].[dbo].[APS_PlanDailyReport_DEV_RPT] PLPK ON PLPK.MODEL LIKE '' + REPLACE(PL.MODEL,'-10','') + '%' AND PLPK.YMD = '{dtNow.ToString("yyyyMMdd")}'  AND PLPK.Day{day.ToString()} IS NOT NULL
                //					AND PLPK.WCNO = '904' AND PLPK.LineName = 'Packing-904' AND PLPK.PlanSum > 0) A
                //LEFT JOIN [dbSCM].[dbo].[AL_PalletTypeMapping] B  ON B.PLTYPE = A.PLTYPE
                //ORDER BY APS_PlanDate, APSSEQ ASC ";
                sql.CommandText = $@"SELECT RES.*,CEILING( CAST(RES.PLANQTY AS FLOAT) / CAST(B.PLQty AS FLOAT)) AS PLQTY FROM (SELECT PL.APS_SEQ,PL.APS_PlanDate,PL.WCNO,PL.SUBLINE LINENAME,PL.PartNo MODEL,M.SEBANGO,APS_PlanQty PLANQTY,
SUBSTRING(REPLACE(TRIM(PLPK.Model),REPLACE(M.MODEL,'-10',''),''),CHARINDEX('-',REPLACE(TRIM(PLPK.Model),REPLACE(M.MODEL,'-10',''),''))+1,LEN(REPLACE(TRIM(PLPK.Model),REPLACE(M.MODEL,'-10',''),''))) AS PLTYPE  
FROM [dbSCM].[dbo].[APS_ProductionPlan] PL 
LEFT JOIN (SELECT  [MODEL] ,[SEBANGO] FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] GROUP BY MODEL,SEBANGO) M
ON M.MODEL = REPLACE(PL.PartNo,'-10','')
LEFT JOIN [dbSCM].[dbo].[APS_PlanDailyReport_DEV_RPT] PLPK ON PLPK.MODEL LIKE '' + REPLACE(M.MODEL,'-10','') + '%' AND PLPK.YMD = '{dtNow.ToString("yyyyMMdd")}'  AND PLPK.Day{day} IS NOT NULL AND PLPK.WCNO = '904' AND PLPK.LineName = 'Packing-904' AND PLPK.PlanSum > 0
WHERE PL.SUBLINE = 'ASSEMBLY LINE4 (SCR)' AND PL.APS_PlanDate = '{dtStart.ToString("yyyy-MM-dd")}' AND PL.LREV = '999') RES
LEFT JOIN [dbSCM].[dbo].[AL_PalletTypeMapping] B  ON B.PLTYPE = RES.PLTYPE
ORDER BY CAST(RES.APS_SEQ AS INT) ASC
";
                DataTable dt = dbSCM.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    res.Add(new PropPriorityPlan()
                    {
                        date = dtStart.ToString("yyyyMMdd"),
                        wcno = dr["WCNO"].ToString(),
                        subLine = dr["LINENAME"].ToString(),
                        model = dr["MODEL"].ToString(),
                        modelCode = dr["SEBANGO"].ToString(),
                        plan = oHelper.ConvStr2Int(dr["PLANQTY"].ToString()),
                        packing = dr["PLTYPE"].ToString(),
                        palletQty = oHelper.ConvStr2Int(dr["PLQTY"].ToString()),
                        remark = ""
                    });
                }
                dtStart = dtStart.AddDays(1);
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("/ApsSavePrivilege")]
        public IActionResult ApsSavePrivilege([FromBody] PramApsSavePrivilege param)
        {
            string empcodeTarget = param.empcode;
            string updateBy = param.updateBy;
            List<string> wcno = param.wcno;
            string privilege = param.privilege;
            DictMstr oPrivilege = efSCM.DictMstrs.FirstOrDefault(x => x.DictSystem == "WIP_STOCK" && x.DictType == "APS_PRIVILEGE" && x.Code == empcodeTarget && x.Description == privilege);
            if (oPrivilege != null)
            {
                if (privilege == "backflush")
                {
                    string PrevWcno = oPrivilege.RefCode;
                    oPrivilege.RefCode = string.Join(",", wcno);
                    oPrivilege.UpdateBy = updateBy;
                    oPrivilege.UpdateDate = DateTime.Now;
                    efSCM.DictMstrs.Update(oPrivilege);
                    int action = efSCM.SaveChanges();
                    return Ok(new
                    {
                        status = action > 0 ? (PrevWcno == string.Join(",", wcno) ? false : true) : false,
                        message = PrevWcno == string.Join(",", wcno) ? "ไม่สามารถแก้ไขสิทธิการบันทึกข้อมูล Backflush ได้ เนื่องจาก wcno ที่เลือกมาไม่แตกต่างจากเดิม" : "ไม่สามารถแก้ไขสิทธิการบันทึกข้อมูล Backflush ได้ เนื่องจาก เกิดข้อผิดพลาดระหว่างบันทึกข้อมูล"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = false,
                        message = $"พนักงาน {empcodeTarget} มีสิทธิดังกล่าวอยู่แล้ว"
                    });
                }
            }
            else
            {
                DictMstr newPrivilege = new DictMstr()
                {
                    DictSystem = "WIP_STOCK",
                    DictType = "APS_PRIVILEGE",
                    Code = empcodeTarget,
                    Description = privilege.ToUpper(),
                    RefCode = string.Join(",", wcno),
                    CreateDate = DateTime.Now,
                    UpdateBy = updateBy,
                    UpdateDate = DateTime.Now,
                    DictStatus = "ACTIVE",
                };
                efSCM.DictMstrs.Add(newPrivilege);
                int action = efSCM.SaveChanges();
                return Ok(new
                {
                    status = action > 0 ? true : false,
                    message = $"ไม่สามารถเพิ่มสิทธิ {privilege} ได้ เนื่องจาก เกิดข้อผิดพลาดระหว่างบันทึกข้อมูล"
                });
            }

        }
        [HttpGet]
        [Route("/ApsGetLastGastight")]
        public IActionResult GetLastGastight()
        {
            try
            {
                DateTime dtNow = DateTime.Now.AddHours(-8);
                List<string> ModelInMainPlan = new List<string>();
                SqlCommand SqlGetMainPlan = new SqlCommand();
                SqlGetMainPlan.CommandText = $@"SELECT  REPLACE([PartNo] ,'-10','') AS MODEL,B.SEBANGO
                  FROM [dbSCM].[dbo].[APS_ProductionPlan] A
                  LEFT JOIN  (SELECT  [MODEL],SEBANGO FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE MODELGROUP = 'SCR' GROUP BY MODEL,SEBANGO) B
                  ON B.MODEL = REPLACE([PartNo] ,'-10','')
                  WHERE APS_PlanDate = '{dtNow.ToString("yyyy-MM-dd")}' AND LREV = '999' AND SUBLINE = 'ASSEMBLY LINE4 (SCR)'   
                GROUP BY  REPLACE([PartNo] ,'-10','') ,B.SEBANGO";
                DataTable dtMainPlans = dbSCM.Query(SqlGetMainPlan);
                foreach (DataRow dr in dtMainPlans.Rows)
                {
                    ModelInMainPlan.Add(dr["SEBANGO"].ToString());
                }
                string JoinModelInMainPlan = string.Join(", ", ModelInMainPlan.Select(line => $"'{line}'"));
                SqlCommand sql = new SqlCommand();
                //  sql.CommandText = $@" SELECT TOP(1) B.MODEL,A.[Model] SEBANGO,A.Insert_date INSER_DATE  FROM [dbIoT].[dbo].[SCR_Body_Shink_Fitting] A
                //LEFT JOIN (SELECT MODEL,SEBANGO  FROM [192.168.226.86].[dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE MODELGROUP = 'SCR' GROUP BY MODEL,SEBANGO) B
                //ON B.SEBANGO = A.Model
                //WHERE A.Model != 'ERRO'  AND A.Model IN ({JoinModelInMainPlan}) 
                //AND FORMAT(DATEADD(HOUR,-8,A.Insert_date),'yyyyMMdd') = '{dtNow.ToString("yyyyMMdd")}'
                //ORDER BY A.Insert_date desc ";
                sql.CommandText = $@"SELECT TOP(1) B.MODEL,A.Model_Code SEBANGO,A.Insert_date INSER_DATE  FROM [dbIoT].[dbo].[SCR_GasTight] A
              LEFT JOIN (SELECT MODEL,SEBANGO  FROM [192.168.226.86].[dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE MODELGROUP = 'SCR' GROUP BY MODEL,SEBANGO) B
              ON B.SEBANGO = A.Model_Code
              WHERE A.Model_Code != 'ERRO'  
            --AND A.Model_Code IN ({JoinModelInMainPlan}) 
             AND FORMAT(DATEADD(HOUR,-8,A.Insert_date),'yyyyMMdd') = '{dtNow.ToString("yyyyMMdd")}'
              ORDER BY A.Insert_date desc";
                DataTable dt = dbIOT.Query(sql);
                if (dt.Rows.Count > 0)
                {
                    return Ok(new
                    {
                        modelCode = dt.Rows[0]["MODEL"].ToString(),
                        modelName = dt.Rows[0]["SEBANGO"].ToString(),
                        dt = dt.Rows[0]["INSER_DATE"].ToString()
                    });
                }
                else
                {
                    return Ok(null);
                }

            }
            catch
            {
                return Ok(null);
            }
            //            Dictionary<string, string> models = new Dictionary<string, string>();
            //            DateTime dtNow = DateTime.Now.AddHours(-8);
            //            SqlCommand sql = new SqlCommand();
            //            sql.CommandText = $@"SELECT  REPLACE([PartNo] ,'-10','') AS MODEL,B.SEBANGO
            //  FROM [dbSCM].[dbo].[APS_ProductionPlan] A
            //  LEFT JOIN  (SELECT  [MODEL],SEBANGO FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE MODELGROUP = 'SCR' GROUP BY MODEL,SEBANGO) B
            //  ON B.MODEL = REPLACE([PartNo] ,'-10','')
            //  wHERE APS_PlanDate = '{dtNow.ToString("yyyy-MM-dd")}' AND LREV = '999' AND SUBLINE = 'ASSEMBLY LINE4 (SCR)'   
            //GROUP BY  REPLACE([PartNo] ,'-10','') ,B.SEBANGO";
            //            try
            //            {
            //                DataTable dt = dbSCM.Query(sql);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    models.Add(dr["SEBANGO"].ToString(), dr["MODEL"].ToString());
            //                }
            //                var oLastGastight = efCostyIoT.ScrGasTights.Where(x => x.InsertDate.Value.Date == dtNow.Date && models.Keys.Contains(x.ModelCode)).OrderBy(x => x.InsertDate).Select(x => new
            //                {
            //                    modelCode = x.ModelCode,
            //                    modelName = models.ContainsKey(x.ModelCode) ? models[x.ModelCode] : "",
            //                    dt = x.InsertDate
            //                }).LastOrDefault();
            //                return Ok(oLastGastight);
            //            }
            //            catch
            //            {
            //                return Ok(null);
            //            }
        }

        [HttpGet]
        [Route("/GetWIPSubline/{line}/{subline}")]
        public IActionResult GetWIPSubline(string line, string subline)
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            List<PropSCRCasingBody> ListSCRSubline = new List<PropSCRCasingBody>();
            List<PropSCRPartGroup> ListHeader = new List<PropSCRPartGroup>();
            //List<Dictionary<string, string>> keyValuePairs = new List<Dictionary<string, string>>();
            List<DictMstr> ModelOfPart = new List<DictMstr>();
            List<ModelGetStockCasingByGroup> RESStockCasing = new List<ModelGetStockCasingByGroup>();
            try
            {
                ModelOfPart = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType != null && x.DictType.StartsWith("PART_SET")).ToList();
                ListHeader = efSCM.DictMstrs.Where(x => x.DictStatus == "ACTIVE" && x.DictSystem == "WIP_STOCK" && x.DictType.StartsWith($"SORT_RM_{line.ToUpper()}_{subline.ToUpper()}")).OrderBy(x => x.Note).GroupBy(x => new
                {
                    GroupCode = x.RefCode,
                    GroupName = x.Description
                }).Select(o => new PropSCRPartGroup() { GroupCode = o.Key.GroupCode, GroupName = o.Key.GroupName }).ToList();
                //SqlCommand sql = new SqlCommand();
                //sql.CommandText = $@"SELECT * FROM [dbSCM].[dbo].[vi_APS_PartStock_SCR_CASING]";
                //DataTable dtStock = dbSCM.Query(sql);
                SqlCommand sqlRmInfo = new SqlCommand();
                sqlRmInfo.CommandText = $@"SELECT  L.REF4 LINE,L.REF_CODE SUBLINE,RM.DESCRIPTION PARTNO,RM.REF1 RM_WCNO,RM.REF2 RM,RM.REF3 RMCM,RM.NOTE RM_GROUP,GP.GROUP_NAME ,ISNULL(WIP.BAL,0) RM_WIP_PLANT,CAST(ISNULL(PS.Inventory,0) AS decimal) RM_WIP_PS FROM [dbSCM].[dbo].[DictMstr] L
 LEFT JOIN [dbSCM].[dbo].[DictMstr] RM
 ON RM.DICT_TYPE LIKE 'RM_' + L.REF4 + '_' + L.REF_CODE
 LEFT JOIN [dbSCM].[dbo].[EKB_WIP_PART_STOCK] WIP
 ON WIP.PARTNO + WIP.CM = RM.REF2+RM.REF3 AND WIP.WCNO = RM.REF1 AND WIP.YM = '{dtNow.ToString("yyyyMM")}'
 LEFT JOIN [dbSCM].[dbo].[ALPHA_TI2_STOCK_PART_SUPPLY] PS
 ON PS.Drawing  = RM.REF2 
 LEFT JOIN ( SELECT REF_CODE GROUP_CODE, DESCRIPTION GROUP_NAME FROM [dbSCM].[dbo].[DictMstr] WHERE DICT_TYPE LIKE 'SORT_RM_%' GROUP BY REF_CODE,DESCRIPTION 
 ORDER BY REF_CODE ASC OFFSET 0 ROWS ) GP
 ON GP.GROUP_CODE = RM.NOTE
 WHERE L.DICT_TYPE LIKE 'SUB_LINE_SORT%' AND L.REF4 = '{line.ToUpper()}'  AND L.REF_CODE = '{subline.ToUpper()}'  
 ORDER BY L.REF_CODE ASC ,L.REF2 ASC ,CAST(L.NOTE AS INT) ASC";
                DataTable dtRMInfo = dbSCM.Query(sqlRmInfo);

                SqlCommand strGetApsCasingPlan = new SqlCommand();
                strGetApsCasingPlan.CommandText = $@"
SELECT PL.WCNO,PL.APS_PlanDate,PL.PRD_SEQ,PL.PRD_PlanQty PRD_QTY,D.NOTE PG,D.REF4 MODEL,TRIM(PL.PartNo) PARTNO ,BOM.ACM CM,TRIM(PL.PartNo)+TRIM(BOM.ACM) PCM,ISNULL(WIP.Qty,0) SUBLINE_RESULT
FROM [dbo].[APS_ProductionPlan] PL 
LEFT JOIN [dbo].[DictMstr] D 
ON D.REF2 = PL.PartNo AND D.DICT_SYSTEM = 'WIP_STOCK' AND D.DICT_TYPE = 'WC_MASTER'
LEFT JOIN (SELECT  A.APARTNO,A.ACM FROM (
SELECT  APARTNO,ACM, ROW_NUMBER() OVER (PARTITION BY APARTNO ORDER BY ACM DESC) AS rn FROM [dbSCM].[dbo].[ALPHA_TSA_BOM]  
) A
WHERE A.rn = 1  ) BOM
ON BOM.APARTNO = PL.PARTNO 
LEFT JOIN (SELECT  [WCNO],[PARTNO],[CM] ,SUM([TransQty] ) Qty FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK_TRANSACTION] 
WHERE YMD = FORMAT(DATEADD(HOUR,-8,GETDATE()),'yyyyMMdd') AND TransType = 'IN' AND RefNo = 'UploadResult (IT)'
GROUP BY [WCNO],[PARTNO],[CM]  ORDER BY PARTNO ASC OFFSET 0 ROWS) WIP
ON TRIM(WIP.PARTNO) + WIP.CM = TRIM(PL.PartNo) + TRIM(BOM.ACM)
WHERE PL.LREV = '999' AND PL.WCNO != '904' AND PL.APS_PlanDate = FORMAT(DATEADD(HOUR,-8,GETDATE()),'yyyy-MM-dd') AND D.NOTE = '{subline.ToUpper()}'
ORDER BY CAST(PRD_SEQ AS INT) ASC  ";
                DataTable dtApsPlanCasing = dbSCM.Query(strGetApsCasingPlan);
                foreach (DataRow dr in dtApsPlanCasing.Rows)
                {
                    string PartNo = dr["PARTNO"].ToString()!;
                    string Cm = dr["CM"].ToString()!;
                    string Model = dr["MODEL"].ToString()!;
                    ModelGetStockCasingByGroup ItemStockCasing = new ModelGetStockCasingByGroup();
                    ItemStockCasing.PrdSeq = oHelper.ConvStr2Int(dr["PRD_SEQ"].ToString());
                    ItemStockCasing.Model = string.Join(",", ModelOfPart.Where(x => x.Ref2 == PartNo).GroupBy(x => x.Code).Select(x => x.Key).ToList());
                    ItemStockCasing.PartNo = PartNo;
                    ItemStockCasing.Cm = Cm;
                    ItemStockCasing.ModelName = Model;
                    ItemStockCasing.RemainPlan = oHelper.ConvStr2Int(dr["PRD_QTY"].ToString()!);
                    ItemStockCasing.ResultMain = 0;
                    ItemStockCasing.ResultSubline = oHelper.ConvStr2Dec(dr["SUBLINE_RESULT"].ToString()!);
                    ItemStockCasing.Time = "";
                    Dictionary<string, decimal> items = new Dictionary<string, decimal>();
                    foreach (PropSCRPartGroup item in ListHeader)
                    {
                        try
                        {
                            var oRMInfo = dtRMInfo.AsEnumerable().Where(x => x.Field<string>("PARTNO").Contains(PartNo) && x.Field<string>("RM_GROUP").Contains(item.GroupCode)).ToList();
                            decimal WIPOfPlant = oRMInfo.Sum(x => x.Field<decimal>("RM_WIP_PLANT"));
                            decimal WIPOfPS = oRMInfo.Sum(x => x.Field<decimal>("RM_WIP_PS"));
                            items.Add($"{item.GroupCode}-LINE", WIPOfPlant);
                            items.Add($"{item.GroupCode}-PS", WIPOfPS);
                        }
                        catch (Exception e)
                        {
                            items.Add($"{item.GroupCode}-LINE", 0);
                            items.Add($"{item.GroupCode}-PS", 0);
                        }
                    }
                    ItemStockCasing.Data = items;
                    RESStockCasing.Add(ItemStockCasing);
                }
                return Ok(new
                {
                    item = RESStockCasing,
                    header = ListHeader
                });
            }
            catch
            {
                return Ok(new
                {
                    item = ListSCRSubline,
                    header = ListHeader
                });
            }
        }

        [HttpPost]
        [Route("/GetPartSetInByDrawing")]
        public IActionResult GetPartSetInByDrawing([FromBody] ParamGetPartSetInByDrawing param)
        {
            string drawing = param.drawing;
            List<DictMstr> ListPartSetIn = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.Ref1 == "904" && (x.DictType != null && x.DictType.StartsWith("PART_SET_IN")) && x.Ref2 == drawing).ToList();
            return Ok(ListPartSetIn);
        }

        [HttpGet]
        [Route("/GetDrawings")]
        public IActionResult GetDrawings()
        {
            var ListDrawing = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType != null && x.DictType.StartsWith("PART_SET_IN") && x.Code != null).OrderBy(x => x.Ref2).GroupBy(n => new
            {
                drawing = n.Ref2,
                cm = n.Ref3
            }).Select(o => new
            {
                o.Key.drawing,
                o.Key.cm,
            });
            return Ok(ListDrawing);
        }
        [HttpGet]
        [Route("/GetModels")]
        public IActionResult GetModels()
        {
            var models = efSCM.WmsMdw27ModelMasters.Where(x => x.Active == "ACTIVE").OrderBy(x => x.Model).GroupBy(x => new
            {
                model = x.Model,
                sebango = x.Sebango
            }).Select(x => new
            {
                x.Key.model,
                x.Key.sebango
            });
            return Ok(models);
        }

        [HttpPost]
        [Route("/UpdateStatusPartSetIn")]
        public IActionResult UpdateStatusPartSetIn([FromBody] ParamUpdateStatusPartSetIn param)
        {
            int dictId = param.dictId;
            string dictStatus = param.dictStatus;
            string empcode = param.empcode;
            DictMstr oDict = efSCM.DictMstrs.FirstOrDefault(x => x.DictId == dictId)!;
            if (oDict != null)
            {
                oDict.DictStatus = dictStatus;
                oDict.UpdateDate = DateTime.Now;
                oDict.UpdateBy = empcode;
                efSCM.DictMstrs.Update(oDict);
                int update = efSCM.SaveChanges();
                return Ok(new
                {
                    status = update > 0 ? true : false,
                    message = "เกิดข้อผิดพลาด "
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    message = "ไม่พบข้อมูล"
                });
            }
        }

        [HttpPost]
        [Route("/CalApsPlanFromSale")]
        public IActionResult CalApsPlanFromSale()
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtEnd = dtNow.AddMonths(1);
            int year = dtNow.Year;
            int month = dtNow.Month;
            SqlCommand StrGetSales = new SqlCommand();
            StrGetSales.CommandText = $@"SELECT * FROM [dbSCM].[dbo].[AL_SaleForecaseMonth] WHERE ym = '{year.ToString("D2")}{month.ToString("D2")}' and ModelName like 'J%' AND LREV = '999' AND Diameter IN ('SCR2_160-JT16','SCR2_160-JT170') order by Diameter";
            DataTable dtSales = dbSCM.Query(StrGetSales);
            if (dtSales.Rows.Count > 0)
            {
                while (dtNow.Date <= dtEnd.Date)
                {
                    string strDay = dtNow.Day.ToString("D2");
                    decimal TotalOfDay = 0;
                    DataRow[] dtOfDay = dtSales.AsEnumerable().Where(x => x.Field<int>($"D{strDay}") > 0).ToArray();
                    foreach (DataRow drSale in dtOfDay)
                    {
                        if (TotalOfDay + oHelper.ConvStr2Dec(drSale[$"D{strDay}"].ToString()) <= 430)
                        {
                            TotalOfDay += oHelper.ConvStr2Dec(drSale[$"D{strDay}"].ToString());
                        }
                        else
                        {
                            decimal DiffOfDay = 0;
                            dtNow = dtNow.AddDays(1);
                        }
                    }
                }
            }
            return Ok();
        }

        //[HttpGet]
        //[Route("/GetGroupRM/{group}")]
        //public IActionResult GetGroupRM(string group)
        //{
        //    string dictType = $"SORT_RM_{group.ToUpper()}";
        //    List<DictMstr> ItemDict = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.Note != "" && x.Note != null && x.DictType != null && x.DictType.StartsWith(dictType) && x.DictStatus == "ACTIVE").OrderBy(x => x.Note).ToList();
        //    var groups = ItemDict.Select(x => new
        //    {
        //        groupCode = x.RefCode,
        //        groupName = x.Description
        //    });
        //    return Ok(groups);
        //}

        [HttpPost]
        [Route("/GetWipStockByPart")]
        public IActionResult GetWipStockByPart([FromBody] ParamGetWipStockByPart param)
        {
            string part = param.partno;
            string cm = param.cm;
            string wcno = param.wcno;
            string ym = param.ym;
            decimal? stock = 0;
            EkbWipPartStock oStock = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Wcno == wcno && x.Ym == ym && x.Partno == part && x.Cm == cm);
            if (oStock != null)
            {
                stock = oStock.Bal;
            }
            return Ok(stock);
        }

        [HttpPost]
        [Route("/SublineSetting")]
        public IActionResult SublineSettingGetData([FromBody] ParamSublineSetting param)
        {
            List<string> ListModel = new List<string>();
            List<string> ListGroupOfProcess = new List<string>();
            List<string> ListDrawingOfGroup = new List<string>();
            string method = param.method;
            if (method == "init")
            {
                string group = "";
                string process = param.process.ToUpper();
                if (process != "")
                {
                    ListGroupOfProcess = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "SUB_LINE_SORT" && x.Ref4 != null && x.Ref4.ToUpper() == process).OrderBy(x => Convert.ToInt32(x.Note)).GroupBy(x => x.RefCode).Select(x => x.Key).ToList()!;
                    ListDrawingOfGroup = new List<string>();
                    group = param.group;
                    if (group == "" && ListGroupOfProcess.Count > 0)
                    {
                        group = ListGroupOfProcess[0];
                    }
                    if (group != "")
                    {
                        ListDrawingOfGroup = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "WC_MASTER" && x.DictStatus == "ACTIVE" && x.Note == group).OrderBy(x => x.Ref2).GroupBy(x => x.Ref2).Select(x => x.Key).ToList()!;
                    }
                }
                return Ok(new
                {
                    process,
                    group,
                    groups = ListGroupOfProcess,
                    drawing = ListDrawingOfGroup
                });
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        [Route("/SublineSettingAddDrawing")]
        public IActionResult SublineSettingAddDrawing([FromBody] ParamSublineSettingAddDrawing param)
        {
            string ym = DateTime.Now.ToString("yyyyMM");
            string drawing = param.drawing.Trim();
            string cm = param.cm.Trim();
            List<string> models = param.model;
            string line = param.line.Trim();
            string group = param.group.Trim();
            string wcno = param.wcno.Trim();
            string createBy = param.createBy;
            var modelsInfo = efSCM.WmsMdw27ModelMasters.Where(x => x.Active == "ACTIVE").OrderBy(x => x.Model).GroupBy(x => new
            {
                model = x.Model,
                sebango = x.Sebango
            }).Select(x => new
            {
                x.Key.model,
                x.Key.sebango
            });
            foreach (string model in models)
            {
                var modelInfo = modelsInfo.FirstOrDefault(x => x.sebango == model);
                if (modelInfo != null)
                {
                    // ========== PART SET OUT ========//
                    DictMstr oPartSetOut = efSCM.DictMstrs.FirstOrDefault(x => x.DictSystem == "WIP_STOCK" && x.DictType == "PART_SET_OUT" && x.Code == model && x.Ref1 == "904" && x.Ref2 == drawing && x.Ref3 == cm && x.Note == group && x.DictStatus == "ACTIVE");
                    if (oPartSetOut == null)
                    {
                        DictMstr newPartSetOut = new DictMstr()
                        {
                            DictSystem = "WIP_STOCK",
                            DictType = "PART_SET_OUT",
                            Code = model,
                            Description = modelInfo.model,
                            RefCode = modelInfo.model,
                            Ref1 = "904",
                            Ref2 = drawing,
                            Ref3 = cm,
                            Ref4 = "1",
                            Note = group,
                            CreateDate = DateTime.Now,
                            UpdateBy = createBy,
                            UpdateDate = DateTime.Now,
                            DictStatus = "ACTIVE"
                        };
                        efSCM.DictMstrs.Add(newPartSetOut);
                    }

                    // ========== PART SET IN ========//
                    DictMstr oPartSetIn = efSCM.DictMstrs.FirstOrDefault(x => x.DictSystem == "WIP_STOCK" && x.DictType == ("PART_SET_IN_" + line.ToUpper()) && x.Code == model && x.Ref1 == "904" && x.Ref2 == drawing && x.Ref3 == cm && x.Note == group && x.DictStatus == "ACTIVE");
                    if (oPartSetIn == null)
                    {
                        DictMstr newPartSetIn = new DictMstr()
                        {
                            DictSystem = "WIP_STOCK",
                            DictType = ("PART_SET_IN_" + line.ToUpper()),
                            Code = model,
                            Description = modelInfo.model,
                            RefCode = modelInfo.model,
                            Ref1 = "904",
                            Ref2 = drawing,
                            Ref3 = cm,
                            Ref4 = "1",
                            Note = group,
                            CreateDate = DateTime.Now,
                            UpdateBy = createBy,
                            UpdateDate = DateTime.Now,
                            DictStatus = "ACTIVE"
                        };
                        efSCM.DictMstrs.Add(newPartSetIn);
                    }

                    // ========== WC MASTER ========//

                    Dictionary<string, string> GroupInfos = new Dictionary<string, string>
                    {
                        { "BODY" , "BODY" },
                        { "BOTTOM" , "BOTTOM"},
                        { "CB" , "CHAMBER COVER" },
                        { "CS","CRANK SHAFT" },
                        { "FS","FIXED" },
                        { "HS" ,"HOUSING"},
                        { "LW" , "LOWER" },
                        { "OS","ORBITING" },
                        { "ROTOR","ROTOR" },
                        { "STATOR","STATOR" },
                        { "TOP","TOP" }
                    };
                    string groupInfo = GroupInfos.GetValueOrDefault(group.ToUpper());
                    DictMstr oWcMaster = efSCM.DictMstrs.FirstOrDefault(x => x.DictSystem == "WIP_STOCK" && x.DictType == "WC_MASTER" && x.Code == ("904_" + groupInfo) && x.Description == wcno && x.RefCode == "904" && x.Ref1 == groupInfo && x.Ref2 == drawing && x.Ref3 == cm && x.Ref4 == modelInfo.model && x.Note == group.ToUpper() && x.DictStatus == "ACTIVE");
                    if (oWcMaster == null)
                    {
                        DictMstr newWcMaster = new DictMstr()
                        {
                            DictSystem = "WIP_STOCK",
                            DictType = "WC_MASTER",
                            Code = ("904_" + groupInfo),
                            Description = wcno,
                            RefCode = "904",
                            Ref1 = groupInfo,
                            Ref2 = drawing,
                            Ref3 = cm,
                            Ref4 = modelInfo.model,
                            Note = group.ToUpper(),
                            CreateDate = DateTime.Now,
                            UpdateBy = createBy,
                            UpdateDate = DateTime.Now,
                            DictStatus = "ACTIVE"
                        };
                        efSCM.DictMstrs.Add(newWcMaster);
                    }

                    // ========== EKB WIP STOCK ========//

                    EkbWipPartStock oEkbWipMain = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Ym == ym && x.Wcno == "904" && x.Partno == drawing && x.Cm == cm && x.PartDesc == group.ToUpper() && x.Ptype != "MAIN");
                    if (oEkbWipMain == null)
                    {
                        EkbWipPartStock newEkbWipMain = new EkbWipPartStock()
                        {
                            Ym = DateTime.Now.ToString("yyyyMM"),
                            Wcno = "904",
                            Partno = drawing,
                            Cm = cm,
                            Bal = 0,
                            Issqty = 0,
                            Lbal = 0,
                            Recqty = 0,
                            PartDesc = group.ToUpper(),
                            UpdateBy = createBy,
                            UpdateDate = DateTime.Now,
                            Ptype = null
                        };
                        efSCM.EkbWipPartStocks.Add(newEkbWipMain);
                    }

                    EkbWipPartStock oEkbWipSub = efSCM.EkbWipPartStocks.FirstOrDefault(x => x.Ym == ym && x.Wcno == wcno && x.Partno == drawing && x.Cm == cm && x.PartDesc == group.ToUpper());
                    if (oEkbWipSub == null)
                    {
                        EkbWipPartStock newEkbWipSubline = new EkbWipPartStock()
                        {
                            Ym = DateTime.Now.ToString("yyyyMM"),
                            Wcno = wcno,
                            Partno = drawing,
                            Cm = cm,
                            Bal = 0,
                            Issqty = 0,
                            Lbal = 0,
                            Recqty = 0,
                            PartDesc = group.ToUpper(),
                            UpdateBy = createBy,
                            UpdateDate = DateTime.Now,
                            Ptype = null
                        };
                        efSCM.EkbWipPartStocks.Add(newEkbWipSubline);
                    }
                    efSCM.SaveChanges();
                }
            }


            return Ok();
        }

        //[HttpPost]
        //[Route("/ApsGetDashboard")]
        //public IActionResult ApsGetDashboard()
        //{
        //    DateTime dtNow = DateTime.Now;

        //    // ==================== INIT MAIN SEQUECNE ======================//
        //    List<PropMainSequence> mainSequence = new List<PropMainSequence>();
        //    DataTable dtApsProdPlan = oServ.GetAPSProdPlan(dtNow.ToString("yyyyMMdd"));
        //    foreach (DataRow drProdPlan in dtApsProdPlan.Rows)
        //    {
        //        string wcno = drProdPlan["WCON"].ToString();
        //        string seq = drProdPlan["SEQ"].ToString();
        //        string model = drProdPlan["MODEL"].ToString();
        //        string sebango = drProdPlan["SEBANGO"].ToString();
        //        //string processName = "";
        //        //string processGroup = "";
        //        //decimal qty = "";
        //        mainSequence.Add(new PropMainSequence()
        //        {
        //            prdSeq = oProdPlan.PrdSeq,
        //            sebango = oPrd
        //        });
        //    }

        //    return Ok();
        //}


        [HttpPost]
        [Route("/GetSublineInfo")] // Sequence , Wip (RM)
        public IActionResult GetSublineInfo()
        {
            DateTime dtNow = DateTime.Now.AddHours(-8);
            List<DictMstr> RawWcno = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType != null && x.DictType.StartsWith("RM_SORT") && x.DictStatus == "ACTIVE").ToList();
            List<ApsProductionPlan> SubPlans = efSCM.ApsProductionPlans.Where(x => x.ApsPlanDate.HasValue && x.ApsPlanDate.Value == dtNow.Date && x.Lrev == "999").OrderBy(x => Convert.ToInt32(x.PrdSeq)).ToList();
            foreach (ApsProductionPlan oSubPlan in SubPlans)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("/ChargeMainSeq")]
        public IActionResult ChargeMainSeq([FromBody] ParamChargeMainSeq param)
        {
            string fPrdPlanCode = param.fPrdPlanCode;
            string tPrdPlanCode = param.tPrdPlanCode;
            string empcode = param.empcode;
            ApsProductionPlan fInfo = efSCM.ApsProductionPlans.FirstOrDefault(x => x.PrdPlanCode == fPrdPlanCode);
            ApsProductionPlan tInfo = efSCM.ApsProductionPlans.FirstOrDefault(x => x.PrdPlanCode == tPrdPlanCode);
            if (fInfo != null && tInfo != null)
            {
                string? defFromPrdSeq = fInfo.PrdSeq;
                string? defToPrdSeq = tInfo.PrdSeq;
                fInfo.PrdSeq = defToPrdSeq;
                tInfo.PrdSeq = defFromPrdSeq;
                efSCM.ApsProductionPlans.Update(fInfo);
                efSCM.ApsProductionPlans.Update(tInfo);
                int update = efSCM.SaveChanges();
                if (update == 2)
                {
                    SqlCommand sqlInsertLog = new SqlCommand();
                    sqlInsertLog.CommandText = $@"INSERT INTO [dbSCM].[dbo].[DICT_SYSTEM_LOGS] (DICT_SYSTEM,DICT_TYPE,CODE,REF_CODE,REF1,REF2,UPDATE_BY,DICT_STATUS) VALUES ('APS','CHANGE','{fInfo.PrdPlanCode}','{tInfo.PrdPlanCode}','{defFromPrdSeq}','{defToPrdSeq}','{empcode}','ACTIVE')";
                    dbSCM.Query(sqlInsertLog);
                    return Ok(new
                    {
                        status = true,
                        message = ""
                    });
                }
                else
                {
                    fInfo.PrdSeq = defFromPrdSeq;
                    tInfo.PrdSeq = defToPrdSeq;
                    efSCM.ApsProductionPlans.Update(fInfo);
                    efSCM.ApsProductionPlans.Update(tInfo);
                    efSCM.SaveChanges();
                    return Ok(new
                    {
                        status = false,
                        message = "เกิดข้อผิดพลาดระหว่างการบันทึกข้อมูล ติดต่อ 250 เบียร์"
                    });
                }

            }
            else
            {
                return Ok(new
                {
                    status = false,
                    message = $"ไม่พบข้อมูลแผนการผลิต "
                });
            }
        }


        [HttpPost]
        [Route("/GetRMDetail")]
        public IActionResult GetRMDetail([FromBody] ParamGetRMDetail param)
        {
            string rm = "";
            string rm_cm = "";
            string partno = param.partno;
            string cm = param.cm;
            string rm_group = param.rm_group;
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT * FROM [dbSCM].[dbo].[DictMstr]  WHERE DICT_SYSTEM = 'WIP_STOCK' AND DICT_TYPE LIKE 'RM_%' AND DESCRIPTION = '{partno}' AND NOTE = '{rm_group}'";
            DataTable dt = dbSCM.Query(sql);

            foreach (DataRow dr in dt.Rows)
            {
                rm = dr["REF2"].ToString();
                rm_cm = dr["REF3"].ToString();

            }
            return Ok(new { rm, rm_cm });
        }
    }
}
