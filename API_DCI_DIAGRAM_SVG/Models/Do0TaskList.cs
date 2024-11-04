using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Do0TaskList
    {
        public string RunningCode { get; set; } = null!;
        public string DoType { get; set; } = null!;
        public int Revision { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }
}
