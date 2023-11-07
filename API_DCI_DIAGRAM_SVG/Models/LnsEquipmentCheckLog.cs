using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("LNS_Equipment_Check_Log")]
    [Index(nameof(EqpCheckDt), Name = "IX_LNS_Equipment_Check_Log")]
    [Index(nameof(EqpStatus), Name = "IX_LNS_Equipment_Check_Log_1")]
    [Index(nameof(EqpStatus), nameof(EqpCheckDt), nameof(EqpCheckBy), Name = "IX_LNS_Equipment_Check_Log_2")]
    public partial class LnsEquipmentCheckLog
    {
        [Key]
        [StringLength(50)]
        public string Nbr { get; set; } = null!;
        [Column("EQP_ID")]
        [StringLength(50)]
        public string? EqpId { get; set; }
        [Column("EQP_Status")]
        [StringLength(50)]
        public string? EqpStatus { get; set; }
        [Column("EQP_Remark")]
        [StringLength(150)]
        public string? EqpRemark { get; set; }
        [Column("EQP_NextCheckDT", TypeName = "datetime")]
        public DateTime? EqpNextCheckDt { get; set; }
        [Column("EQP_CheckDT", TypeName = "datetime")]
        public DateTime? EqpCheckDt { get; set; }
        [Column("EQP_CheckBy")]
        [StringLength(10)]
        [Unicode(false)]
        public string? EqpCheckBy { get; set; }
    }
}
