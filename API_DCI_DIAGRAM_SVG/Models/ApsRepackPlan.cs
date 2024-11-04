using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsRepackPlan
    {
        public string PlnDate { get; set; } = null!;
        public string PlnModelCode { get; set; } = null!;
        public string? PlnModel { get; set; }
        public string PlnPltype { get; set; } = null!;
        public decimal? PlnQty { get; set; }
        public decimal? PlnQtyPallent { get; set; }
        public string? PlnRemark { get; set; }
        public string? PlnStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
