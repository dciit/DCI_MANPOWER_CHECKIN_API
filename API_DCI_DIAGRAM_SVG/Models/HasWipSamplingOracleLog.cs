using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasWipSamplingOracleLog
    {
        public string Nbr { get; set; } = null!;
        public string Jibu { get; set; } = null!;
        public string Iwcno { get; set; } = null!;
        public string Bwcno { get; set; } = null!;
        public string Idate { get; set; } = null!;
        public string Itime { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Descr { get; set; }
        public decimal? Rqty { get; set; }
        public decimal? Boxqty { get; set; }
        public string? Delto { get; set; }
        public string? Cfbit { get; set; }
        public string? Iperson { get; set; }
        public string? Cperson { get; set; }
        public string? Refno { get; set; }
        public string? Docno { get; set; }
        public string? Sekbn { get; set; }
        public string? Henku { get; set; }
        public string? Henres { get; set; }
        public string? Hanto { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
    }
}
