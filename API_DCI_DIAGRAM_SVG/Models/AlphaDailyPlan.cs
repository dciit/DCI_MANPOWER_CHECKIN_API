using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlphaDailyPlan
    {
        public string Wc { get; set; } = null!;
        public string ModelCode { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime PlanDate { get; set; }
        public int? PlanQty { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
