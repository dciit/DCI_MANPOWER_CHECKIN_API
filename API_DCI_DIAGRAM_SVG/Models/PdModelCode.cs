using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdModelCode
    {
        public string ModelCode { get; set; } = null!;
        public string? ModelName { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ModelType { get; set; }
        public string? Status { get; set; }
    }
}
