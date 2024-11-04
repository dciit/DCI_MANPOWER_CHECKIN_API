using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PartLocation
    {
        public int PartLocationId { get; set; }
        public int? AreaId { get; set; }
        public int? PpId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? QtyBox { get; set; }
        public short? Active { get; set; }
        public short? CommonArea { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? FactoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ZoneId { get; set; }
        public int? ZoneGroupId { get; set; }
    }
}
