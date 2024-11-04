using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoLog
    {
        public string? RunningCode { get; set; }
        public string? Partno { get; set; }
        public string? DateVal { get; set; }
        public double? PrevDo { get; set; }
        public double? Do { get; set; }
        public string? Status { get; set; }
        public DateTime? DtInsert { get; set; }
        public DateTime? DtUpdate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
