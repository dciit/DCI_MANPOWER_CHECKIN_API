using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsProductionPlanNotice
    {
        public string NtNbr { get; set; } = null!;
        public string PrdPlanCode { get; set; } = null!;
        public string NtType { get; set; } = null!;
        public string NtCode { get; set; } = null!;
        public string? NtObjectiveType { get; set; }
        public string? NtNotice { get; set; }
        public string? CreBy { get; set; }
        public DateTime? CreDt { get; set; }
    }
}
