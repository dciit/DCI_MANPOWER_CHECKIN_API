using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletPermission
    {
        public string EmpCode { get; set; } = null!;
        public string? ScanWh { get; set; }
        public string? ScanKaizen { get; set; }
        public string? ScanPack { get; set; }
        public string? EditRack { get; set; }
    }
}
