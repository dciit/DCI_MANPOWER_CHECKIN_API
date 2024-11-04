using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IvInventoryBook
    {
        public string Ymd { get; set; } = null!;
        public string Rev { get; set; } = null!;
        public string Tagno { get; set; } = null!;
        public string Orderno { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Descr { get; set; }
        public string? Whum { get; set; }
        public string? Route { get; set; }
        public decimal? BookQty { get; set; }
        public string? Cby { get; set; }
        public DateTime? Cdate { get; set; }
    }
}
