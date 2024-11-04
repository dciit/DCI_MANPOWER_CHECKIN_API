using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempIssued
    {
        public int Id { get; set; }
        public string TagId { get; set; } = null!;
        public string? PicklistNo { get; set; }
        public string? ItemId { get; set; }
        public decimal? IssueQty { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? IssueBy { get; set; }
        public string? Remark { get; set; }
    }
}
