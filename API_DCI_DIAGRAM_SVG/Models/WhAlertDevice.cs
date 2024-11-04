using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhAlertDevice
    {
        public DateTime? AlertTime { get; set; }
        public string? Alert { get; set; }
        public string? RigType { get; set; }
    }
}
