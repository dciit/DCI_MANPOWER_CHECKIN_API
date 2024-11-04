using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWmsStkbal
    {
        public string Ymd { get; set; } = null!;
        public string Ym { get; set; } = null!;
        public string Wh { get; set; } = null!;
        public string Wc { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? Lbalstk { get; set; }
        public int? Instk { get; set; }
        public int? Outstk { get; set; }
        public int? Balstk { get; set; }
        public string? Remark { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime? Cdate { get; set; }
    }
}
