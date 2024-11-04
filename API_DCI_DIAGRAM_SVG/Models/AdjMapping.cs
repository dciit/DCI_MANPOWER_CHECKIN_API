using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdjMapping
    {
        public string ModelCodeOld { get; set; } = null!;
        public string? ModelNameOld { get; set; }
        public string ModelCodeNew { get; set; } = null!;
        public string? ModelNameNew { get; set; }
    }
}
