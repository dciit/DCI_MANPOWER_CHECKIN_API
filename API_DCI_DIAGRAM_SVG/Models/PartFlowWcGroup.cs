using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PartFlowWcGroup
    {
        public string Wcno { get; set; } = null!;
        public string GrpCode { get; set; } = null!;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
