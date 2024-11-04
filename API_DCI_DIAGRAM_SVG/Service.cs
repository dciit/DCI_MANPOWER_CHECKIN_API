using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;
using API_DCI_DIAGRAM_SVG.Props;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace API_DCI_DIAGRAM_SVG
{
    public class Service
    {
        private readonly SqlConnectDB dbSCM = new SqlConnectDB("dbSCM");
        private readonly DBDCI _contextDCI;
        private readonly HRMContext _contxHRM;
        private readonly DBSCM efSCM;
        public ClsHelper oHelper = new ClsHelper();
        public Service(DBDCI contextDCI, DBSCM contextSCM, HRMContext contxHRM)
        {
            _contextDCI = contextDCI;
            efSCM = contextSCM;
            _contxHRM = contxHRM;
        }

        public Service()
        {
        }

        public MModels.MManSkill getCounter(string objCode)
        {
            int CounterManSkill = 0;
            List<Employee> ListEmpCodeOfSkill = new List<Employee>();
            List<MpckDictionary> oMQs = efSCM.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "MQ").ToList();
            int MQLength = oMQs.Count;
            List<string> MQGroupMQNo = oMQs.Select(x => x.DictCode).Distinct().ToList();
            List<ViTrTrainessLog> AAA = _contextDCI.ViTrTrainessLogs.Where(x => MQGroupMQNo.Contains(x.MqNo) && x.Status == "post" && x.Result == "P").Select(x => new ViTrTrainessLog
            {
                EmpCode = x.EmpCode,
                MqNo = x.MqNo
            }).ToList().GroupBy(x => x.EmpCode).Select(y => new ViTrTrainessLog { EmpCode = y.Key, Score = y.GroupBy(x => x.MqNo).Count() }).Where(z => z.Score == MQLength).ToList();

            List<MpckDictionary> oSAs = efSCM.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            if (oSAs != null)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var BBB = efSCM.SkcLicenseTrainings
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                if (AAA.Count > 0 && BBB.Count > 0)
                {
                    var B = AAA.Select(x => x.EmpCode).Intersect(BBB).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => B.Contains(x.Code)).ToList();
                    CounterManSkill = B.Count();
                }
                else if (AAA.Count > 0 && BBB.Count == 0)
                {
                    var A = AAA.Select(x => x.EmpCode).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                    CounterManSkill = A.Count();
                }
                else if (AAA.Count == 0 && BBB.Count > 0)
                {
                    var A = BBB.Select(x => x).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                    CounterManSkill = A.Count();
                }
                else
                {
                    CounterManSkill = 0;
                }

            }
            if (oMQs.Count == 0 && oSAs.Count == 0)
            {
                CounterManSkill = 0;
            }
            return new MModels.MManSkill
            {
                counter = CounterManSkill.ToString("D2"),
                employees = ListEmpCodeOfSkill
            };
        }


        public MModels.MManSkill GetEmployeeListInMQSA(string objCode)
        {
            int CounterManSkill = 0;
            List<Employee> ListEmpCodeOfSkill = new List<Employee>();
            List<MpckDictionary> oMQs = efSCM.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "MQ").ToList();
            int MQLength = oMQs.Count;
            List<string> MQGroupMQNo = oMQs.Select(x => x.DictCode).Distinct().ToList();
            List<ViTrTrainessLog> oEmpMQs = _contextDCI.ViTrTrainessLogs.Where(x => MQGroupMQNo.Contains(x.MqNo) && x.Status == "post" && x.Result == "P").Select(x => new ViTrTrainessLog
            {
                EmpCode = x.EmpCode,
                MqNo = x.MqNo
            }).ToList().GroupBy(x => x.EmpCode).Select(y => new ViTrTrainessLog { EmpCode = y.Key, Score = y.GroupBy(x => x.MqNo).Count() }).Where(z => z.Score == MQLength).ToList();

            List<MpckDictionary> oSAs = efSCM.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            oSAs = (from a in oSAs
                    join b in efSCM.SkcDictMstrs.Where(x => x.DictStatus == true)
                    on a.DictCode equals b.Code
                    where b.DictStatus == true
                    select a
                    ).ToList();

            if (oMQs.Count > 0 && oSAs.Count > 0)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var oEmpSAs = efSCM.SkcLicenseTrainings
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                var IntersectEmp = oEmpMQs.Select(x => x.EmpCode).Intersect(oEmpSAs).Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
                CounterManSkill = IntersectEmp.Count();
            }
            else if (oMQs.Count > 0 && oSAs.Count == 0)
            {
                var oGroupEmpMQ = oEmpMQs.Select(x => x.EmpCode).Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => oGroupEmpMQ.Contains(x.Code)).ToList();
                CounterManSkill = oGroupEmpMQ.Count();
            }
            else if (oSAs.Count > 0 && oMQs.Count == 0)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var oEmpSAs = efSCM.SkcLicenseTrainings
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                var IntersectEmp = oEmpSAs.Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
                CounterManSkill = IntersectEmp.Count();
            }
            else
            {

            }


            //if (oSAs.Count == 0)
            //{
            //    var A = oEmpMQs.Select(x => x.EmpCode).Distinct().ToList();
            //    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
            //    CounterManSkill = A.Count();
            //}
            //else
            //{
            //    int SALength = oSAs.Count;
            //    List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
            //    var oEmpSAs = efSCM.SkcLicenseTraining
            //    .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
            //    {
            //        DictCode = x.DictCode,
            //        Empcode = x.Empcode
            //    }).ToList().GroupBy(x => x.Empcode).Select(y => new
            //    {
            //        Empcode = y.Key,
            //        Count = y.GroupBy(x => x.DictCode).Count()
            //    }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();

            //    if (oMQs.Count > 0 && oSAs.Count > 0)
            //    {
            //        var IntersectEmp = oEmpMQs.Select(x => x.EmpCode).Intersect(oEmpSAs).Distinct().ToList();
            //        ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
            //        CounterManSkill = IntersectEmp.Count();
            //    }

            //}

            return new MModels.MManSkill
            {
                counter = CounterManSkill.ToString("D2"),
                employees = ListEmpCodeOfSkill
            };
        }


        public List<MpckDictionary> getMQofObj(string objCode)
        {

            List<MpckDictionary> list = new List<MpckDictionary>();
            list = efSCM.MpckDictionaries.Where(x => x.DictRefCode == objCode && x.DictType == "MQ").ToList();
            return list;
        }


        public List<SkcDictMstr> getSAofObj(string objCode)
        {
            List<SkcDictMstr> list = new List<SkcDictMstr>();
            List<MpckDictionary> oSAs = efSCM.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            if (oSAs.Count > 0)
            {
                List<SkcDictMstr> oSAALLs = efSCM.SkcDictMstrs.Where(d => d.Code == d.RefCode && d.DictStatus == true && d.DictType == "LICENSE").ToList();
                list = (from sa in oSAs.OrderBy(b => b.DictCode)
                        join saall in oSAALLs
                        on sa.DictCode equals saall.Code
                        select new SkcDictMstr()
                        {
                            Code = sa.DictCode,
                            DictDesc = saall.DictDesc
                        }).ToList();
            }

            return list;
        }

        public List<PartGroupMaster> GetPartMaster()
        {
            List<PartGroupMaster> rPartGroup = new List<PartGroupMaster>();
            SqlCommand sql = new SqlCommand();
            List<DictMstr> rModelStandard = efSCM.DictMstrs.Where(x => x.DictSystem == "WIP_STOCK" && x.DictType == "MODEL_STANDARD").ToList();
            sql.CommandText = $@"SELECT A.[DESCRIPTION] AS WCNO,A.REF2 AS PARTNO,A.REF3 AS CM ,A.REF4 AS MODEL_COMMON,A.NOTE AS PART_GROUP ,B.DESCRIPTION AS PART_GROUP_NAME
FROM [dbSCM].[dbo].[DictMstr]  A
LEFT JOIN [dbSCM].[dbo].[DictMstr] B
ON B.CODE = A.NOTE 
WHERE  A.DICT_type = 'WC_MASTER' AND A.NOTE != ''  AND A.REF4 != ''  
and B.DICT_SYSTEM = 'WIP_STOCK' AND B.DICT_TYPE = 'PART_GROUP_MASTER'
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
            return rPartGroup;
        }

        public DataTable GetAPSProdPlan(string ymd)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT PL.[WCNO] ,PL.[PRD_SEQ] SEQ
      ,REPLACE(TRIM(PL.[PartNo]),'-10','') MODEL
	  ,ML.SEBANGO 
      ,PL.[APS_PlanQty] PLAN_QTY
  FROM [dbSCM].[dbo].[APS_ProductionPlan] PL 
  LEFT JOIN (SELECT SEBANGO,MODEL FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] GROUP BY SEBANGO,MODEL) ML
  ON ML.MODEL =  REPLACE(TRIM(PL.[PartNo]),'-10','')
  WHERE PL.APS_PlanDate = '{ymd}' AND PL.LREV = 999 AND PL.SUBLINE = 'ASSEMBLY LINE4 (SCR)'  ORDER BY CAST(PL.PRD_SEQ AS INT) ASC";
            DataTable dt = dbSCM.Query(sql);
            return dt;
        }

        public List<PropWIP> GetWIPSublines()
        {
            List<PropWIP> res = new List<PropWIP>();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT X.DESCRIPTION MODEL,M.SEBANGO ,X.[REF2] PART ,X.[REF3],Y.NOTE ,ISNULL(Z.BAL,0) BAL,Y.DESCRIPTION SUB_WCNO  
FROM [dbSCM].[dbo].[DictMstr] X 
LEFT JOIN (SELECT SEBANGO,MODEL FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] GROUP BY SEBANGO,MODEL) M
ON M.MODEL = X.DESCRIPTION
LEFT JOIN [dbSCM].[dbo].[DictMstr] Y
ON Y.DICT_TYPE = 'WC_MASTER' AND Y.REF2 = X.REF2
LEFT JOIN [dbSCM].[dbo].[EKB_WIP_PART_STOCK] Z
ON Z.YM = FORMAT(GETDATE(),'yyyyMM') AND Z.WCNO NOT LIKE '90%' 
AND Z.WCNO NOT LIKE '80%' 
AND Z.PARTNO = X.REF2  
AND Z.CM = X.REF3 
AND Z.WCNO = Y.DESCRIPTION
WHERE 1=1
  AND X.DICT_SYSTEM = 'WIP_STOCK'
  AND X.DICT_TYPE = 'PART_SET_OUT' 
  AND X.DICT_STATUS = 'ACTIVE'
  AND Y.NOTE IS NOT NULL
  AND Y.REF_CODE = '904'
  AND Y.NOTE != 'OS' ";
            DataTable dt = dbSCM.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                res.Add(new PropWIP()
                {
                    sebango = dr["SEBANGO"].ToString(),
                    model = dr["MODEL"].ToString(),
                    part = dr["PART"].ToString(),
                    cm = dr["REF3"].ToString(),
                    subline = dr["NOTE"].ToString(),
                    bal = oHelper.ConvStr2Dec(dr["BAL"].ToString())
                });
            }
            return res;
        }

        public List<PropWIP> GetWIPMains()
        {
            List<PropWIP> res = new List<PropWIP>();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = $@"SELECT X.DESCRIPTION MODEL, M.SEBANGO ,X.[REF2] PART ,X.[REF3],Y.NOTE ,ISNULL(Z.BAL, 0) BAL,Y.DESCRIPTION SUB_WCNO
FROM[dbSCM].[dbo].[DictMstr] X
LEFT JOIN(SELECT SEBANGO, MODEL FROM[dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] GROUP BY SEBANGO, MODEL) M
ON M.MODEL = X.DESCRIPTION
LEFT JOIN[dbSCM].[dbo].[DictMstr] Y
ON Y.DICT_TYPE = 'WC_MASTER' AND Y.REF2 = X.REF2
LEFT JOIN[dbSCM].[dbo].[EKB_WIP_PART_STOCK] Z
ON Z.YM = FORMAT(GETDATE(), 'yyyyMM') AND Z.WCNO LIKE '90%'
AND Z.PARTNO = X.REF2
AND Z.CM = X.REF3
AND Z.WCNO = '904'
WHERE 1 = 1
  AND X.DICT_SYSTEM = 'WIP_STOCK'
  AND X.DICT_TYPE = 'PART_SET_OUT'
  AND X.DICT_STATUS = 'ACTIVE'
  AND Y.NOTE IS NOT NULL
  AND Y.NOTE != 'OS'";
            DataTable dt = dbSCM.Query(sql);
            foreach (DataRow dr in dt.Rows)
            {
                res.Add(new PropWIP()
                {
                    sebango = dr["SEBANGO"].ToString(),
                    model = dr["MODEL"].ToString(),
                    part = dr["PART"].ToString(),
                    cm = dr["REF3"].ToString(),
                    subline = dr["NOTE"].ToString(),
                    bal = oHelper.ConvStr2Dec(dr["BAL"].ToString())
                });
            }
            return res;
        }
    }
}
