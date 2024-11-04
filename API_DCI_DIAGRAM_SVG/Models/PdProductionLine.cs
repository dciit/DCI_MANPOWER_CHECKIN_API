using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdProductionLine
    {
        public int Pdid { get; set; }
        public string? FactoryName { get; set; }
        public string? LineName { get; set; }
        public string? ProcessName { get; set; }
        public int? Pdline { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
