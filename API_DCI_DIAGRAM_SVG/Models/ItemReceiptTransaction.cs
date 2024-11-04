using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ItemReceiptTransaction
    {
        public string EinvoiceId { get; set; } = null!;
        public string Invoice { get; set; } = null!;
        public string PoNbr { get; set; } = null!;
        public int Line { get; set; }
        public string PartId { get; set; } = null!;
        public decimal? ReceiptQty { get; set; }
        public decimal? OrderQty { get; set; }
        public DateTime? UpdateQty { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? DataVendor { get; set; }
        public string? PackageComplete { get; set; }
        public string? LotType { get; set; }
    }
}
