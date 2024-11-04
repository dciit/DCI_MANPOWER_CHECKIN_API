using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnSbu
    {
        public string Sbu { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string Rev { get; set; } = null!;
    }
}
