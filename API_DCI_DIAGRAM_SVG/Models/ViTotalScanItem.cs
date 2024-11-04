using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViTotalScanItem
    {
        public string InvoiceId { get; set; } = null!;
        public string ItemId { get; set; } = null!;
        public decimal? TotalScan { get; set; }
    }
}
