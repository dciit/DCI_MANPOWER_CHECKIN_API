using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsMasterProblemImage
    {
        public string ProblemCode { get; set; } = null!;
        public string ProblemType { get; set; } = null!;
        public string ProblemMc { get; set; } = null!;
        public string? ProblemImage { get; set; }
        public string? ProblemStatus { get; set; }
        public string? Type { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
