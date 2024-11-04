using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsMasterProblem
    {
        public string ProblemCode { get; set; } = null!;
        public string? ProblemName { get; set; }
        public string? ProblemType { get; set; }
        public string? ProblemRemark1 { get; set; }
        public string? ProblemRemark2 { get; set; }
        public string? ProblemRemark3 { get; set; }
        public string? ProblemRemark4 { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
