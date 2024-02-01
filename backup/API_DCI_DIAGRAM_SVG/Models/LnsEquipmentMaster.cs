using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("LNS_Equipment_MASTER")]
    public partial class LnsEquipmentMaster
    {
        [Key]
        [Column("OBJ_ID")]
        [StringLength(50)]
        public string ObjId { get; set; } = null!;
        [Column("OBJ_NAME")]
        [StringLength(50)]
        public string? ObjName { get; set; }
        [Column("OBJ_W")]
        public int? ObjW { get; set; }
        [Column("OBJ_H")]
        public int? ObjH { get; set; }
        [Column("OBJ_SVG", TypeName = "text")]
        public string? ObjSvg { get; set; }
        [Column("OBJ_MstNextDay")]
        public int? ObjMstNextDay { get; set; }
        [Column("OBJ_MstNextMonth")]
        public int? ObjMstNextMonth { get; set; }
        [Column("OBJ_MstNextYear")]
        public int? ObjMstNextYear { get; set; }
    }
}
