using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlphaDailyResult
    {
        public string PrdDate { get; set; } = null!;
        public string Wc { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Shift { get; set; } = null!;
        public DateTime? ResultDate { get; set; }
        public int? Qty { get; set; }
        public string? ReffNo { get; set; }
        public string? ResultCreateDate { get; set; }
        public string? ResultModifiedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
