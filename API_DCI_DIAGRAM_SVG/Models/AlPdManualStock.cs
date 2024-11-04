using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPdManualStock
    {
        public string Ymd { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Desc1 { get; set; }
        public string Range { get; set; } = null!;
        public string? Route { get; set; }
        public string Wcno { get; set; } = null!;
        public string? Whum { get; set; }
        public int? Stkqty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Lrev { get; set; }
    }
}
