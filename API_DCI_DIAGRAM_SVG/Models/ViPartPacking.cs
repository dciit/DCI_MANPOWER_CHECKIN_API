using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPartPacking
    {
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public string? VdSort { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtUm { get; set; }
        public decimal? OrderWeight { get; set; }
    }
}
