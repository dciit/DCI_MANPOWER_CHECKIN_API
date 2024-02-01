using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViMpckObjectList
    {
        public string ObjCode { get; set; } = null!;
        public string? LayoutCode { get; set; }
        public string? ObjMasterId { get; set; }
        public string? ObjType { get; set; }
        public string? ObjTitle { get; set; }
        public string? ObjSubtitle { get; set; }
        public string? ObjPath { get; set; }
        public double? ObjX { get; set; }
        public double? ObjY { get; set; }
        public string? ObjStatus { get; set; }
        public string? EmpCode { get; set; }
        public DateTime? ObjLastCheckDt { get; set; }
        public string? LayoutName { get; set; }
        public string? LayoutSubName { get; set; }
        public string? Factory { get; set; }
        public string? Line { get; set; }
        public string? SubLine { get; set; }
        public string? LayoutStatus { get; set; }
        public string? BypassMq { get; set; }
        public string? BypassSa { get; set; }
        public string Ot { get; set; } = null!;
        public string Mq { get; set; } = null!;
        public string Sa { get; set; } = null!;
        public string EmpImage { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public int? MstOrder { get; set; }
        public string? ObjSvg { get; set; }
    }
}
