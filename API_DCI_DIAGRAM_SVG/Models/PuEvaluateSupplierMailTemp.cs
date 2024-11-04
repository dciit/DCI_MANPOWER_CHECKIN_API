using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuEvaluateSupplierMailTemp
    {
        public int MId { get; set; }
        public string Ym { get; set; } = null!;
        public string VenderCode { get; set; } = null!;
        public string? Buyer { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
