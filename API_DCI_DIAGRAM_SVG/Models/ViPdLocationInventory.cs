using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPdLocationInventory
    {
        public string LocationId { get; set; } = null!;
        public string PtPart { get; set; } = null!;
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtUm { get; set; }
        public string? StatusRm { get; set; }
        public decimal? Qty { get; set; }
        public decimal? MininumStock { get; set; }
        public decimal? MaximunStock { get; set; }
        public decimal? SafetyStock { get; set; }
        public string? Remark { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? IssueStatus { get; set; }
    }
}
