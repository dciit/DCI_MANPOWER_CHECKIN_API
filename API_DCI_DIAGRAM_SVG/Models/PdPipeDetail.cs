using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdPipeDetail
    {
        public string PdId { get; set; } = null!;
        public int? PhId { get; set; }
        public string? PdPipenumber { get; set; }
        public string? PdProcess { get; set; }
        public int? PdMcLine { get; set; }
        public string? PdStatus { get; set; }
        public string? PdRemark { get; set; }
        public DateTime? PdMfgdate { get; set; }
        public string? PdCreateby { get; set; }
        public DateTime? PdCreatedate { get; set; }
        public string? PdUpdateby { get; set; }
        public DateTime? PdUpdatedate { get; set; }
    }
}
