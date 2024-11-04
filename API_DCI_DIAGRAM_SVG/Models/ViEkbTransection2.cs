using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViEkbTransection2
    {
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? TransType { get; set; }
        public decimal? TransQty { get; set; }
        public string TimeRound { get; set; } = null!;
        public DateTime? ShiftDate { get; set; }
        public string Shifts { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string Ym { get; set; } = null!;
        public string? CreateBy { get; set; }
    }
}
