using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlInhouseAct
    {
        public string Prdymd { get; set; } = null!;
        public string Sht { get; set; } = null!;
        public string? Bgdept { get; set; }
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public long? Qty { get; set; }
        public string? Result { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
