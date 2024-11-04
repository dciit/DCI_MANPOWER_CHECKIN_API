using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartStockPlanLog
    {
        public string Nbr { get; set; } = null!;
        public string? Ymd { get; set; }
        public string? Shift { get; set; }
        public string? Wcno { get; set; }
        public string? Partno { get; set; }
        public string? Cm { get; set; }
        public decimal? PlanQty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? Remark { get; set; }
    }
}
