using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoLogDev
    {
        public long LogId { get; set; }
        public string DoRunning { get; set; } = null!;
        public int DoRev { get; set; }
        public string LogPartNo { get; set; } = null!;
        public string LogVdCode { get; set; } = null!;
        public int LogProdLead { get; set; }
        public string LogType { get; set; } = null!;
        /// <summary>
        /// ข้อมูลของวันที่ PLAN, DO ที่คำนวนได้
        /// </summary>
        public string LogFromDate { get; set; } = null!;
        public double LogFromPlan { get; set; }
        /// <summary>
        /// stock
        /// </summary>
        public double LogFromStock { get; set; }
        /// <summary>
        /// วันที่ LOG_F_DATE - PROD LEAD TIME [D]
        /// </summary>
        public string LogNextDate { get; set; } = null!;
        public double LogNextStock { get; set; }
        /// <summary>
        /// วันที่ LOG_F_DATE - PROD LEAD TIME [D]
        /// </summary>
        public string LogToDate { get; set; } = null!;
        public double LogDo { get; set; }
        public double LogBox { get; set; }
        /// <summary>
        /// used,notused
        /// </summary>
        public string LogState { get; set; } = null!;
        public string LogRemark { get; set; } = null!;
        public DateTime LogCreateDate { get; set; }
        public DateTime LogUpdateDate { get; set; }
        public string LogUpdateBy { get; set; } = null!;
    }
}
