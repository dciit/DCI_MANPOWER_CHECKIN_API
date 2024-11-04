using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdInitializeLocationInventory
    {
        public int Id { get; set; }
        public string? LocationId { get; set; }
        public string? PtPart { get; set; }
        public string? DataMonth { get; set; }
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
