using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedStockIssue
    {
        public string SiNo { get; set; } = null!;
        public string? SiCostcenter { get; set; }
        public string? SiStatus { get; set; }
        public string? SiRequestBy { get; set; }
        public string? SiCreateBy { get; set; }
        public DateTime? SiDate { get; set; }
    }
}
