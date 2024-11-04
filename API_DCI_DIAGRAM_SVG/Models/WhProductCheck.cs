using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhProductCheck
    {
        public string Serial { get; set; } = null!;
        public string? Model { get; set; }
        public string? Plno { get; set; }
        public string? Pltype { get; set; }
        public string? Nwc { get; set; }
        public DateTime? Ndate { get; set; }
        public string? Fwc { get; set; }
        public DateTime? Fdate { get; set; }
        public DateTime? Cdate { get; set; }
        public string? Ctime { get; set; }
        public DateTime? Wdate { get; set; }
        public string? Wtime { get; set; }
        public string? Line { get; set; }
        public string? Prdtype { get; set; }
        public DateTime? Scandate { get; set; }
        public string? Scanstatus { get; set; }
    }
}
