using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdReceiveStockMotorLog
    {
        public int Id { get; set; }
        public string? TagId { get; set; }
        public string? Model { get; set; }
        public string? Drawing { get; set; }
        public int? Qty { get; set; }
        public string? LocationCode { get; set; }
        public string? Remark01 { get; set; }
        public string? Remark02 { get; set; }
        public string? Remark03 { get; set; }
        public string? Remark04 { get; set; }
        public string? Remark05 { get; set; }
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
