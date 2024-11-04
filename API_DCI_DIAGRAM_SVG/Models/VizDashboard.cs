using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VizDashboard
    {
        public string DataType { get; set; } = null!;
        public string Fisy { get; set; } = null!;
        public string Ymd { get; set; } = null!;
        public decimal? DataValue { get; set; }
        public string? UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
