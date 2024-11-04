using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlphaPicklistPart
    {
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Wh { get; set; }
    }
}
