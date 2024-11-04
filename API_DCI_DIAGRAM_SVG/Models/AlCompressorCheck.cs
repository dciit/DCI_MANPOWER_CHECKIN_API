using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlCompressorCheck
    {
        public string? SerialNo { get; set; }
        public string? ModelName { get; set; }
        public string? Nwc { get; set; }
        public DateTime? Ndate { get; set; }
        public string? Fwc { get; set; }
        public DateTime? Fdate { get; set; }
        public string? Swc { get; set; }
        public DateTime? Sdate { get; set; }
        public string? Cwc { get; set; }
        public DateTime? Cdate { get; set; }
        public string? PalletNo { get; set; }
        public string? PalletType { get; set; }
        public string? Ln { get; set; }
        public string? Kno { get; set; }
    }
}
