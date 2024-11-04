using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PtPackingBom
    {
        public long PtBomId { get; set; }
        public string? PtYear { get; set; }
        public string? PtMonth { get; set; }
        public int? PtRev { get; set; }
        public string? PtStatus { get; set; }
        public string? PtModelType { get; set; }
        public string PtModel { get; set; } = null!;
        public string? PtParent { get; set; }
        public string? PtIndex { get; set; }
        public string? PtSyn { get; set; }
        public int? PtLevel { get; set; }
        public string? PtTypedrawing { get; set; }
        public int? PtChildcount { get; set; }
        public string? PtCompo { get; set; }
        public string? PtDes { get; set; }
        public decimal? PtQty { get; set; }
        public string? PtUnit { get; set; }
        public DateTime? PtStartEff { get; set; }
        public DateTime? PtEndEff { get; set; }
        public string? PtIssue { get; set; }
        public DateTime? PtModDate { get; set; }
        public string? PtUserId { get; set; }
        public DateTime? PtUpdateDate { get; set; }
        public string? PtPuOrder { get; set; }
        /// <summary>
        /// Pallet Qty
        /// </summary>
        public string? PtRemark1 { get; set; }
        public string? PtRemark2 { get; set; }
        public string? PtRemark3 { get; set; }
        public string? PtRemark4 { get; set; }
        public string? PtRemark5 { get; set; }
    }
}
