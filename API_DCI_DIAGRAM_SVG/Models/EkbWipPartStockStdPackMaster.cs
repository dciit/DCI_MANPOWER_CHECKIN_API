using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartStockStdPackMaster
    {
        public string PartNameCode { get; set; } = null!;
        public string PartCode { get; set; } = null!;
        public int? StdBoxQty { get; set; }
        public string? Line { get; set; }
        public string? Lrev { get; set; }
        public string? Remark { get; set; }
    }
}
