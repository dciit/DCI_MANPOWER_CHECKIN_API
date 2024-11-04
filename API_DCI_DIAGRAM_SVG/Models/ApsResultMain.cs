using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsResultMain
    {
        public string Wcno { get; set; } = null!;
        public DateTime Prddate { get; set; }
        public string Model { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createdate { get; set; }
        public decimal? ManualQuantity { get; set; }
    }
}
