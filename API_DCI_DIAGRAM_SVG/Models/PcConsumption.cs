using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PcConsumption
    {
        public string Ymd { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Vender { get; set; }
        public decimal? M01 { get; set; }
        public decimal? M02 { get; set; }
        public decimal? M03 { get; set; }
        public decimal? M04 { get; set; }
        public decimal? M05 { get; set; }
        public decimal? M06 { get; set; }
        public decimal? M07 { get; set; }
        public decimal? M08 { get; set; }
        public decimal? M09 { get; set; }
        public decimal? M10 { get; set; }
        public decimal? M11 { get; set; }
        public decimal? M12 { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
