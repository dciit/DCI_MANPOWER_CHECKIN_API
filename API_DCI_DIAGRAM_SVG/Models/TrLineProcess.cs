using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class TrLineProcess
    {
        public string ProcCode { get; set; } = null!;
        public string? ProcType { get; set; }
        public string? Factory { get; set; }
        public string? Line { get; set; }
        public string? SubLine { get; set; }
        public string? ProcessCode { get; set; }
        public string? ProcessName { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
