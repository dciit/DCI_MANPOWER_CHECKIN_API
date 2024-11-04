using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTrhMotor
    {
        public string Trhid { get; set; } = null!;
        public string? ModelCode { get; set; }
        public int? Wip1Qty { get; set; }
        public int? Wip2Qty { get; set; }
        public int? TotalQty { get; set; }
        public int? QtyNg { get; set; }
        public string? Shift { get; set; }
        public DateTime? ShiftDate { get; set; }
        public string? LocationCode { get; set; }
        public string? MclineNo { get; set; }
        public string? Remark { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
