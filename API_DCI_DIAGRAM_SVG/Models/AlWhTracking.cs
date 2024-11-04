using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWhTracking
    {
        public string Ymd { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Serial { get; set; } = null!;
        public string? Plno { get; set; }
        public string? Pltype { get; set; }
        public string Type { get; set; } = null!;
        public string Subtype { get; set; } = null!;
        public string Fromwc { get; set; } = null!;
        public string Towc { get; set; } = null!;
        public string? Refno1 { get; set; }
        public string? Refno2 { get; set; }
        public string? Refno3 { get; set; }
        public string? Refno4 { get; set; }
        public string? Refno5 { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
