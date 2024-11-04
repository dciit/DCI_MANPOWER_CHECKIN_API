using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlScrapReport
    {
        public string ScpSource { get; set; } = null!;
        public string ScpYmd { get; set; } = null!;
        public string ScpSht { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Itemno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string ScpYm { get; set; } = null!;
        public string Dtype { get; set; } = null!;
        public decimal? Qty { get; set; }
        public decimal? StdCost { get; set; }
        public string? Remark { get; set; }
        public string Refno { get; set; } = null!;
        public string Docno { get; set; } = null!;
        public string Lrev { get; set; } = null!;
        public string? Reason { get; set; }
        public string? Bgdept { get; set; }
        public string? Bgno { get; set; }
        public string Datatype { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? Cdate { get; set; }
        public string? Cby { get; set; }
        public DateTime? Udate { get; set; }
        public string? Uby { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
