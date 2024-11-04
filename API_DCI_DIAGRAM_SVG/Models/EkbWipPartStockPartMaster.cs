using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartStockPartMaster
    {
        public string PartCode { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? PartName { get; set; }
        public string? PartModel { get; set; }
        public string PartNameCode { get; set; } = null!;
        public decimal? StdPackQty { get; set; }
        public string? PartStatus { get; set; }
    }
}
