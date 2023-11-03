using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsLayout
    {
        public string LayoutCode { get; set; } = null!;
        public string? LayoutName { get; set; }
        public int? LayoutWidth { get; set; }
        public int? LayoutHeight { get; set; }
    }
}
