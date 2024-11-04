using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViApsInventoryWipDev
    {
        public string ItemCode { get; set; } = null!;
        public string? Unit { get; set; }
        public double? Quantity { get; set; }
    }
}
