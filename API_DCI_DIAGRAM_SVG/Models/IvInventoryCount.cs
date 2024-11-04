using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IvInventoryCount
    {
        public string Ymd { get; set; } = null!;
        public string Rev { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string Whum { get; set; } = null!;
        public string Tagno { get; set; } = null!;
        public decimal Phyqty { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
