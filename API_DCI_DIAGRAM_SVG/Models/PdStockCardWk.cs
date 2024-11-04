using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdStockCardWk
    {
        public string Pid { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Ymd { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string? Partname { get; set; }
        public string Cm { get; set; } = null!;
        public string? Unit { get; set; }
        public string? Route { get; set; }
        public decimal? Balqty { get; set; }
    }
}
