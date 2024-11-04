using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViSupplierPartDelivery
    {
        public string? VdAddr { get; set; }
        public string? VdSort { get; set; }
        public string? PoNbr { get; set; }
        public string? PtPart { get; set; }
        public decimal DpQty { get; set; }
        public decimal? ReceiveQty { get; set; }
        public string? DoDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public int? ReceiveDiff { get; set; }
    }
}
