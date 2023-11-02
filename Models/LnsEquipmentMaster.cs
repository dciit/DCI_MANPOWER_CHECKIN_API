using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsEquipmentMaster
    {
        public string ObjId { get; set; } = null!;
        public string? ObjName { get; set; }
        public int? ObjW { get; set; }
        public int? ObjH { get; set; }
        public string? ObjSvg { get; set; }
        public int? ObjMstNextDay { get; set; }
        public int? ObjMstNextMonth { get; set; }
        public int? ObjMstNextYear { get; set; }
    }
}
