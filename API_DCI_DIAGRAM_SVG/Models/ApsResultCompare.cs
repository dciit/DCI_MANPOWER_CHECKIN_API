using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultCompare
    {
        public string Nbr { get; set; } = null!;
        public string? SaleOrderCode { get; set; }
        public int? PlanQty { get; set; }
        public int? ResuleQty { get; set; }
        public string? Lrev { get; set; }
        public string? Rev { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
