using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptManualPoMaster
    {
        public int Id { get; set; }
        public string? PoNumber { get; set; }
        public string? PoInvoice { get; set; }
        public DateTime? PoEffectDate { get; set; }
        public DateTime? PoShipDate { get; set; }
        public string? PoSupplierCode { get; set; }
        public string? PoSupplierName { get; set; }
        public string? PoVat { get; set; }
        public DateTime? PoCreateDate { get; set; }
        public string? PoCreateBy { get; set; }
        public string? PoStatus { get; set; }
    }
}
