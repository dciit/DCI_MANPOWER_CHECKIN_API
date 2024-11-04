using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlLinePartStock
    {
        public string Ym { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Desc1 { get; set; }
        public string Wcno { get; set; } = null!;
        public string? Whum { get; set; }
        public decimal? Lastbal { get; set; }
        public decimal? Recqty { get; set; }
        public decimal? Issqty { get; set; }
        public decimal? Balqty { get; set; }
        public int? Lrev { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
