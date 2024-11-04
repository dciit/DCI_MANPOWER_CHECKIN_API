using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasHoldScrap
    {
        public string ScrapId { get; set; } = null!;
        public string? ScrapSamplingMain { get; set; }
        public decimal? ScrapQty { get; set; }
        public string? ScrapDate { get; set; }
        public string? ScrapCby { get; set; }
        public DateTime? ScrapUdate { get; set; }
    }
}
