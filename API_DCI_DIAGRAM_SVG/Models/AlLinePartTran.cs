using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlLinePartTran
    {
        public string Nbr { get; set; } = null!;
        public string? Ymd { get; set; }
        public string? Partno { get; set; }
        public string? Cm { get; set; }
        public string? Desc1 { get; set; }
        public string? Wcno { get; set; }
        public string? Whum { get; set; }
        public string? TrnType { get; set; }
        public decimal? Qty { get; set; }
        public int? Lrev { get; set; }
        public string? DataBy { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
