using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempReceived
    {
        public int TmpId { get; set; }
        public string? PartPackageId { get; set; }
        public string? InvoiceId { get; set; }
        public string? Invoice { get; set; }
        public string? Po { get; set; }
        public string? ItemId { get; set; }
        public decimal? ScanQty { get; set; }
        public DateTime? ScanDate { get; set; }
        public string? ScanBy { get; set; }
    }
}
