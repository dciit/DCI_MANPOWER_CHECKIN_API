using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViRcsReworkLog
    {
        public string PipeNo { get; set; } = null!;
        public string ReworkCode { get; set; } = null!;
        public string ReworkType { get; set; } = null!;
        public string? LogBy { get; set; }
        public DateTime LogTime { get; set; }
        public string? Remark { get; set; }
        public string? ReworkLine { get; set; }
        public string ProblemCode { get; set; } = null!;
        public string? ProblemName { get; set; }
        public string? ProblemType { get; set; }
        public string? ProblemRemark1 { get; set; }
        public string? ProblemRemark2 { get; set; }
        public string? ProblemRemark3 { get; set; }
        public string? ProblemRemark4 { get; set; }
    }
}
