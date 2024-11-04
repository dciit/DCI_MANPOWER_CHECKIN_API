using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPkgMstr
    {
        public string Model { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Description { get; set; }
        public string Route { get; set; } = null!;
        public string Vender { get; set; } = null!;
        public string? Vendername { get; set; }
        public int? ReqQty { get; set; }
        public string? Unit { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
