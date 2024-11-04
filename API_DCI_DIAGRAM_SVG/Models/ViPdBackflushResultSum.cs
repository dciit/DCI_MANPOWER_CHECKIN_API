using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPdBackflushResultSum
    {
        public string? Pdmonth { get; set; }
        public string? Pdday { get; set; }
        public string Shift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public int? Qty { get; set; }
    }
}
