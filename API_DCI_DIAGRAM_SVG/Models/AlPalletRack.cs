using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletRack
    {
        public string Qrcode { get; set; } = null!;
        public string? Plrno { get; set; }
        public string? Plrstatus { get; set; }
        public string? Pltype { get; set; }
        public string? Plcustomer { get; set; }
        public string? Uby { get; set; }
        public DateTime? Udate { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? FixedAsset { get; set; }
        public string? FixedAssetBy { get; set; }
        public DateTime? FixedAssetDate { get; set; }
    }
}
