using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPurchaseOrderBalanceN
    {
        public string? PodNbr { get; set; }
        public string? PodPart { get; set; }
        public decimal? PodOrderQty { get; set; }
        public decimal? PodReceived { get; set; }
        public decimal? PodRemain { get; set; }
    }
}
