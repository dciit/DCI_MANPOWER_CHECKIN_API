using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdRawmatOrder
    {
        public string TmpNbr { get; set; } = null!;
        public DateTime? ServeTime { get; set; }
        public DateTime? ShortageTime { get; set; }
        public string? Andon { get; set; }
        public string? LocLoc { get; set; }
        public string? ModelCode { get; set; }
        public string? PtPart { get; set; }
        public decimal? SystemQty { get; set; }
        public decimal? PickedQty { get; set; }
        public decimal? ConfirmQty { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? PickedBy { get; set; }
        public DateTime? PickedDate { get; set; }
        public string? ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }
    }
}
