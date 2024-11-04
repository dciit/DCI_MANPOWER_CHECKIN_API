using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPnCompessorCustomer
    {
        public string ModelCode { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? ModelType { get; set; }
        public string? ModelGroup { get; set; }
        public int Line { get; set; }
        public string? Status { get; set; }
        public string? CmAddr { get; set; }
        public string? CmSort { get; set; }
    }
}
