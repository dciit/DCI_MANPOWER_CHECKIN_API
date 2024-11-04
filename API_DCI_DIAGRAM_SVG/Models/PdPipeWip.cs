using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdPipeWip
    {
        public string? PipeNumber { get; set; }
        public string? ModelNo { get; set; }
        public string? LocationNo { get; set; }
        public DateTime? Mfgdate { get; set; }
        public string? Remark { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
