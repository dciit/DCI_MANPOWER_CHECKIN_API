using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlSubmaterialMaster
    {
        public string Wcno { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public decimal? Qty { get; set; }
        public string Rev { get; set; } = null!;
        public DateTime? Createdate { get; set; }
        public string? Createby { get; set; }
    }
}
