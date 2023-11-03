using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsPoint
    {
        public int PosId { get; set; }
        public int? ObjId { get; set; }
        public string? PosName { get; set; }
        public double? PosX { get; set; }
        public double? PosW { get; set; }
        public double? PosY { get; set; }
        public double? PosH { get; set; }
        public string? Status { get; set; }
    }
}
