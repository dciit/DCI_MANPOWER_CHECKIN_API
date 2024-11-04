using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlScrapRequest
    {
        public string ReqSource { get; set; } = null!;
        public string ReqYmd { get; set; } = null!;
        public string ReqSht { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Itemno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string ReqYm { get; set; } = null!;
        public string Dtype { get; set; } = null!;
        public decimal? ReqQty { get; set; }
        public decimal? ConfirmQty { get; set; }
        public decimal? StdCost { get; set; }
        public string? Remark { get; set; }
        public string? Refno { get; set; }
        public string Docno { get; set; } = null!;
        public string? Reason { get; set; }
        public string? Bgdept { get; set; }
        public string? Bgno { get; set; }
        public string? Datatype { get; set; }
        public string? Status { get; set; }
        public string? Cby { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Uby { get; set; }
        public DateTime? Udate { get; set; }
        public string? PdMg { get; set; }
        public DateTime? PdMgDate { get; set; }
        public string? PdGm { get; set; }
        public DateTime? PdGmDate { get; set; }
        public string? QcMg { get; set; }
        public DateTime? QcMgDate { get; set; }
        public string? QcGm { get; set; }
        public DateTime? QcGmDate { get; set; }
        public string? ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string? Ac { get; set; }
        public DateTime? AcDate { get; set; }
        public string? Alphaby { get; set; }
        public DateTime? Alphadate { get; set; }
        public string? QcsamplingWc { get; set; }
    }
}
