using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TempStoreAreaReserveTag
    {
        public int? DpId { get; set; }
        public int? ReserveId { get; set; }
        public string? TagId { get; set; }
        public int? AreaId { get; set; }
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public string? EinvNo { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? TagQty { get; set; }
        public short? ReceiveStatus { get; set; }
    }
}
