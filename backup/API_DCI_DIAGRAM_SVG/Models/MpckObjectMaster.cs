using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class MpckObjectMaster
    {
        public string ObjMasterId { get; set; } = null!;
        public string? MstName { get; set; }
        public string? ObjSvg { get; set; }
        public string? MstStatus { get; set; }
        public int? MstOrder { get; set; }
    }
}
