using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class BuildingCycleTimeLog
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string? BoardCode { get; set; }
        public double? CycleTime { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
