using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdPipeHeader
    {
        public int PhId { get; set; }
        public string PhModel { get; set; } = null!;
        public int? PhWip1 { get; set; }
        public int? PhWip2 { get; set; }
        public int? PhNg { get; set; }
        public string? PhLocationCode { get; set; }
        public int? PhMcLine { get; set; }
        public string? PhRemark { get; set; }
        public string? PhCreateby { get; set; }
        public DateTime? PhCreatedate { get; set; }
        public string? PhUpdateby { get; set; }
        public DateTime? PhUpdatedate { get; set; }
    }
}
