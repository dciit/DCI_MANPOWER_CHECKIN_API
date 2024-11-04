using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class QualEmg
    {
        public int QualEmgId { get; set; }
        public string? Fy { get; set; }
        public DateTime? LastClaim { get; set; }
        public string? DetailClaim { get; set; }
        public string? EmployeeName { get; set; }
        public int? ComCase { get; set; }
        public int? ComUnit { get; set; }
        public int? ComPpm { get; set; }
        public string? ComAct { get; set; }
        public int? ComActPpm { get; set; }
        public int? ComTarget { get; set; }
        public int? OdmCase { get; set; }
        public int? OdmUnit { get; set; }
        public int? OdmPpm { get; set; }
        public string? OdmAct { get; set; }
        public int? OdmActPpm { get; set; }
        public int? OdmTarget { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
    }
}
