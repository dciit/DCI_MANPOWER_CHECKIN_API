using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlScrapQcmstr
    {
        public string MstCode { get; set; } = null!;
        public string? MstSetName { get; set; }
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? MstModel { get; set; }
        public string? PartDesc { get; set; }
        public decimal? Qty { get; set; }
        public string? MstStatus { get; set; }
        public string? Cby { get; set; }
        public DateTime? Cdate { get; set; }
        public string? QcsamplingWc { get; set; }
    }
}
