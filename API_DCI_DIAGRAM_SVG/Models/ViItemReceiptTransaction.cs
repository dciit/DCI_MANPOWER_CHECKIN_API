using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViItemReceiptTransaction
    {
        public string EinvoiceId { get; set; } = null!;
        public string Invoice { get; set; } = null!;
        public string PoNbr { get; set; } = null!;
        public string PartId { get; set; } = null!;
        public decimal? ReceiptQty { get; set; }
        public decimal? OrderQty { get; set; }
        public DateTime? UpdateQty { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public bool? DataVendor { get; set; }
        public bool? PackageComplete { get; set; }
        public string? LotType { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
    }
}
