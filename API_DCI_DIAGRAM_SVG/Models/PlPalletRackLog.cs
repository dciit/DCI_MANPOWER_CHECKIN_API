using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PlPalletRackLog
    {
        public string Nbr { get; set; } = null!;
        public string? Qrcode { get; set; }
        public string? Plrno { get; set; }
        public string? Pltype { get; set; }
        public string? FromPlrstatus { get; set; }
        public string? ToPlrstatus { get; set; }
        public string? CrBy { get; set; }
        public DateTime? CrDate { get; set; }
    }
}
