using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViSupplierAddress
    {
        public string SupplierNo { get; set; } = null!;
        public string? VdSort { get; set; }
        public string? VdShipvia { get; set; }
        public string? AdLine1 { get; set; }
        public string? AdLine2 { get; set; }
        public string? AdLine3 { get; set; }
        public string? AdFax { get; set; }
        public string? AdFax2 { get; set; }
        public string? AdPhone2 { get; set; }
        public string? AdAttn2 { get; set; }
        public string? AdCountry { get; set; }
        public string? AdPhone { get; set; }
        public string? AdAttn { get; set; }
        public string? AdZip { get; set; }
        public string? AdState { get; set; }
        public string? AdCity { get; set; }
        public string? AdName { get; set; }
    }
}
