using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWipstkYmd
    {
        public string Ymd { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Desc1 { get; set; }
        public decimal? Lwbal { get; set; }
        public decimal? Recqty { get; set; }
        public decimal? Isqty { get; set; }
        public decimal? Balqty { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
