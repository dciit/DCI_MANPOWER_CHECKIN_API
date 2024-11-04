using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPartTagDetail
    {
        public int? DpId { get; set; }
        public string? PoNbr { get; set; }
        public string TagId { get; set; } = null!;
        public string? EinvNo { get; set; }
        public string? PtPart { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? ReceiveBy { get; set; }
        public decimal? TagQty { get; set; }
    }
}
