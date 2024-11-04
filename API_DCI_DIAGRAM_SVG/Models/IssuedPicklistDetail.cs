using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedPicklistDetail
    {
        /// <summary>
        /// number of packing set.
        /// </summary>
        public string PicklistDetailCode { get; set; } = null!;
        public string PicklistCode { get; set; } = null!;
        public int? ItemLine { get; set; }
        public string? PtPart { get; set; }
        public string? QadNbr { get; set; }
        /// <summary>
        /// data of packing set
        /// </summary>
        public decimal? CurrentPrice { get; set; }
        public decimal? RequestQty { get; set; }
        public string? Um { get; set; }
        public string? Costcerter { get; set; }
        public string? PtStatus { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Remark { get; set; }
        public int? RequestStatus { get; set; }
        public decimal? QtyOpen { get; set; }
        /// <summary>
        /// columns for record confirm send r/m to production.
        /// </summary>
        public decimal? QtyAllow { get; set; }
        public decimal? QtyPick { get; set; }
        public decimal? QtyIssue { get; set; }
        public string? RequestType { get; set; }
        public string? RequestLine { get; set; }
        public string? RequestLoc { get; set; }
        /// <summary>
        /// data of packing bom qty
        /// </summary>
        public string? RequestCostcenter { get; set; }
        public string? RequestWorkCenter { get; set; }
        public string? SourceLine { get; set; }
        public string? SourceLoc { get; set; }
        public string? SourceWorkCenter { get; set; }
    }
}
