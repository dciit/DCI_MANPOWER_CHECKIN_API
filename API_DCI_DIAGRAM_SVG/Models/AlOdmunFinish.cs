using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlOdmunFinish
    {
        public string SerialNo { get; set; } = null!;
        public string? Model { get; set; }
        public string? Line { get; set; }
        public string? Nwc { get; set; }
        public string? Ndate { get; set; }
        public string? Fwc { get; set; }
        public string? Fdate { get; set; }
        public string? Plno { get; set; }
        public string? Pltype { get; set; }
        public string? Cwc { get; set; }
        public string? Cdate { get; set; }
        public string? Ctime { get; set; }
        public string? Kno { get; set; }
        public string? Prdtype { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
