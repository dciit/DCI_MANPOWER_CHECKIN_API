using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultMainWk1
    {
        public string Pid { get; set; } = null!;
        public DateTime Prddate { get; set; }
        public string Line { get; set; } = null!;
        public string Serial { get; set; } = null!;
        public string? Model { get; set; }
    }
}
