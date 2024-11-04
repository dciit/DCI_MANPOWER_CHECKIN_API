using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsReworkLog
    {
        public string NbrRework { get; set; } = null!;
        public string PipeNo { get; set; } = null!;
        public string ReworkCode { get; set; } = null!;
        public string ReworkType { get; set; } = null!;
        public string? LogBy { get; set; }
        public DateTime LogTime { get; set; }
        public string? Remark { get; set; }
        public string? ReworkLine { get; set; }
    }
}
