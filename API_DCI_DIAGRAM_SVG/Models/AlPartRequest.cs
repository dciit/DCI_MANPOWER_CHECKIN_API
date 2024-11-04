using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartRequest
    {
        public string ReqYmd { get; set; } = null!;
        public string ReqShift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string ReqTime { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public decimal? ReqQty { get; set; }
        public decimal? IssQty { get; set; }
        public string? Slipno { get; set; }
        public string ReqStatus { get; set; } = null!;
        public string RefNo { get; set; } = null!;
        public string? Cby { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Uby { get; set; }
        public DateTime? Udate { get; set; }
    }
}
