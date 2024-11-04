using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HelpdeskJob
    {
        public int JobId { get; set; }
        public string HdCode { get; set; } = null!;
        public int? JobFac { get; set; }
        public string? JobLocation { get; set; }
        public string? JobReqBy { get; set; }
        public DateTime? JobReqDate { get; set; }
        public string? JobDesc { get; set; }
        public string? JobAcceptBy { get; set; }
        public DateTime? JobAcceptDate { get; set; }
        public DateTime? JobFinishDate { get; set; }
        public string? JobStatus { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
