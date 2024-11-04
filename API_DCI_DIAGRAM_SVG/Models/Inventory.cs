using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Inventory
    {
        public int InvId { get; set; }
        public int? AreaId { get; set; }
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public decimal? Qty { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? FactoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ZoneId { get; set; }
        public int? ZoneGroupId { get; set; }
    }
}
