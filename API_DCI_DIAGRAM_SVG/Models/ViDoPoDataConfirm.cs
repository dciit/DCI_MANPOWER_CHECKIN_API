using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViDoPoDataConfirm
    {
        public DateTime RndDate { get; set; }
        public string? PoNbr { get; set; }
        public string? PtPart { get; set; }
        public string? PoLine { get; set; }
        public decimal DpQty { get; set; }
    }
}
