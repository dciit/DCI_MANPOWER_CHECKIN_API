using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViReceiptItemsTypeStatus
    {
        public string? Einvoice { get; set; }
        public string? Invoice { get; set; }
        public string? SupplierName { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public int? RndId { get; set; }
        public int? DpId { get; set; }
        public string? PtPart { get; set; }
        public string? PartType { get; set; }
        public int? DpStatus { get; set; }
        public string? InvoiceStatus { get; set; }
        public bool? QadStatus { get; set; }
        public string? ItemStatus { get; set; }
    }
}
