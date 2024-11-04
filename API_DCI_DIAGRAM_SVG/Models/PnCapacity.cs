using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnCapacity
    {
        public string ProductionLine { get; set; } = null!;
        public int? CapacityMax { get; set; }
        public decimal? CapacityPercent { get; set; }
        public int? Capacity { get; set; }
        public string? CapacityPer { get; set; }
        public string? Status { get; set; }
        public string? LineName { get; set; }
    }
}
