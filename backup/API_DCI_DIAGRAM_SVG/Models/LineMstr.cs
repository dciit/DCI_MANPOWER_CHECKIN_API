using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LineMstr
    {
        [Key]
        [Column("ln_code")]
        [StringLength(20)]
        public string LnCode { get; set; } = null!;
        [Column("ln_name")]
        [StringLength(50)]
        public string? LnName { get; set; }
        [Column("ln_group")]
        [StringLength(50)]
        public string? LnGroup { get; set; }
        [Column("ln_product")]
        [StringLength(50)]
        public string? LnProduct { get; set; }
        [Column("ln_factory")]
        [StringLength(50)]
        public string? LnFactory { get; set; }
        [Column("OP_std", TypeName = "decimal(18, 2)")]
        public decimal? OpStd { get; set; }
        [Column("LE_std", TypeName = "decimal(18, 2)")]
        public decimal? LeStd { get; set; }
        [Column("FO_std", TypeName = "decimal(18, 2)")]
        public decimal? FoStd { get; set; }
        [Column("SU_std", TypeName = "decimal(18, 2)")]
        public decimal? SuStd { get; set; }
    }
}
