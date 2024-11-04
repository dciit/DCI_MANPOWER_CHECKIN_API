using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViReceiveTransaction
    {
        public string EinvoiceId { get; set; } = null!;
        public string PartId { get; set; } = null!;
        public decimal? OrderQty { get; set; }
        public decimal? ReceiptQty { get; set; }
        public DateTime? UpdateQty { get; set; }
    }
}
