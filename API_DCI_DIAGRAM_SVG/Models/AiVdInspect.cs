using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AiVdInspect
    {
        public string InspectId { get; set; } = null!;
        public string InspectMstrId { get; set; } = null!;
        public string? VendorId { get; set; }
        public string? InspectCount1 { get; set; }
        public string? InspectCount2 { get; set; }
        public string? InspectCount3 { get; set; }
        public string? InspectCount4 { get; set; }
        public string? InspectCount5 { get; set; }
        public string? InspectCount6 { get; set; }
        public string? InspectCount7 { get; set; }
        public string? InspectCount8 { get; set; }
        public string? InspectCount9 { get; set; }
        public string? InspectCount10 { get; set; }
        public string? InspectJudement { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public string? Lot { get; set; }
        public string? InspectNo { get; set; }
        public string? Material { get; set; }
    }
}
