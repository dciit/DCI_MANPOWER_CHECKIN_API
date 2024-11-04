using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPartTagTransaction
    {
        public string? TagId { get; set; }
        public string? TagPart { get; set; }
        public decimal? TagQty { get; set; }
        public DateTime? TagReceiveDt { get; set; }
        public string? TagReceiveBy { get; set; }
        public DateTime? TagIssueDt { get; set; }
        public string? TagIssueBy { get; set; }
        public int? StockDay { get; set; }
    }
}
