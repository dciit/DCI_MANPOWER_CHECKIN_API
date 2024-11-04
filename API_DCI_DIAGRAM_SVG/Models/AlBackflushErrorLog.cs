using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlBackflushErrorLog
    {
        public long Nbr { get; set; }
        public DateTime? LogDate { get; set; }
        public string? ErrorQuery { get; set; }
    }
}
