using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlStdcost
    {
        public string Fisy { get; set; } = null!;
        public string Pdtype { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Costtype { get; set; } = null!;
        public decimal? Amount { get; set; }
        public string? Remark { get; set; }
    }
}
