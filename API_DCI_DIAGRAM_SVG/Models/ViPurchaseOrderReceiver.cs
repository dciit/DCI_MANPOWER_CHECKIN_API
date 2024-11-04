using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPurchaseOrderReceiver
    {
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? Receiver { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string? Supplier { get; set; }
    }
}
