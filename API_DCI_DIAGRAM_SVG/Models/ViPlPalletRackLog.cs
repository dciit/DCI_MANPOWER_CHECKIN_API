using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPlPalletRackLog
    {
        public string Nbr { get; set; } = null!;
        public string? Qrcode { get; set; }
        public string? Plrno { get; set; }
        public string? Pltype { get; set; }
        public string? FromPlrstatus { get; set; }
        public string? ToPlrstatus { get; set; }
        public string? CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string? Qrcodea { get; set; }
        public string? Qrcodeb { get; set; }
        public string? FixedAsset { get; set; }
        public string? Asdate { get; set; }
        public string? Asname { get; set; }
        public string? Asamt { get; set; }
        public string? Ascode { get; set; }
        public string? Invo { get; set; }
        public string? VdCode { get; set; }
        public string? VdName { get; set; }
    }
}
