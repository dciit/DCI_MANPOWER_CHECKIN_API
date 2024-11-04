using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WkIvDiffReport
    {
        public string Pid { get; set; } = null!;
        public string Ymd { get; set; } = null!;
        public string Rev { get; set; } = null!;
        public string Tagno { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Partname { get; set; }
        public string? Whunit { get; set; }
        public string? Route { get; set; }
        public decimal? Stdcost { get; set; }
        public decimal? Bookqty { get; set; }
        public decimal? Phyqty { get; set; }
    }
}
