using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPicklistDetail
    {
        public string? QadNbr { get; set; }
        public string? RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? RequestTime { get; set; }
        public string? RequestShift { get; set; }
        public string? RequestLine { get; set; }
        public string? RequestWorkCenter { get; set; }
        public string? RequestCostcenter { get; set; }
        public string? RequestLoc { get; set; }
        public int? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ItemLine { get; set; }
        public string? PtPart { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public decimal? RequestQty { get; set; }
        public string? Um { get; set; }
        public string? SourceLoc { get; set; }
        public decimal? QtyIssue { get; set; }
        public decimal? QtyPick { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? RequestStatus { get; set; }
        public string? LnDesc { get; set; }
        public string? Remark { get; set; }
    }
}
