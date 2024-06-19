using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class ApsController : Controller
    {
        private readonly DBSCM efSCM;
        private readonly SqlConnectDB dbSCM = new SqlConnectDB("dbSCM");

        public ApsController(DBSCM efSCM)
        {
            this.efSCM = efSCM;
        }

        [HttpGet]
        [Route("/aps/data/maininout")]
        public IActionResult ApsData()
        {
            List<ViApsPartMaster> rApsPartMaster = efSCM.ViApsPartMasters.Where(x => x.Model != null && x.Wcno == "904").OrderBy(x => x.Model).ToList();
            return Ok(rApsPartMaster);
        }

        [HttpGet]
        [Route("/ApsMainGetData")]
        public IActionResult ApsMainGetData()
        {
            DateTime dtNow = DateTime.Now;
            List<ApsSchema> rApsSchema = new List<ApsSchema>
                 {
                     new ApsSchema() { factory = "1", line = "ASSEMBLY LINE1 (1YC) Line 1", wcno = "904" },
                     new ApsSchema() { factory = "1", line = "FINAL-ASSEMBLY LINE1 (1YC) Line 1", wcno = "904" }
                 };
            List<List<string>> rResult = new List<List<string>>();
            // SET START TIME
            List<string> rStartTime = new List<string>();
            foreach (ApsSchema oScheman in rApsSchema)
            {
                rStartTime.Add("08:20");
            }
            rResult.Add(rStartTime);

            // SET PLAN TODAY
            string dd = dtNow.ToString("dd");
            List<string> rPlan = new List<string>();
            foreach (ApsSchema oScheman in rApsSchema)
            {
                string DailyQty = "";

                Random rnd = new Random();
                string pid = rnd.Next().ToString();

                //CREATE TEMP DAILY DATA
                SqlCommand sqlStore = new SqlCommand();
                sqlStore.CommandText = "sp_APS_WK_DailyPlan";
                sqlStore.CommandType = CommandType.StoredProcedure;
                sqlStore.Parameters.Add(new SqlParameter("@pPID", pid));
                sqlStore.Parameters.Add(new SqlParameter("@pWCNO", oScheman.wcno));
                sqlStore.Parameters.Add(new SqlParameter("@pLINENAME", oScheman.line));
                sqlStore.CommandTimeout = 180;
                dbSCM.ExecuteCommand(sqlStore);



                SqlCommand sqlSelectDaily = new SqlCommand();
                sqlSelectDaily.CommandText = @"SELECT *
                                 FROM vi_WK_APS_PlanDailyReport 
                                 WHERE WCNO = @WCNO AND LineName = @LINE
            AND YM = @YM
             AND PID = @PID";
                sqlSelectDaily.Parameters.Add(new SqlParameter("@WCNO", oScheman.wcno));
                sqlSelectDaily.Parameters.Add(new SqlParameter("@LINE", oScheman.line));
                sqlSelectDaily.Parameters.Add(new SqlParameter("@YM", dtNow.ToString("yyyyMM")));
                sqlSelectDaily.Parameters.Add(new SqlParameter("@PID", pid));
                DataTable dtDaily = dbSCM.Query(sqlSelectDaily);
                if (dtDaily.Rows.Count > 0)
                {
                    //DailyQty = dtDaily.Rows[0]["PlanQty"].ToString();
                }
                // DEL TEMP 
                SqlCommand sqlDelTempApsReport = new SqlCommand();
                sqlDelTempApsReport.CommandText = @"DELETE  FROM vi_WK_APS_PlanDailyReport 
                                 WHERE  PID = @PID";
                sqlDelTempApsReport.Parameters.Add(new SqlParameter("@PID", pid));
                dbSCM.Query(sqlDelTempApsReport);
                rPlan.Add(DailyQty);
            }
            rResult.Add(rPlan);
            return Ok();
        }
    }
}
