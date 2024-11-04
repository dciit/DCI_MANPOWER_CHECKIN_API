using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedPicklistTransaction
    {
        public string IssueId { get; set; } = null!;
        public string QadNbr { get; set; } = null!;
        public int? ItemLine { get; set; }
        public string? PtPart { get; set; }
        public string? Um { get; set; }
        public int? Sequence { get; set; }
        public decimal? QtyOpen { get; set; }
        public decimal? QtyAllow { get; set; }
        public decimal? QtyPick { get; set; }
        public decimal? QtyIssue { get; set; }
        public string? SourceLoc { get; set; }
        public string? RequestLoc { get; set; }
        public string? PickBy { get; set; }
        public DateTime? PickDate { get; set; }
        public string? AllowBy { get; set; }
        public DateTime? AllowDate { get; set; }
    }
}
