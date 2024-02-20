using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class BoardDatum
    {
        public string BoardId { get; set; } = null!;
        public string? PdName { get; set; }
        public int? Actual { get; set; }
        public int? CurPlan { get; set; }
        public int? CurDlPlan { get; set; }
        public string? CurStatus { get; set; }
        public int? ActiveTime { get; set; }
        public int? LogTime { get; set; }
        public DateTime? LastActive { get; set; }
        public DateTime? LastLog { get; set; }
        public string? ReadPlan { get; set; }
        public int? CycleTime { get; set; }
        public string? ServiceRequest { get; set; }
        public DateTime? RequestStart { get; set; }
        public DateTime? ServiceStart { get; set; }
        public DateTime? ServiceEnd { get; set; }
        public string? MachineNo { get; set; }
        public string? RequestType { get; set; }
        public string? Shift { get; set; }
        public bool? Enable { get; set; }
        public DateTime? LastCycleTime { get; set; }
        public string? IpAddress { get; set; }
        public string? Tempature { get; set; }
        public string? PdModel { get; set; }
        public int? TotalNg { get; set; }
        public decimal? CycleTimeDecimal { get; set; }
    }
}
