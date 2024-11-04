using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlScrapLog
    {
        public string Nbr { get; set; } = null!;
        public string? DocNo { get; set; }
        public string? Permission { get; set; }
        public string? Action { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }
}
