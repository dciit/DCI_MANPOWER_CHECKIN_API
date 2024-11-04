using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletDooutLog
    {
        public string Dono { get; set; } = null!;
        public string Ivno { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Ymd { get; set; }
    }
}
