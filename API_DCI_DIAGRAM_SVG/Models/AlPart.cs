using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPart
    {
        public string DrawingNo { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Description { get; set; }
        public string? Route { get; set; }
        public string? OrderType { get; set; }
        public string? Catmat { get; set; }
        public string? Whunit { get; set; }
        public string? CnvCode { get; set; }
        public decimal? CnvWt { get; set; }
        public string? Ivunit { get; set; }
        public decimal? QtyBox { get; set; }
        public string VenderCode { get; set; } = null!;
        public string? VenderName { get; set; }
        public int? LeadTime { get; set; }
        public int? PdLeadTime { get; set; }
        public string? Remark1 { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
