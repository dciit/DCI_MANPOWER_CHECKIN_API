using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VdDoCycle
    {
        public string VdAddr { get; set; } = null!;
        public string DoDay { get; set; } = null!;
        public int DoSequence { get; set; }
        public string DoTime { get; set; } = null!;
        public DateTime? UpdateDt { get; set; }
        public string? UpdateBy { get; set; }
    }
}
