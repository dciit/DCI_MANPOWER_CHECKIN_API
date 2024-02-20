using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DataLog
    {
        public DateTime LogTime { get; set; }
        public string BoardId { get; set; } = null!;
        public int? DailyPlan { get; set; }
        public int? Plan { get; set; }
        public int? Actual { get; set; }
        public int? Diff { get; set; }
        public string? Shift { get; set; }
        public string? Status { get; set; }
        public decimal? BreakDown { get; set; }

    }
}
