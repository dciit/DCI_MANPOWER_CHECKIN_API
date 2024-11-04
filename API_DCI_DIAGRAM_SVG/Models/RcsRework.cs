using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RcsRework
    {
        public string NbrRework { get; set; } = null!;
        public string PipeNo { get; set; } = null!;
        public string? Line { get; set; }
        public string? ModelCode { get; set; }
        public string? Model { get; set; }
        public string? InBy { get; set; }
        public DateTime? InDate { get; set; }
        public string? OutBy { get; set; }
        public DateTime? OutDate { get; set; }
        public string? ReworkStatus { get; set; }
        public string? ReworkLine { get; set; }
    }
}
