using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("LNS_Equipment")]
    public partial class LnsEquipment
    {
        [Column("EQP_PRIORITY")]
        public int EqpPriority { get; set; }
        [Key]
        [Column("EQP_ID")]
        [StringLength(50)]
        public string EqpId { get; set; } = null!;
        [Column("LAYOUT_CODE")]
        [StringLength(50)]
        public string? LayoutCode { get; set; }
        [Column("OBJ_ID")]
        [StringLength(50)]
        public string? ObjId { get; set; }
        [Column("EQP_Title")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EqpTitle { get; set; }
        [Column("EQP_SubTitle")]
        [StringLength(150)]
        [Unicode(false)]
        public string? EqpSubTitle { get; set; }
        [Column("EQP_X")]
        public double? EqpX { get; set; }
        [Column("EQP_W")]
        public double? EqpW { get; set; }
        [Column("EQP_Y")]
        public double? EqpY { get; set; }
        [Column("EQP_H")]
        public double? EqpH { get; set; }
        [Column("EQP_Status")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EqpStatus { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Layout { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Factory { get; set; }
        [Column("EQP_NextCheckDT", TypeName = "datetime")]
        public DateTime? EqpNextCheckDt { get; set; }
        [Column("EQP_LastCheckDT", TypeName = "datetime")]
        public DateTime? EqpLastCheckDt { get; set; }
        [Column("EQP_LastCheckBy")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EqpLastCheckBy { get; set; }
        [Column("EQP_Remark")]
        [StringLength(150)]
        [Unicode(false)]
        public string? EqpRemark { get; set; }
        [Column("EQP_StartCheckDT", TypeName = "datetime")]
        public DateTime? EqpStartCheckDt { get; set; }
        [Column("OBJ_MstNextDay")]
        public int? ObjMstNextDay { get; set; }
        [Column("OBJ_MstNextMonth")]
        public int? ObjMstNextMonth { get; set; }
        [Column("OBJ_MstNextYear")]
        public int? ObjMstNextYear { get; set; }
        [Column("EQP_Trigger")]
        public int? EqpTrigger { get; set; }
        [Column("EQP_Scale")]
        public double? EqpScale { get; set; }
        [Column("EQP_Rotate")]
        public int? EqpRotate { get; set; }
    }
}
