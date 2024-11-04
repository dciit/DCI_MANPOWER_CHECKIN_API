using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViReceiverPrint
    {
        public string ReceiptNo { get; set; } = null!;
        public string? Einvoice { get; set; }
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? Receiver { get; set; }
        public decimal? TransNo { get; set; }
        public string? PartId { get; set; }
        public decimal? ReceiptQty { get; set; }
        public string? Um { get; set; }
        public string? Supplier { get; set; }
        public string? Site { get; set; }
        public string? Location { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string? Type { get; set; }
        public string? Username { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtDesc1 { get; set; }
    }
}
