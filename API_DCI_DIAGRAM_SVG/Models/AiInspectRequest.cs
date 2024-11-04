using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AiInspectRequest
    {
        public int InsId { get; set; }
        public string InspectNo { get; set; } = null!;
        public DateTime? InspectDate { get; set; }
        public string? InspectResult { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string Model { get; set; } = null!;
        public string PartNo { get; set; } = null!;
        public string? PartName { get; set; }
        public string? Dcilot { get; set; }
        public string? VendorCode { get; set; }
        public DateTime? SendDate { get; set; }
        public string? FilePathXls { get; set; }
        public string? FilePathPdf { get; set; }
        /// <summary>
        /// Status for Check Document (WAIT,CHECKED,APPROVED)
        /// </summary>
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Remark { get; set; }
        public string? RemarkCheck { get; set; }
    }
}
