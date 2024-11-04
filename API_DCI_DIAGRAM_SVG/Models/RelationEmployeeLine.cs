using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class RelationEmployeeLine
    {
        public string Code { get; set; } = null!;
        public string? LnLine { get; set; }
        public string? LocLoc { get; set; }
        public string? WcWkctr { get; set; }
        public string? AllowLoc { get; set; }
        public string? AllowLine { get; set; }
        public string? PdModel { get; set; }
        public string? PdType { get; set; }
        public string? PdModelAllow { get; set; }
    }
}
