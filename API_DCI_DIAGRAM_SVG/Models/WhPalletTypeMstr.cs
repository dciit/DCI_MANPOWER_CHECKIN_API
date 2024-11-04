using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhPalletTypeMstr
    {
        public string PalletType { get; set; } = null!;
        public int? PalletCapacity { get; set; }
        public int? PalletFloor { get; set; }
        public string? PalletStatus { get; set; }
        public string? PalletModelUse { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
