using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPartTagTemp
    {
        public string TmpTagId { get; set; } = null!;
        public string? TmpPtPart { get; set; }
        public int? TmpTagOrder { get; set; }
        public string? MfgLotNo { get; set; }
        public DateTime? MfgDate { get; set; }
        public decimal? TmpPckQty { get; set; }
        public decimal? TmpQty { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? TmpStatus { get; set; }
    }
}
