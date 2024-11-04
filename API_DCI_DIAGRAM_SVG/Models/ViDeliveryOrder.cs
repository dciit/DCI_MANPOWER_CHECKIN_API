using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViDeliveryOrder
    {
        public string? MainCode { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public string? Bpartno { get; set; }
        public double? PlanQty { get; set; }
        public decimal? Suryo { get; set; }
        public string? Route { get; set; }
        public string? VenderCode { get; set; }
        public double? Usege { get; set; }
    }
}
