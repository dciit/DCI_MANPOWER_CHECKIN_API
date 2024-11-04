using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWcallowIssue
    {
        public string Nbr { get; set; } = null!;
        public string? Wcno { get; set; }
        public string? Idate { get; set; }
        public string? AllowBy { get; set; }
        public DateTime? AllowDate { get; set; }
    }
}
