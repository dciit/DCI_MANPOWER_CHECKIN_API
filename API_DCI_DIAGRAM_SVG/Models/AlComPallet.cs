using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlComPallet
    {
        public string PlNo { get; set; } = null!;
        public string? Line { get; set; }
        public string? PackWcno { get; set; }
        public string? PlType { get; set; }
        public string? PlRack { get; set; }
        public int? PlQty { get; set; }
        public string? Model { get; set; }
        public string? PlFromWcno { get; set; }
        public string? PlToWcno { get; set; }
        public string? PackStatus { get; set; }
        public string? DataBy { get; set; }
        public DateTime? DataDatetime { get; set; }
    }
}
