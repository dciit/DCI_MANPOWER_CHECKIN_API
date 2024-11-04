using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnTransLineModel
    {
        public int Id { get; set; }
        public string? ProductionLine { get; set; }
        public string? ModelCode { get; set; }
        public string? Model { get; set; }
    }
}
