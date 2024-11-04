using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsReworkDetail
    {
        public string NbrRework { get; set; } = null!;
        public string PipeNo { get; set; } = null!;
        public string? ReworkCode { get; set; }
        public string ProblemCode { get; set; } = null!;
        public string? ProblemPoint { get; set; }
        public string? ProblemSide { get; set; }
        public string? ProblemMc { get; set; }
    }
}
