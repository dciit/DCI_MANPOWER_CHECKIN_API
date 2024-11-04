using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WkOutsidestk
    {
        public string Pid { get; set; } = null!;
        public string Ym { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string? Partname { get; set; }
        public string Vender { get; set; } = null!;
        public decimal? Aprice { get; set; }
        public decimal? Stdcost { get; set; }
        public decimal? Lbalqty { get; set; }
        public decimal? Inqty { get; set; }
        public decimal? Outqty { get; set; }
        public string? Remark { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updatedate { get; set; }
        public DateTime? LastReceive { get; set; }
        public DateTime? LastIssue { get; set; }
    }
}
