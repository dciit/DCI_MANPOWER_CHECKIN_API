using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsLogResultPlanReportDev
    {
        public string Batchdate { get; set; } = null!;
        public string Plancode { get; set; } = null!;
        public string Mainresource { get; set; } = null!;
        public string Maincode { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public decimal? Planqty { get; set; }
        public DateTime? Prdstartdt { get; set; }
        public DateTime? Prdenddt { get; set; }
        public string? Source { get; set; }
        public DateTime Resultdate { get; set; }
        public string Resultwcno { get; set; } = null!;
        public decimal? Resultqty { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
