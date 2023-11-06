using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("DCRunNbr")]
    public partial class DcrunNbr
    {
        [Key]
        public int FormatId { get; set; }
        [StringLength(25)]
        public string DocKey { get; set; } = null!;
        [StringLength(25)]
        public string? DocPrefix { get; set; }
        [StringLength(255)]
        public string? Remark { get; set; }
        public int YearNbrPrefix { get; set; }
        public int MonthNbrPrefix { get; set; }
        public int DayNbrPrefix { get; set; }
        public int FormatNbr { get; set; }
        [StringLength(25)]
        public string ResetOption { get; set; } = null!;
        [Column("NextID")]
        public int NextId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActiveDate { get; set; }
    }
}
