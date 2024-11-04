using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultCompareLog
    {
        public string Nbr { get; set; } = null!;
        public string? SaleOrderCode { get; set; }
        public string? Pddate { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public int? Quantity { get; set; }
    }
}
