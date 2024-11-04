using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPlPalletRack
    {
        public string Qrcode { get; set; } = null!;
        public string Qrcodea { get; set; } = null!;
        public string Qrcodeb { get; set; } = null!;
        public string? Plrno { get; set; }
        public string? Plrstatus { get; set; }
        public string? Pltype { get; set; }
        public string? CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string? Uby { get; set; }
        public DateTime? Udate { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
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
