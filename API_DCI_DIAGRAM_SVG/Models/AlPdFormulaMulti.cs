using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPdFormulaMulti
    {
        public string Fno { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string Pwcno { get; set; } = null!;
        public string Ppartno { get; set; } = null!;
        public string Pcm { get; set; } = null!;
        public decimal? Qty { get; set; }
        public string? Strymd { get; set; }
        public string? Endymd { get; set; }
        public string Lrev { get; set; } = null!;
        public string? Rev { get; set; }
        public string? Reason { get; set; }
        public string? Person { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
    }
}
