using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsInventoryRm
    {
        public string ItemCode { get; set; } = null!;
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
