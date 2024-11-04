using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class InventoryOnHand
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public string? Site { get; set; }
        public string? ItemNumber { get; set; }
        public string? InventoryStatus { get; set; }
        public decimal? QuantityOnHand { get; set; }
        public decimal? MinStock { get; set; }
        public decimal? MaxStock { get; set; }
        public decimal? SafetyStock { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Remark { get; set; }
    }
}
