using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViAlPalletRack
    {
        public string Qrcode { get; set; } = null!;
        public string? Plrno { get; set; }
        public string? Plrstatus { get; set; }
        public string? Pltype { get; set; }
        public string? Uby { get; set; }
        public DateTime? Udate { get; set; }
        public string Plcustomer { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string CustomerNameShort { get; set; } = null!;
        public string Plgrp { get; set; } = null!;
        public string Plqty { get; set; } = null!;
        public string Pllevel { get; set; } = null!;
        public string Remark1 { get; set; } = null!;
        public string Remark2 { get; set; } = null!;
        public string Remark3 { get; set; } = null!;
        public string? FixedAsset { get; set; }
        public string? FixedAssetBy { get; set; }
        public DateTime? FixedAssetDate { get; set; }
    }
}
