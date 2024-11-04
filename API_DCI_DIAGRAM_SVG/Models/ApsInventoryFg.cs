using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsInventoryFg
    {
        public string ModelName { get; set; } = null!;
        public string PackagingType { get; set; } = null!;
        public double? Quantity { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
