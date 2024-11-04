using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AreaDetial
    {
        public int AreaId { get; set; }
        public int? FactoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ZoneId { get; set; }
        public int? ZoneGroupId { get; set; }
        public string? ZoneNumber { get; set; }
        public decimal? Width { get; set; }
        public decimal? Long { get; set; }
        public decimal? Height { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
