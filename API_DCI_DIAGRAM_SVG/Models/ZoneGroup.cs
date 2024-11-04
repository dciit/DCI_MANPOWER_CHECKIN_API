using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ZoneGroup
    {
        public int ZoneGroupId { get; set; }
        public string? ZoneGroupShortName { get; set; }
        public string? ZoneGroupName { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
