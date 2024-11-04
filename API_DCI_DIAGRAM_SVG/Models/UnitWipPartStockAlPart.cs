using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UnitWipPartStockAlPart
    {
        public string Ym { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? PartDesc { get; set; }
        public decimal? Lbal { get; set; }
        public decimal? Recqty { get; set; }
        public decimal? Issqty { get; set; }
        public decimal? Bal { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Kisyun { get; set; }
        public string? Apartno { get; set; }
        public string Partno { get; set; } = null!;
    }
}
