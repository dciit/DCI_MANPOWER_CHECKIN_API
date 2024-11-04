using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasLineProcessMaster
    {
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Drawning { get; set; }
        public string MainProcess { get; set; } = null!;
        public string SubProcess { get; set; } = null!;
        public string? Std { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }
}
