using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasWipSamplingTransferLog
    {
        public string Nbr { get; set; } = null!;
        public DateTime? Pddate { get; set; }
        public string? Shift { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public string? Drawing { get; set; }
        public string? Cm { get; set; }
        public string? BackflushQty { get; set; }
        public string? JudegementResult { get; set; }
        public int? JudegementQty { get; set; }
        public string? DocNo { get; set; }
        public string? RefNo { get; set; }
        public string? FromWcno { get; set; }
        public string? ToWcno { get; set; }
        public string? TransQty { get; set; }
        public string? AccuTransQty { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
