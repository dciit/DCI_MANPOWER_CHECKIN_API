using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPoBalance
    {
        public int RunningId { get; set; }
        public string RunningCode { get; set; } = null!;
        public int Revision { get; set; }
        public string VdAddr { get; set; } = null!;
        public string ItemNumber { get; set; } = null!;
        public string? ItemUm { get; set; }
        public int? ItemLine { get; set; }
        public string? PurchaseOrder { get; set; }
        public decimal? QtyOrder { get; set; }
        public decimal? QtyReceived { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }
}
