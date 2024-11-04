using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlComSerial
    {
        public string SerialNo { get; set; } = null!;
        public string? Line { get; set; }
        public string? Wcno { get; set; }
        public string? PlNo { get; set; }
        public string? Model { get; set; }
        public string? PlType { get; set; }
        public string? SerialStatus { get; set; }
        public string? DataBy { get; set; }
        public DateTime? DataDatetime { get; set; }
    }
}
