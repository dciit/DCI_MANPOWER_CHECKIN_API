using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasSamplingDict
    {
        public string DictType { get; set; } = null!;
        public string DictCode { get; set; } = null!;
        public string? DictDesc { get; set; }
        public string? DictRef { get; set; }
    }
}
