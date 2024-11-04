using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlAuthDvcd
    {
        public string Dvcd { get; set; } = null!;
        public string DvType { get; set; } = null!;
        public string AlGroupId { get; set; } = null!;
        public string? UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string? AuthStatus { get; set; }
    }
}
