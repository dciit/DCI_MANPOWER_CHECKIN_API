using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlScrapRequestSerialLog
    {
        public string? ReqYmd { get; set; }
        public string? ReqSht { get; set; }
        public string? Wcno { get; set; }
        public string? Docno { get; set; }
        public string SerialNo { get; set; } = null!;
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? InsertBy { get; set; }
    }
}
