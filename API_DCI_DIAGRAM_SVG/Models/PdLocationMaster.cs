using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdLocationMaster
    {
        public string LocationId { get; set; } = null!;
        public string? QadLocationId { get; set; }
        public string? AndonLineId { get; set; }
    }
}
