using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartAutoRequestLog
    {
        public string Jibu { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Idate { get; set; } = null!;
        public string Itime { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Kotei { get; set; } = null!;
        public string Brusn { get; set; } = null!;
        public decimal? Icnt { get; set; }
        public decimal? Rqty { get; set; }
        public decimal? Iqty { get; set; }
        public decimal? Sqty { get; set; }
        public string Slipno { get; set; } = null!;
        public string? Cfmbit { get; set; }
        public string? Sekbn { get; set; }
        public string? Iperson { get; set; }
        public string? Cperson { get; set; }
        public string? Henku { get; set; }
        public string? Henres { get; set; }
        public string? Htanto { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
    }
}
