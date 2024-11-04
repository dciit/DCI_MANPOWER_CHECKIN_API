using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasLineProcess
    {
        public string LineSamplingNbr { get; set; } = null!;
        public string LineMain { get; set; } = null!;
        public string LineSub { get; set; } = null!;
        public string LineMachine { get; set; } = null!;
        public string? LineStd { get; set; }
        public decimal? LineAct { get; set; }
        public DateTime? LineUpdatedate { get; set; }
        public string? LineUpddateby { get; set; }
    }
}
