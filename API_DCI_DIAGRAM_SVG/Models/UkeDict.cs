using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UkeDict
    {
        public string DictType { get; set; } = null!;
        public string DictCode { get; set; } = null!;
        public string DictName { get; set; } = null!;
        public string? DictSubName { get; set; }
        public string DictRefCode { get; set; } = null!;
        public string DictUpdateBy { get; set; } = null!;
        public DateTime DictUpdateDate { get; set; }
    }
}
