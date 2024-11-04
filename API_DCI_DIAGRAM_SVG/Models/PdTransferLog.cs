using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTransferLog
    {
        public int Id { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public string? Model { get; set; }
        public string? DrawingNo { get; set; }
        public decimal? Qty { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? Remark4 { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
