using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class StoreReceivePart
    {
        public int SrId { get; set; }
        public int? DpId { get; set; }
        public string? PtPart { get; set; }
        public int? AreaId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? RemainQty { get; set; }
        public int? SrStatus { get; set; }
        public string? Remark { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? FactoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ZoneId { get; set; }
        public int? ZoneGroupId { get; set; }
    }
}
