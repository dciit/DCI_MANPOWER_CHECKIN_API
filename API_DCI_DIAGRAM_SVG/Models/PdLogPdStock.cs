using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdLogPdStock
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? DrawingNo { get; set; }
        public string? Location { get; set; }
        public int? Qty { get; set; }
        public string? Remark { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public string? StockLocation { get; set; }
        public string? StockBefore { get; set; }
        public string? StockAfter { get; set; }
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
