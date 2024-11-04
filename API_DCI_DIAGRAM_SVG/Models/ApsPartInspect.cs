using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsPartInspect
    {
        public string PartNo { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? PartDesc { get; set; }
        public string? Route { get; set; }
        public string Vendor { get; set; } = null!;
        public string? VendorName { get; set; }
        public string? InspectType { get; set; }
    }
}
