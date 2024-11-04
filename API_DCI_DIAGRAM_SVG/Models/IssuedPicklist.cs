using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedPicklist
    {
        public string PicklistCode { get; set; } = null!;
        /// <summary>
        /// Request number of picklist in qad.
        /// </summary>
        public string? QadNbr { get; set; }
        public string? RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? RequestTime { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ReceiveBy { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? AcceptRequestBy { get; set; }
        public DateTime? AcceptRequestDate { get; set; }
        public string? SenderBy { get; set; }
        public DateTime? SenderDate { get; set; }
        public int? Status { get; set; }
        public string? RequestLoc { get; set; }
        public string? RequestShift { get; set; }
        public string? RequestCostcenter { get; set; }
        public string? RequestLine { get; set; }
        public string? SourceLine { get; set; }
        public string? SourceLoc { get; set; }
        public string? SourceWorkCenter { get; set; }
        public string? DesctLine { get; set; }
        public string? DesctLoc { get; set; }
        public string? DesctWorkCenter { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? RequestType { get; set; }
        public string? RequestWorkCenter { get; set; }
    }
}
