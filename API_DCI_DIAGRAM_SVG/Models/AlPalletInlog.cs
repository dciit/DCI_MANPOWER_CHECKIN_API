using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletInlog
    {
        public string Astdate { get; set; } = null!;
        public string Asttime { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Plno { get; set; } = null!;
        public string? Pltype { get; set; }
        public string? Prdtype { get; set; }
        public string? Plrack { get; set; }
    }
}
