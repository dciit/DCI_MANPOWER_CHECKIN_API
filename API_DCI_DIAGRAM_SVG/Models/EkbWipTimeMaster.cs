using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipTimeMaster
    {
        public string Wcno { get; set; } = null!;
        public string TimeFrom { get; set; } = null!;
        public string TimeTo { get; set; } = null!;
        public string? TimeDelivery { get; set; }
    }
}
