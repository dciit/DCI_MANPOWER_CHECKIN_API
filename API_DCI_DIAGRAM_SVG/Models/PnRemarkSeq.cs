using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnRemarkSeq
    {
        public string? Model { get; set; }
        public string? ModelCode { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string? Remark { get; set; }
        public string? Status { get; set; }
    }
}
