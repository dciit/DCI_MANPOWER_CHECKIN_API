using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsInventoryWipbyDate
    {
        public DateTime Ymd { get; set; }
        public string ItemCode { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public decimal? Inventory { get; set; }
        public decimal? Result { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
