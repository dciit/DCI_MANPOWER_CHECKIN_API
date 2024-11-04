using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlDstDatpil
    {
        public string Iwcno { get; set; } = null!;
        public string Bwcno { get; set; } = null!;
        public string Idate { get; set; } = null!;
        public string Itime { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Descr { get; set; }
        public decimal? Rqty { get; set; }
        public decimal? Iqty { get; set; }
        public decimal? Boxqty { get; set; }
        public string? Delto { get; set; }
        public string? Prgbit { get; set; }
        public string? Rqperson { get; set; }
        public DateTime? Rqdate { get; set; }
        public string? Cfperson { get; set; }
        public DateTime? Cfdate { get; set; }
        public string? Ajperson { get; set; }
        public DateTime? Ajdate { get; set; }
        public string? Refno { get; set; }
        public string? Docno { get; set; }
        public string? Sekbn { get; set; }
        public string? Henku { get; set; }
        public string? Henres { get; set; }
        public string? Htanto { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Udate { get; set; }
    }
}
