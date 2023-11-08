using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("MPCK_Object")]
    [Index(nameof(LayoutCode), Name = "IX_MPCK_Object")]
    [Index(nameof(EmpCode), nameof(LayoutCode), Name = "IX_MPCK_Object_1")]
    [Index(nameof(EmpCode), Name = "IX_MPCK_Object_2")]
    [Index(nameof(LayoutCode), nameof(ObjType), Name = "IX_MPCK_Object_3")]
    public partial class MpckObject
    {
        [Key]
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
        [Column("Obj_InsertDT", TypeName = "datetime")]
        public DateTime? ObjInsertDt { get; set; }
    }
}
