using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdPartStockKdr
    {
        public string Prddate { get; set; } = null!;
        public string Prdshift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public decimal QtyOk { get; set; }
        public decimal QtyNg { get; set; }
        public DateTime? Updatedate { get; set; }
        public string? Updateby { get; set; }
    }
}
