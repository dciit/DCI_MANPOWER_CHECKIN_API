using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsPriorityPlanRemake
    {
        public string Ymd { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Seq { get; set; } = null!;
        public string SubLine { get; set; } = null!;
        public string Packing { get; set; } = null!;
        public string? Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public bool? IsRemark { get; set; }
        public bool? IsRev { get; set; }
    }
}
