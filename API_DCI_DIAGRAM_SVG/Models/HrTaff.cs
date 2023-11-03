using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("HR_Taff")]
    [Index(nameof(Code), Name = "IX_HR_Taff")]
    [Index(nameof(TaffRecord), nameof(TaffType), Name = "IX_HR_Taff_1")]
    public partial class HrTaff
    {
        [Key]
        [Column("CODE")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Key]
        [StringLength(10)]
        public string TaffType { get; set; } = null!;
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime TaffRecord { get; set; }
    }
}
