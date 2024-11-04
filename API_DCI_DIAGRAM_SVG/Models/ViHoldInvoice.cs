using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViHoldInvoice
    {
        public string? Einvoice { get; set; }
        public string? Invoice { get; set; }
        public string? SupplierNo { get; set; }
        public string? SupplierName { get; set; }
        public string? HoldBy { get; set; }
        public DateTime? HoldDate { get; set; }
        public string? Status { get; set; }
    }
}
