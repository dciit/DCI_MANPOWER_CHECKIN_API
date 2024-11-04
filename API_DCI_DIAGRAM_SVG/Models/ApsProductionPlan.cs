using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsProductionPlan
    {
        public string PrdPlanCode { get; set; } = null!;
        public string? Wcno { get; set; }
        public string? Subline { get; set; }
        public string? ApsCurrent { get; set; }
        public string? ApsSeq { get; set; }
        public DateTime? ApsPlanDate { get; set; }
        public string? ApsDistribute { get; set; }
        public string? PrdSeq { get; set; }
        public string? PartNo { get; set; }
        public string? Cm { get; set; }
        public int ApsPlanQty { get; set; }
        public int PrdPlanQty { get; set; }
        public string Rev { get; set; } = null!;
        public string Lrev { get; set; } = null!;
        public string? CreBy { get; set; }
        public DateTime? CreDt { get; set; }
        public string? UpdBy { get; set; }
        public DateTime? UpdDt { get; set; }
    }
}
