using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViEkbTransectionDataOutPd
    {
        public string Ym { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? TransType { get; set; }
        public decimal? TransQty { get; set; }
        public string? QrcodeData { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ShiftDate { get; set; }
        public string Shifts { get; set; } = null!;
    }
}
