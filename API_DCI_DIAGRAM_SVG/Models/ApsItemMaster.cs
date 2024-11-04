using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsItemMaster
    {
        public string ItemNo { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string MainResource { get; set; } = null!;
        public string? ProcessName { get; set; }
        public decimal? CycleTime { get; set; }
    }
}
