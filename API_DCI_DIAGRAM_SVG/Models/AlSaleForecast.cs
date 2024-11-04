using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlSaleForecast
    {
        public string Ym { get; set; } = null!;
        public string DataType { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? Qty { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
