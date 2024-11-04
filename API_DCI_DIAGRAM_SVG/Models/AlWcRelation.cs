using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWcRelation
    {
        public string ParentWcno { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string? LineType { get; set; }
        public string? LineSub { get; set; }
        public int? LineOrderBy { get; set; }
    }
}
