using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlInvoiceMaster
    {
        public string VendorCode { get; set; } = null!;
        public string? VendorName { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceSubTotol { get; set; }
        public string? InvoiceVat { get; set; }
        public string? InvoiceNetTotal { get; set; }
        public string? FileMaster { get; set; }
        public string? VendorStatus { get; set; }
    }
}
