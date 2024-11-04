using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPoReceiver
    {
        public string? Einvoice { get; set; }
        public string? Supplier { get; set; }
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? Receiver { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}
