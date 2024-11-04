using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdjSerialEditDigit
    {
        public string Serial { get; set; } = null!;
        public string SerialOld { get; set; } = null!;
        public string SerialNew { get; set; } = null!;
        public bool? SerialStatus { get; set; }
    }
}
