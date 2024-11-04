using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViStoreReceiptDatum
    {
        public DateTime? ReceiptDate { get; set; }
        public string? ReceiptNo { get; set; }
        public string? DciLotNo { get; set; }
        public string? Receiver { get; set; }
        public string? PtPart { get; set; }
        public decimal? Qty { get; set; }
        public string? Um { get; set; }
        public string? Location { get; set; }
        public string? Qadstatus { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? StoreDate { get; set; }
        public string? Einvoice { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public int SrId { get; set; }
    }
}
