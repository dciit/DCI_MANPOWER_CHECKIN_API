using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhPalletNoMstr
    {
        public string PalletNo { get; set; } = null!;
        public string? PalletNoOld { get; set; }
        public string? PalletType { get; set; }
        public int? PalletFloor { get; set; }
        public int? PalletQty { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
