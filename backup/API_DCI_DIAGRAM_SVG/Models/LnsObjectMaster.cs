using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsObjectMaster
    {
        public int ObjId { get; set; }
        public string? ObjName { get; set; }
        public string? ObjType { get; set; }
        public string? ObjAxis { get; set; }
        public int? ObjW { get; set; }
        public int? ObjH { get; set; }
        public int? ObjR { get; set; }
        public string? ObjFill { get; set; }
        public string? ObjStrokeColor { get; set; }
        public int? ObjStrokeWidth { get; set; }
        public string? ObjSvg { get; set; }
    }
}
