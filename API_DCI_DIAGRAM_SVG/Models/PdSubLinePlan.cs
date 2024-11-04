using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdSubLinePlan
    {
        public string PnNbr { get; set; } = null!;
        public string? WorkCenter { get; set; }
        public string? Andon { get; set; }
        public string? LocLoc { get; set; }
        public DateTime? DataDate { get; set; }
        public string? Shift { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Sequense { get; set; }
        public string? ModelCode { get; set; }
        public string? RmDwg { get; set; }
        public string? FgDwg { get; set; }
        public int? CycleTime { get; set; }
        public decimal? PlanQty { get; set; }
        public decimal? BomUsage { get; set; }
        public decimal? RmQty { get; set; }
        public decimal? RmHoldQty { get; set; }
        public decimal? RmNgqty { get; set; }
        public decimal? FgQty { get; set; }
        public decimal? FgHoldQty { get; set; }
        public decimal? FgHoldOkqty { get; set; }
        public decimal? FgHoldNgqty { get; set; }
        public decimal? FgNgqty { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Status { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? Remark4 { get; set; }
        public string? Remark5 { get; set; }
    }
}
