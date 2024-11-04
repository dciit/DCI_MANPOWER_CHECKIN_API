using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempStoreAreaReserveOrder
    {
        public int? DpId { get; set; }
        public string? EinvNo { get; set; }
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public int? AreaId { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? ReceiveQty { get; set; }
        public int? DpStatus { get; set; }
        public int? PpId { get; set; }
        public decimal? PpQty { get; set; }
        public short? StatusFinish { get; set; }
    }
}
