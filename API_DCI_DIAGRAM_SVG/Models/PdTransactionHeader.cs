using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTransactionHeader
    {
        public string Trhdid { get; set; } = null!;
        public int? Pdid { get; set; }
        public string? ModelCode { get; set; }
        public decimal? QtyOk { get; set; }
        public decimal? QtyNg { get; set; }
        public string? Shift { get; set; }
        public DateTime? ShiftDate { get; set; }
        public string? Remark { get; set; }
        public DateTime? CollectDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
