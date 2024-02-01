using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("TR_Line_Process")]
    [Index(nameof(Factory), Name = "IX_TR_Line_Process")]
    [Index(nameof(Factory), nameof(Line), Name = "IX_TR_Line_Process_1")]
    [Index(nameof(Factory), nameof(Line), nameof(SubLine), Name = "IX_TR_Line_Process_2")]
    public partial class TrLineProcess
    {
        [Key]
        [StringLength(50)]
        public string ProcCode { get; set; } = null!;
        [StringLength(50)]
        public string? ProcType { get; set; }
        [StringLength(50)]
        public string? Factory { get; set; }
        [StringLength(50)]
        public string? Line { get; set; }
        [StringLength(50)]
        public string? SubLine { get; set; }
        [StringLength(50)]
        public string? ProcessCode { get; set; }
        [StringLength(300)]
        public string? ProcessName { get; set; }
        [Column("CreateBY")]
        [StringLength(50)]
        public string? CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
