using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartDescription
    {
        public string PartNo { get; set; } = null!;
        public string? Description { get; set; }
        public string? LockIssue { get; set; }
    }
}
