using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdConfig
    {
        public string Cfgtype { get; set; } = null!;
        public string? Cfgcode { get; set; }
        public string? Cfgyear { get; set; }
        public string? Cfgmonth { get; set; }
        public int? CfgdigitNumber { get; set; }
        public int? Cfgrunning { get; set; }
    }
}
