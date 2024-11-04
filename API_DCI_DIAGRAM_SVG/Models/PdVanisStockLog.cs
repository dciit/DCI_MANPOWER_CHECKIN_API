using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdVanisStockLog
    {
        public string Id { get; set; } = null!;
        public string? PartName { get; set; }
        public string? Model { get; set; }
        public string? DrawingNo { get; set; }
        public int? Qty { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string? Shift { get; set; }
        public string? MatGrade { get; set; }
        public string? LabelSlit { get; set; }
        public string? CheckBy { get; set; }
        public string? StatusUse { get; set; }
        public DateTime? PrintDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
