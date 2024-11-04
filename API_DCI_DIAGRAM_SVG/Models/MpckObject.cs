using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class MpckObject
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
        public DateTime? ObjInsertDt { get; set; }
        public string? ObjPicture { get; set; }
        public int? ObjWidth { get; set; }
        public int? ObjHeight { get; set; }
        public string? ObjBackgroundColor { get; set; }
        public string? ObjBorderColor { get; set; }
        public int? ObjBorderWidth { get; set; }
        public int? ObjPriority { get; set; }
        public string? ObjPosition { get; set; }
        public int? ObjFontSize { get; set; }
        public string? ObjFontColor { get; set; }
    }
}
