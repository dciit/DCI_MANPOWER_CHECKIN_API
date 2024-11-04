using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlFgSerial
    {
        public long Id { get; set; }
        public string SerialNo { get; set; } = null!;
        public string? Model { get; set; }
        public string? Line { get; set; }
        public string? Pdt { get; set; }
        public string? Unw { get; set; }
        public string? Rwe { get; set; }
        public string? Rwd { get; set; }
        public string? Rwq { get; set; }
        public string? Dci { get; set; }
        public string? P01 { get; set; }
        public string? Rpk { get; set; }
        public string? Hwh { get; set; }
        public string? PreviousWc { get; set; }
        public string? CurrentWc { get; set; }
        public string? CurrentWcDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
