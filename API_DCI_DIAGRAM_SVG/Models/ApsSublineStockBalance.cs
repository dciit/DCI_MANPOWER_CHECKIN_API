using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsSublineStockBalance
    {
        public string Ym { get; set; } = null!;
        public string Ymd { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Hhmm { get; set; } = null!;
        public string ApsSeq { get; set; } = null!;
        public string Modelcode { get; set; } = null!;
        public string Modelname { get; set; } = null!;
        public string? ApsCurrent { get; set; }
        public decimal? ApsPlan { get; set; }
        public decimal? ApsResult { get; set; }
        public decimal? ApsRemainPlan { get; set; }
        public decimal? FsMain { get; set; }
        public decimal? FsSubline { get; set; }
        public decimal? HsMain { get; set; }
        public decimal? HsSubline { get; set; }
        public decimal? LwMain { get; set; }
        public decimal? LwSubline { get; set; }
        public decimal? CsMain { get; set; }
        public decimal? CsSubline { get; set; }
        public decimal? BodyMain { get; set; }
        public decimal? BodySubline { get; set; }
        public decimal? BottomMain { get; set; }
        public decimal? BottomSubline { get; set; }
        public decimal? TopMain { get; set; }
        public decimal? TopSubline { get; set; }
        public decimal? StatorMain { get; set; }
        public decimal? StatorSubline { get; set; }
        public decimal? RotorMain { get; set; }
        public decimal? RotorSubline { get; set; }
        public DateTime? CreateDate { get; set; } 
    }
}
