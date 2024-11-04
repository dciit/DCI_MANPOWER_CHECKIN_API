using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhPlCheck
    {
        public DateTime BookDate { get; set; }
        public string Model { get; set; } = null!;
        public string Plno { get; set; } = null!;
        public string? Pltype { get; set; }
        public string? Nwc { get; set; }
        public string? Prdtype { get; set; }
    }
}
