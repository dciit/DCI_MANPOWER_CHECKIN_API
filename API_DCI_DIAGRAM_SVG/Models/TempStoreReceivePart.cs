using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempStoreReceivePart
    {
        public long TmpSrId { get; set; }
        public string? EinvNo { get; set; }
        public string? PtPart { get; set; }
        public int? AreaId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? QtyBox { get; set; }
        public short? Send { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
