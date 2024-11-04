using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptMonitorTran
    {
        public int Id { get; set; }
        public string? Einvoice { get; set; }
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? SupplierNo { get; set; }
        public string? SupplierName { get; set; }
        public int? OrderLine { get; set; }
        public int? ReceiveLine { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? ReceiveBy { get; set; }
        public string? Status { get; set; }
        public int? TotalTag { get; set; }
        public int? ScanTag { get; set; }
        public decimal? Percentage { get; set; }
        public bool? IsQad { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? UserId { get; set; }
    }
}
