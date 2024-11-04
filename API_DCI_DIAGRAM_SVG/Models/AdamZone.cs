using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdamZone
    {
        public int Adzid { get; set; }
        public int? Adcid { get; set; }
        public int? FactoryId { get; set; }
        public int? LocationId { get; set; }
        public int? ZoneId { get; set; }
        public int? ZoneGroupId { get; set; }
        public int? ColorNo { get; set; }
        public short? Active { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
