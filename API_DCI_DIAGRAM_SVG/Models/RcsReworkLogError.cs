using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsReworkLogError
    {
        public string PipeNo { get; set; } = null!;
        public string ReworkType { get; set; } = null!;
        public string? LogBy { get; set; }
        public DateTime LogTime { get; set; }
    }
}
