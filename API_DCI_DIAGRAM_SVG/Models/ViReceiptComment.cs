using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViReceiptComment
    {
        public string? Einvoice { get; set; }
        public string? Invoice { get; set; }
        public string? SupplierNo { get; set; }
        public string? SupplierName { get; set; }
        public string? Comment { get; set; }
        public string? UserId { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}
