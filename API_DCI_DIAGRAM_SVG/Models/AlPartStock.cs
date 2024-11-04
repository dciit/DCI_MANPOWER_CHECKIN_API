using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartStock
    {
        public string Ymd { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Desc1 { get; set; }
        public string? Route { get; set; }
        public string Wh { get; set; } = null!;
        public string? Whum { get; set; }
        public string? Qtybox { get; set; }
        public int? OrderLt { get; set; }
        public string? Cnvcode { get; set; }
        public decimal? Cnvweight { get; set; }
        public string? Cnvum { get; set; }
        public decimal? Minqty { get; set; }
        public decimal? Lwbal { get; set; }
        public decimal? Recqty { get; set; }
        public decimal? Isqty { get; set; }
        public decimal? Balqty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Amt { get; set; }
        public DateTime? DataDate { get; set; }
        public string? Product { get; set; }
    }
}
