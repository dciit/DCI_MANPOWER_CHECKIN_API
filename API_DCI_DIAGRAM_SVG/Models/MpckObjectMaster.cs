using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("MPCK_Object_Master")]
    public partial class MpckObjectMaster
    {
        [Key]
        [Column("Obj_MasterID")]
        [StringLength(20)]
        public string ObjMasterId { get; set; } = null!;
        [Column("Mst_Name")]
        [StringLength(50)]
        public string? MstName { get; set; }
        [Column("OBJ_SVG", TypeName = "text")]
        public string? ObjSvg { get; set; }
    }
}
