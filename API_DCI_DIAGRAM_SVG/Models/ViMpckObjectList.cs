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
        [StringLength(20)]
        public string ObjCode { get; set; } = null!;
        [StringLength(20)]
        public string? LayoutCode { get; set; }
        [Column("Obj_MasterID")]
        [StringLength(20)]
        public string? ObjMasterId { get; set; }
        [Column("Obj_Type")]
        [StringLength(10)]
        public string? ObjType { get; set; }
        [Column("Obj_Title")]
        [StringLength(50)]
        public string? ObjTitle { get; set; }
        [Column("Obj_Subtitle")]
        [StringLength(200)]
        public string? ObjSubtitle { get; set; }
        [Column("Obj_Path", TypeName = "text")]
        public string? ObjPath { get; set; }
        [Column("Obj_X")]
        public double? ObjX { get; set; }
        [Column("Obj_Y")]
        public double? ObjY { get; set; }
        [Column("Obj_Status")]
        [StringLength(10)]
        public string? ObjStatus { get; set; }
        [StringLength(5)]
        public string? EmpCode { get; set; }
        [Column("Obj_LastCheckDT", TypeName = "datetime")]
        public DateTime? ObjLastCheckDt { get; set; }
        [StringLength(50)]
        public string? LayoutName { get; set; }
        [StringLength(100)]
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
        [StringLength(5)]
        [Unicode(false)]
        public string Ot { get; set; } = null!;
        [Column("MQ")]
        [StringLength(5)]
        [Unicode(false)]
        public string Mq { get; set; } = null!;
        [Column("SA")]
        [StringLength(5)]
        [Unicode(false)]
        public string Sa { get; set; } = null!;
        [StringLength(54)]
        public string EmpImage { get; set; } = null!;
        [StringLength(202)]
        public string EmpName { get; set; } = null!;
        [Column("Mst_Order")]
        public int? MstOrder { get; set; }
        [Column("OBJ_SVG", TypeName = "text")]
        public string? ObjSvg { get; set; }
        [Column("Obj_Picture")]
        [StringLength(200)]
        public string ObjPicture { get; set; }

        [Column("Obj_Width")]
        public int ObjWidth { get; set; }

        [Column("Obj_Height")]
        public int ObjHeight { get; set; }

        [Column("Obj_BackgroundColor")]
        [StringLength(10)]
        public string ObjBackgroundColor { get; set; }
        [Column("Obj_BorderColor")]
        [StringLength(10)]
        public string ObjBorderColor { get; set; }

        [Column("Obj_Priority")]
        public int? ObjPriority { get; set; }
        [Column("Obj_Position")]
        [StringLength(10)]
        public string? ObjPosition { get; set; }
    }
}
