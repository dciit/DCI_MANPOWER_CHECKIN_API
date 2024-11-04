using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPdFormulaWc
    {
        public string Partno { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Ptype { get; set; } = null!;
        public string Trnbit { get; set; } = null!;
        public string Trnwcno { get; set; } = null!;
        public string? Strymd { get; set; }
        public string? Endymd { get; set; }
        public string Lrev { get; set; } = null!;
        public string? Rev { get; set; }
        public string? Reason { get; set; }
        public string? Person { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Ftype { get; set; } = null!;
    }
}
