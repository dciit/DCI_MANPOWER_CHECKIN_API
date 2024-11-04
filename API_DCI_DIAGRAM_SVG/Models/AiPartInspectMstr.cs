using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AiPartInspectMstr
    {
        public int InspectMstrId { get; set; }
        public string PartNo { get; set; } = null!;
        public string VdName { get; set; } = null!;
        public string? PartName { get; set; }
        public string? InspectPoint { get; set; }
        public decimal? InspectMin { get; set; }
        public decimal? InspectMax { get; set; }
        public string? InspectDesc { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
