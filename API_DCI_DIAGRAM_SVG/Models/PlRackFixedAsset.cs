using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PlRackFixedAsset
    {
        public string Asno { get; set; } = null!;
        public string Asdate { get; set; } = null!;
        public string Asname { get; set; } = null!;
        public string? Asamt { get; set; }
        public string? Ascode { get; set; }
        public string? Invo { get; set; }
        public string? VdCode { get; set; }
        public string? VdName { get; set; }
    }
}
