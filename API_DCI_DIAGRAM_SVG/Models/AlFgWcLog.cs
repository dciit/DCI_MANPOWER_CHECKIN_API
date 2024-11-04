using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlFgWcLog
    {
        public string? SerialNo { get; set; }
        public string? OldWc { get; set; }
        public string? NewWc { get; set; }
        public string? Line { get; set; }
        public string? OldDate { get; set; }
        public string? NewDate { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
