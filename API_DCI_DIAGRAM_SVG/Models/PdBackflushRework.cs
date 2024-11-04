using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdBackflushRework
    {
        public DateTime Pddate { get; set; }
        public string Shift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Drawing { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public int? Qty { get; set; }
        public string? Remark { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
