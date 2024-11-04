using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DictRc
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public string? Desc1 { get; set; }
        public string? Desc2 { get; set; }
        public string? Desc3 { get; set; }
        public int? Int1 { get; set; }
        public int? Int2 { get; set; }
        public decimal? Decimal1 { get; set; }
        public decimal? Decimal2 { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public bool? Bool1 { get; set; }
        public bool? Bool2 { get; set; }
    }
}
