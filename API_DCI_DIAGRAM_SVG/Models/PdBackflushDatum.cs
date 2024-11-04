using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdBackflushDatum
    {
        public string Wc { get; set; } = null!;
        public string Line { get; set; } = null!;
        public DateTime Pddate { get; set; }
        public string Shift { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Drawing { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Ch2 { get; set; }
        public string? Ch4 { get; set; }
        public string? Ch6 { get; set; }
        public string? Ch8 { get; set; }
        public string? Ch10 { get; set; }
        public string? Ch12 { get; set; }
        public string? Total { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PdbackflushStatus { get; set; }
        public int? LockEdit { get; set; }
        public string? HoldAccumulate { get; set; }
        public string? HoldDaily { get; set; }
        public string? HoldRemain { get; set; }
        public string? HoldDetail { get; set; }
        public string? Ngdaily { get; set; }
        public string? Ngdetail { get; set; }
    }
}
