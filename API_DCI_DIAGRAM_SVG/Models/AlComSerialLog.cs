using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlComSerialLog
    {
        public string Nbr { get; set; } = null!;
        public string? SerialNo { get; set; }
        public string? FromWcno { get; set; }
        public string? ToWcno { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? DataBy { get; set; }
        public DateTime? DataDatetime { get; set; }
    }
}
