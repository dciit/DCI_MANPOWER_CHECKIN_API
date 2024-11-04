using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PartFlowUserInGroup
    {
        public string EmpCode { get; set; } = null!;
        public string GrpCode { get; set; } = null!;
        public string? GrpName { get; set; }
        public string? EmpStatus { get; set; }
        public string? Wcno { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
