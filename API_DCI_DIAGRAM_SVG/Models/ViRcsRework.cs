using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViRcsRework
    {
        public string PipeNo { get; set; } = null!;
        public string ReworkCode { get; set; } = null!;
        public string? Line { get; set; }
        public string? ModelCode { get; set; }
        public string? Model { get; set; }
        public string? InBy { get; set; }
        public DateTime? InDate { get; set; }
        public string? OutBy { get; set; }
        public DateTime? OutDate { get; set; }
        public string? ReworkStatus { get; set; }
        public string? ReworkLine { get; set; }
        public string? ProblemName { get; set; }
        public string? ProblemType { get; set; }
        public string? ProblemRemark1 { get; set; }
        public string? ProblemRemark2 { get; set; }
        public string? ProblemRemark3 { get; set; }
        public string? ProblemRemark4 { get; set; }
        public string ProblemCode { get; set; } = null!;
    }
}
