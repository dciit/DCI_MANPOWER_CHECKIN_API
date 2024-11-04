using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultSubLine
    {
        public string PrdType { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public DateTime Prddate { get; set; }
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createdate { get; set; }
        public string Rev { get; set; } = null!;
        public string Lrev { get; set; } = null!;
        public decimal? ManualQuantity { get; set; }
    }
}
