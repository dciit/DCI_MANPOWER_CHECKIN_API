using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletRackLog
    {
        public string Nbr { get; set; } = null!;
        public string? Qrcode { get; set; }
        public string? Plrno { get; set; }
        public string? Plrstatus { get; set; }
        public string? Pltype { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
