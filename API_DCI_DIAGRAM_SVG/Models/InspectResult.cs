using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class InspectResult
    {
        public int InId { get; set; }
        public int? DpId { get; set; }
        public string? PtPart { get; set; }
        public decimal? QtyInspect { get; set; }
        public decimal? QtyOk { get; set; }
        public decimal? QtyNg { get; set; }
        public decimal? QtyScrap { get; set; }
        public string? InStatus { get; set; }
        public string? Remark { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
