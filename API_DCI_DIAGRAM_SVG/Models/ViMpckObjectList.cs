using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Keyless]
    public partial class ViMpckObjectList
    {
        [Column("Obj_Code")]
        [StringLength(50)]
        public string ObjCode { get; set; } = null!;
        [StringLength(50)]
        public string? LayoutCode { get; set; }
        [Column("Obj_MasterID")]
        [StringLength(50)]
        public string? ObjMasterId { get; set; }
        [Column("Obj_Type")]
        [StringLength(50)]
        public string? ObjType { get; set; }
        [Column("Obj_Title")]
        [StringLength(50)]
        public string? ObjTitle { get; set; }
        [Column("Obj_Subtitle")]
        [StringLength(50)]
        public string? ObjSubtitle { get; set; }
        [Column("Obj_Path")]
        [StringLength(50)]
        public string? ObjPath { get; set; }
        [Column("Obj_X")]
        [StringLength(10)]
        public string? ObjX { get; set; }
        [Column("Obj_Y")]
        [StringLength(10)]
        public string? ObjY { get; set; }
        [Column("Obj_Status")]
        [StringLength(10)]
        public string? ObjStatus { get; set; }
        [StringLength(10)]
        public string? EmpCode { get; set; }
        [Column("Obj_LastCheckDT", TypeName = "datetime")]
        public DateTime? ObjLastCheckDt { get; set; }
        [StringLength(50)]
        public string? LayoutName { get; set; }
        [StringLength(50)]
        public string? LayoutSubName { get; set; }
        [StringLength(10)]
        public string? Factory { get; set; }
        [StringLength(10)]
        public string? Line { get; set; }
        [StringLength(20)]
        public string? SubLine { get; set; }
        [StringLength(10)]
        public string? LayoutStatus { get; set; }
        [Column("BypassMQ")]
        [StringLength(10)]
        public string? BypassMq { get; set; }
        [Column("BypassSA")]
        [StringLength(10)]
        public string? BypassSa { get; set; }
        [Column("OT")]
        [StringLength(10)]
        [Unicode(false)]
        public string Ot { get; set; } = null!;
        [Column("MQ")]
        [StringLength(10)]
        [Unicode(false)]
        public string Mq { get; set; } = null!;
        [Column("SA")]
        [StringLength(10)]
        [Unicode(false)]
        public string Sa { get; set; } = null!;
        [Column("EmpImage")]
        [StringLength(200)]
        [Unicode(false)]
        public string EmpImage { get; set; } = null!;
    }
}
