using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LogTransaction
    {
        public long Id { get; set; }
        public int? LtypeId { get; set; }
        public string? Ltable { get; set; }
        public string? Lfield { get; set; }
        public string? LtranId { get; set; }
        public string? ValuesBefore { get; set; }
        public string? ValuesAfter { get; set; }
        public string? OtherBefore { get; set; }
        public string? OtherAfter { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Remark { get; set; }
    }
}
