using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlphaPicklistPrint
    {
        public string Idate { get; set; } = null!;
        public string Itime { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Slipno { get; set; } = null!;
        public string? Printbit { get; set; }
        public string? Printer { get; set; }
        public string? PrinterWh { get; set; }
    }
}
