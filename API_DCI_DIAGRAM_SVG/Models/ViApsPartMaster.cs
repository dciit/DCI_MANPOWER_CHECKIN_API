using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViApsPartMaster
    {
        public string? Model { get; set; }
        public string PartNameCode { get; set; } = null!;
        public string PartCode { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
    }
}
