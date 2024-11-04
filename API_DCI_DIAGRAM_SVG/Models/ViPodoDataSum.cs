using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPodoDataSum
    {
        public string? SupplierCode { get; set; }
        public DateTime? DoDate { get; set; }
        public string? PoItem { get; set; }
        public decimal? DoQty { get; set; }
    }
}
