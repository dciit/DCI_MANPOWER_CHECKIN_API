using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsEquipment
    {
        public int EqpPriority { get; set; }
        public string EqpId { get; set; } = null!;
        public string? LayoutCode { get; set; }
        public string? ObjId { get; set; }
        public string? EqpTitle { get; set; }
        public string? EqpSubTitle { get; set; }
        public double? EqpX { get; set; }
        public double? EqpW { get; set; }
        public double? EqpY { get; set; }
        public double? EqpH { get; set; }
        public string? EqpStatus { get; set; }
        public string? Layout { get; set; }
        public string? Factory { get; set; }
        public DateTime? EqpNextCheckDt { get; set; }
        public DateTime? EqpLastCheckDt { get; set; }
        public string? EqpLastCheckBy { get; set; }
        public string? EqpRemark { get; set; }
        public DateTime? EqpStartCheckDt { get; set; }
        public int? ObjMstNextDay { get; set; }
        public int? ObjMstNextMonth { get; set; }
        public int? ObjMstNextYear { get; set; }
        public int? EqpTrigger { get; set; }
        public double? EqpScale { get; set; }
        public int? EqpRotate { get; set; }
    }
}
