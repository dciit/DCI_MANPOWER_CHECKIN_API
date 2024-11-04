using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViReceivingItem
    {
        public string? PartName { get; set; }
        public decimal DpQty { get; set; }
        public int DpStatus { get; set; }
        public string? StatusName { get; set; }
        public string? RndInvno { get; set; }
        public string? PartNo { get; set; }
        public decimal? ReceiptQty { get; set; }
        public DateTime? UpdateQty { get; set; }
        public string? Description { get; set; }
        public string PoNbr { get; set; } = null!;
        public string Invoice { get; set; } = null!;
        public string? Remark { get; set; }
        public bool? DataVendor { get; set; }
        public bool? PackageComplete { get; set; }
        public string? LotType { get; set; }
    }
}
