using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PtMstrStore
    {
        public string PtPart { get; set; } = null!;
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtUm { get; set; }
        public decimal? Stf11 { get; set; }
        public decimal? Stf22 { get; set; }
        public decimal? SafetyStock { get; set; }
        public decimal? MinStock { get; set; }
    }
}
