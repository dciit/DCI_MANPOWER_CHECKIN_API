using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdMarkingItemMaster
    {
        public string PdLine { get; set; } = null!;
        public string PdLoc { get; set; } = null!;
        public string? PdMc { get; set; }
        public string? PdMcname { get; set; }
        public string PdModel { get; set; } = null!;
        public string PdPart { get; set; } = null!;
        public DateTime? EffStart { get; set; }
        public DateTime? EffEnd { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? Remark4 { get; set; }
        public string? Remark5 { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? PdType { get; set; }
    }
}
