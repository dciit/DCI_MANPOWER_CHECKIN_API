using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsFgstockInOut
    {
        public string AssortType { get; set; } = null!;
        public DateTime LoadingDate { get; set; }
        public string Model { get; set; } = null!;
        public string PackingType { get; set; } = null!;
        public decimal? Quantity { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
