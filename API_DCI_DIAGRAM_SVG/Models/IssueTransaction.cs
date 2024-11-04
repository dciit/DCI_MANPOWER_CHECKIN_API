using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssueTransaction
    {
        public string Id { get; set; } = null!;
        public string? Picklist { get; set; }
        public string? PartId { get; set; }
        public decimal? Qty { get; set; }
        public string? Um { get; set; }
        public string? IssueBy { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? Status { get; set; }
    }
}
