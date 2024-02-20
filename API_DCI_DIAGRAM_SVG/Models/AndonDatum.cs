using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AndonDatum
    {
        public string BoardId { get; set; } = null!;
        public string? BoardName { get; set; }
        public DateTime? Pddate { get; set; }
        public string? Pdshift { get; set; }
        public string ModelCode { get; set; } = null!;
        public string? ModelName { get; set; }
        public int? Target { get; set; }
        public int? Plan { get; set; }
        public int? Actual { get; set; }
        public int? Diff { get; set; }
        public int? Order { get; set; }
        public int? CycleTime { get; set; }
        public DateTime? StartRun { get; set; }
        public DateTime? EndRun { get; set; }
        public int? ModelChangeTime { get; set; }
        public DateTime? ModelChangeStartTime { get; set; }
        public DateTime? ModelChangeEndTime { get; set; }
        public string? Status { get; set; }
        public int? Enable { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
