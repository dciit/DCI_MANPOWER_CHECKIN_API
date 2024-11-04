using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartResultTransactionLog
    {
        public string Wcno { get; set; } = null!;
        public string LineType { get; set; } = null!;
        public string SerialNo { get; set; } = null!;
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public DateTime? PrdDate { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
