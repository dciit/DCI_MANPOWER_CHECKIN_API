using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public class ApsServices
    {
        private SqlConnectDB oSCM = new SqlConnectDB("dbSCM");
        public List<PropDrawings> GetDrawings(string ymd = "")
        {
            try
            {
                if (ymd == "")
                {
                    ymd = DateTime.Now.ToString("yyyyMMdd");
                }
                List<PropDrawings> items = new List<PropDrawings>();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = $@" SELECT [PWCNO] AS WCNO,[APARTNO] AS PARTNO, ACM AS CM FROM [dbSCM].[dbo].[AL_PD_Formula]   WHERE [STRYMN] <= '{ymd}' AND [ENDYMN] >= '{ymd}' and PWCNO NOT LIKE '90%' AND SUBSTRING(APARTNO,1,1) != 'J' 
  AND SUBSTRING(APARTNO,1,2) NOT IN('1Y','2Y')
UNION ALL
    SELECT [PWCNO],[PPARTNO], PCM
    FROM [dbSCM].[dbo].[AL_PD_Formula_Multi]
  WHERE [STRYMD] <= '{ymd}' AND [ENDYMD] >= '{ymd}'  and PWCNO NOT LIKE '90%' AND SUBSTRING(PPARTNO,1,1) != 'J'
  AND  SUBSTRING(PPARTNO,1,2) NOT IN('1Y','2Y') GROUP BY PWCNO, PPARTNO, PCM";
                DataTable dt = oSCM.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    PropDrawings item = new PropDrawings();
                    item.wcno = dr["WCNO"].ToString();
                    item.drawing = dr["PARTNO"].ToString();
                    item.cm = dr["CM"].ToString();
                    items.Add(item);
                }
                return items;
            }
            catch
            {
                return new List<PropDrawings>();
            }

        }
    }
}