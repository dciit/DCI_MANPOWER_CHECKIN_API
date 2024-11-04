using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuSubContractId
    {
        public int RunningNo { get; set; }
        public string? ItemNumber { get; set; }
        public string? Site { get; set; }
        public string? WorkOrderId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ChildPart { get; set; }
        public string? ChildLocation { get; set; }
        public decimal? ChildQty { get; set; }
        public string? ChildUm { get; set; }
    }
}
