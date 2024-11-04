using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTrdPipe
    {
        public string Trdid { get; set; } = null!;
        public string? Trhid { get; set; }
        public string? SerialNumber { get; set; }
        public string? WipLocation { get; set; }
        public int? MclineNo { get; set; }
        public string? PartStatus { get; set; }
        public string? Remark { get; set; }
        public DateTime? Mfgdate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
