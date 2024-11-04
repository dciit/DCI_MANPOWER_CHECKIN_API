using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedStockIssueDetail
    {
        public string SiNo { get; set; } = null!;
        public string SiPart { get; set; } = null!;
        public string? SiPartName { get; set; }
        public string? SiPartDesc { get; set; }
        public string? SiLocation { get; set; }
        public decimal? SiQty { get; set; }
        public string? SiUm { get; set; }
    }
}
