using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsProductionPlanNotify
    {
        public string Wcno { get; set; } = null!;
        public string LineType { get; set; } = null!;
        public DateTime ChangeDt { get; set; }
        public string SubLine { get; set; } = null!;
        public DateTime? NotifyDt { get; set; }
        public string? NotifyBy { get; set; }
        public string? AckStatus { get; set; }
        public string? AckBy { get; set; }
        public DateTime? AckDt { get; set; }
    }
}
