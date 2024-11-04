using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartStockWip
    {
        public string Nbr { get; set; } = null!;
        public string? Ym { get; set; }
        public string? Partno { get; set; }
        public string? Cm { get; set; }
        public string? Desc1 { get; set; }
        public string? Route { get; set; }
        public string? Wcno { get; set; }
        public string? Whum { get; set; }
        public decimal? Lwbal { get; set; }
        public decimal? Recqty { get; set; }
        public decimal? Isqty { get; set; }
        public decimal? Balqty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Amt { get; set; }
        public DateTime? DataDate { get; set; }
        public string? Product { get; set; }
        public string? Lrev { get; set; }
    }
}
