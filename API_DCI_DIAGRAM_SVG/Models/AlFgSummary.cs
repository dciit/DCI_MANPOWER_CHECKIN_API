using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlFgSummary
    {
        public string Ymd { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string Line { get; set; } = null!;
        public string TypeDate { get; set; } = null!;
        public string Wc { get; set; } = null!;
        public string? Io { get; set; }
        public string? Qty { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
