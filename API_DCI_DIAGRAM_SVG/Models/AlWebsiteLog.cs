using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWebsiteLog
    {
        public string LogNbr { get; set; } = null!;
        public DateTime? LogDt { get; set; }
        public string? LogDomain { get; set; }
        public string? LogLink { get; set; }
        public string? LogIp { get; set; }
    }
}
