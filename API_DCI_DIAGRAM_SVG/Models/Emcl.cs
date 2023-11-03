using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("EMCL")]
    public partial class Emcl
    {
        [Key]
        [Column("YM")]
        [StringLength(10)]
        public string Ym { get; set; } = null!;
        [Key]
        [Column("CODE")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("STSS")]
        [StringLength(50)]
        public string? Stss { get; set; }
        [Column("STSO")]
        [StringLength(50)]
        public string? Stso { get; set; }
        [Column("STSH")]
        [StringLength(50)]
        public string? Stsh { get; set; }
        [Column("CR_BY")]
        [StringLength(50)]
        public string? CrBy { get; set; }
        [Column("CR_DT", TypeName = "date")]
        public DateTime? CrDt { get; set; }
        [Column("UPD_BY")]
        [StringLength(50)]
        public string? UpdBy { get; set; }
        [Column("UPD_DT", TypeName = "date")]
        public DateTime? UpdDt { get; set; }
    }
}
