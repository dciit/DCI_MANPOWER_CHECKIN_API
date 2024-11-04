using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempChangeSerial
    {
        public int Id { get; set; }
        public string? FromSerial { get; set; }
        public string? ToSerial { get; set; }
        public string? ChgStatus { get; set; }
    }
}
