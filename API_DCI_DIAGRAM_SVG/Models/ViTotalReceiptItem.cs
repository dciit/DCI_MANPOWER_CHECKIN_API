using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViTotalReceiptItem
    {
        public string? EInvoiceId { get; set; }
        public string? PartId { get; set; }
        public decimal OrderQty { get; set; }
        public decimal? TotalScan { get; set; }
        public string? PtPart { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
    }
}
