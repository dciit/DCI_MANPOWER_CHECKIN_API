using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Keyless]
    public partial class ViMpckCheckInOutLog
    {
        [StringLength(50)]
        public string Nbr { get; set; } = null!;
        [Column("Obj_Code")]
        [StringLength(20)]
        public string? ObjCode { get; set; }
        [StringLength(5)]
        public string? EmpCode { get; set; }
        [StringLength(202)]
        public string? EmpName { get; set; }
        [Column("POSIT")]
        [StringLength(50)]
        public string? Posit { get; set; }
        [Column("CKDate")]
        [StringLength(8)]
        public string? Ckdate { get; set; }
        [Column("CKShift")]
        [StringLength(5)]
        public string? Ckshift { get; set; }
        [Column("CKType")]
        [StringLength(10)]
        public string? Cktype { get; set; }
        [Column("CKDateTime", TypeName = "datetime")]
        public DateTime? CkdateTime { get; set; }
    }
}
