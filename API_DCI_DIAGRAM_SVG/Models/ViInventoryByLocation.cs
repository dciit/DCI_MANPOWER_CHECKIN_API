using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViInventoryByLocation
    {
        public string? Location { get; set; }
        public string? Site { get; set; }
        public string? ItemNumber { get; set; }
        public string? InventoryStatus { get; set; }
        public decimal? QuantityOnHand { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Remark { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtUm { get; set; }
    }
}
