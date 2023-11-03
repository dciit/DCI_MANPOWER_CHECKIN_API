using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("MPCK_CheckInLog")]
    [Index(nameof(ObjCode), nameof(Ckdate), nameof(Cktype), Name = "IX_MPCK_CheckInLog")]
    [Index(nameof(ObjCode), nameof(CkdateTime), nameof(Cktype), Name = "IX_MPCK_CheckInLog_1")]
    public partial class MpckCheckInLog
    {
        [Key]
        [StringLength(50)]
        public string Nbr { get; set; } = null!;
        [Column("Obj_Code")]
        [StringLength(50)]
        public string? ObjCode { get; set; }
        [StringLength(10)]
        public string? EmpCode { get; set; }
        [Column("CKDate")]
        [StringLength(50)]
        public string? Ckdate { get; set; }
        [Column("CKTime")]
        [StringLength(50)]
        public string? Cktime { get; set; }
        [Column("CKShift")]
        [StringLength(10)]
        public string? Ckshift { get; set; }
        [Column("CKType")]
        [StringLength(50)]
        public string? Cktype { get; set; }
        [Column("CKDateTime", TypeName = "datetime")]
        public DateTime? CkdateTime { get; set; }
    }
}
