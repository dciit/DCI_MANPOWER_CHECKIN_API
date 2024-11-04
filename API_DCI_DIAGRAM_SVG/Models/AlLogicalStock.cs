using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlLogicalStock
    {
        public string Nbr { get; set; } = null!;
        public string? Ymd { get; set; }
        public int? Syocnt { get; set; }
        public string? Bpartno { get; set; }
        public string? Bkotei { get; set; }
        public string? Bbrusn { get; set; }
        public string? Bkojiku { get; set; }
        public string? Bhatank { get; set; }
        public string? Bhtcode { get; set; }
        public string? Ahtcode { get; set; }
        public string? Dnbasyo { get; set; }
        public string? Kankom { get; set; }
        public string? Boipj { get; set; }
        public string? Mprdym { get; set; }
        public string? Nonymn { get; set; }
        public decimal? Riryoj { get; set; }
    }
}
