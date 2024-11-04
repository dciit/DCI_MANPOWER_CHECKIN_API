using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsMasterProblemPoint
    {
        public string? ProblemCode { get; set; }
        public string? ProblemType { get; set; }
        public string? ProblemMc { get; set; }
        public string ProblemPointCode { get; set; } = null!;
        public string? ProblemPointDescription { get; set; }
        public string? ProblemStatus { get; set; }
        public string? Type { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatetDate { get; set; }
    }
}
