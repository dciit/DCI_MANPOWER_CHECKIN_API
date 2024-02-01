using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class MpckDictionary
    {
        public string DictType { get; set; } = null!;
        public string DictCode { get; set; } = null!;
        public string? DictName { get; set; }
        public string? DictSubName { get; set; }
        public string DictRefCode { get; set; } = null!;
        public string? DictRefName { get; set; }
        public string? DictRefSubName { get; set; }
        public string? DictRefCode2 { get; set; }
    }
}
