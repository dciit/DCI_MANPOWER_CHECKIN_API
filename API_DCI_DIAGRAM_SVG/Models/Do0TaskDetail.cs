using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Do0TaskDetail
    {
        public string RunningCode { get; set; } = null!;
        public string Supplier { get; set; } = null!;
        public int Revision { get; set; }
        public string? Status { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
