using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPoDataTemp
    {
        public int Id { get; set; }
        public string? RunningCode { get; set; }
        public string? SupplierCode { get; set; }
        public DateTime? DoDate { get; set; }
        public string? DoTime { get; set; }
        public decimal? DoQty { get; set; }
        public decimal? PoRemain { get; set; }
        public string? PoNo { get; set; }
        public int? PoLine { get; set; }
        public string? PoItem { get; set; }
        public string? PoUnit { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Revision { get; set; }
        public string? Status { get; set; }
    }
}
