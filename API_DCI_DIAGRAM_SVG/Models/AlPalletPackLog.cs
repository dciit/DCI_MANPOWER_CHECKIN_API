using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletPackLog
    {
        public string PackDt { get; set; } = null!;
        public string Plno { get; set; } = null!;
        public string? Plrack { get; set; }
        public string? Pltype { get; set; }
        public string? Model { get; set; }
        public string? Nwc { get; set; }
    }
}
