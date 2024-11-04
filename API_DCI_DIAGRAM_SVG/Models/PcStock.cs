using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PcStock
    {
        public string Ymd { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public decimal? Qty { get; set; }
        public string? Whunit { get; set; }
        public string? Location { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
