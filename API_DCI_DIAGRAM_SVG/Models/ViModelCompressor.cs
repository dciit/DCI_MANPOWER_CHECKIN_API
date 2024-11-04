using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViModelCompressor
    {
        public string? ModelName { get; set; }
        public string ModelCode { get; set; } = null!;
        public string? ModelType { get; set; }
        public string? ModelGroup { get; set; }
        public int? Line { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
