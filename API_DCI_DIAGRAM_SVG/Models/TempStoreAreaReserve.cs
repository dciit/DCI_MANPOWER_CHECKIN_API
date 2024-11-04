using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempStoreAreaReserve
    {
        public long Id { get; set; }
        public long? DpId { get; set; }
        public string? EinvNo { get; set; }
        public int? AreaId { get; set; }
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public decimal? Qty { get; set; }
        public decimal? QtyBox { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
