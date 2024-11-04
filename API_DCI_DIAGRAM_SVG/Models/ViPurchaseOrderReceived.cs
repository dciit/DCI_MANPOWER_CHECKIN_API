using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPurchaseOrderReceived
    {
        public string? PodNbr { get; set; }
        public decimal? PodLine { get; set; }
        public string? PodPart { get; set; }
        public decimal? PodQtyReceive { get; set; }
        public string? PodUm { get; set; }
    }
}
