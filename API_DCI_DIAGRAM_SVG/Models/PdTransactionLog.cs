using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTransactionLog
    {
        public string TranId { get; set; } = null!;
        public string? TableName { get; set; }
        public string? EventType { get; set; }
        public string? FieldTarget { get; set; }
        public string? ValueBefore { get; set; }
        public string? ValueAfter { get; set; }
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
