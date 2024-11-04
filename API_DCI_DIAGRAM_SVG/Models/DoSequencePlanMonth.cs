using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoSequencePlanMonth
    {
        public string Id { get; set; } = null!;
        public string? Model { get; set; }
        public string? Code { get; set; }
        public string? SeqDate { get; set; }
        public string? PlanPd { get; set; }
        public string? PlanRevision { get; set; }
        public string? CreateBy { get; set; }
        public string? CreateDate { get; set; }
    }
}
