using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultMainWk2
    {
        public string Pid { get; set; } = null!;
        public DateTime Prddate { get; set; }
        public string Line { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int SerialCount { get; set; }
    }
}
