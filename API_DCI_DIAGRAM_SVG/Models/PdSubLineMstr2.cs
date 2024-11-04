using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdSubLineMstr2
    {
        public string Model { get; set; } = null!;
        public int? CycleTime { get; set; }
        public string LineName { get; set; } = null!;
        public string BoardId { get; set; } = null!;
        public string? Fgpart { get; set; }
        public string Rm { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
