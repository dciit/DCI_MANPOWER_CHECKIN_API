using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPartTag
    {
        public string TagId { get; set; } = null!;
        public int? TagOrder { get; set; }
        public int? DpId { get; set; }
        public string? EinvNo { get; set; }
        public string? PtPart { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? TagQty { get; set; }
        public decimal? QtyOk { get; set; }
        public decimal? QtyNg { get; set; }
        public decimal? SamplingQty { get; set; }
        public decimal? SamplingOk { get; set; }
        public decimal? SamplingNg { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ReceiveBy { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? InspectBy { get; set; }
        public DateTime? InspectDate { get; set; }
        public string? Remark { get; set; }
    }
}
