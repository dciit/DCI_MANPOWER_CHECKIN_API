using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPdFormula
    {
        public string Wcno { get; set; } = null!;
        public string Apartno { get; set; } = null!;
        public string Akotei { get; set; } = null!;
        public string Bpartno { get; set; } = null!;
        public string Bkotei { get; set; } = null!;
        public string Kaiseq { get; set; } = null!;
        public decimal? Suryo { get; set; }
        public string Pwcno { get; set; } = null!;
        public string? Grp { get; set; }
        public string? Strymn { get; set; }
        public string? Endymn { get; set; }
        public string? Ksnbit { get; set; }
        public string? Motokai { get; set; }
        public string? Sekbn { get; set; }
        public string? Henku { get; set; }
        public string? Henres { get; set; }
        public string? Htanto { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
        public string Acm { get; set; } = null!;
        public string Bcm { get; set; } = null!;
    }
}
