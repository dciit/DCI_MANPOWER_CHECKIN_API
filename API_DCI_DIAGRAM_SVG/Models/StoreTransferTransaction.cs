using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class StoreTransferTransaction
    {
        public string Id { get; set; } = null!;
        public DateTime? EffectiveDate { get; set; }
        public string? OrderNo { get; set; }
        public string? ItemNumber { get; set; }
        public decimal? Quantity { get; set; }
        public string? Remarks { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? QadStatus { get; set; }
    }
}
