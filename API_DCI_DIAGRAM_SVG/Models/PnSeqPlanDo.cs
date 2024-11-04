using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnSeqPlanDo
    {
        public long SeqId { get; set; }
        public string Model { get; set; } = null!;
        public string? ModelCode { get; set; }
        public string? Line { get; set; }
        public string? Seq { get; set; }
        public int? Revision { get; set; }
        public int? RevisionSeq { get; set; }
        public DateTime SeqDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? PlanPd { get; set; }
        public int? Actual { get; set; }
        public string? ModelCustomer { get; set; }
        public string? PackingDetail { get; set; }
        public string? PalletDetail { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Rmk1 { get; set; }
        public string? Rmk2 { get; set; }
        /// <summary>
        /// detail Seq of 1YC such as FMT, Test 
        /// </summary>
        public string? Rmk3 { get; set; }
        public string? Rmk4 { get; set; }
        public string? Rmk5 { get; set; }
        public string Status { get; set; } = null!;
    }
}
