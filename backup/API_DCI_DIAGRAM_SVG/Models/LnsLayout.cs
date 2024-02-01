using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("LNS_Layout")]
    public partial class LnsLayout
    {
        [Key]
        [Column("LAYOUT_CODE")]
        [StringLength(50)]
        public string LayoutCode { get; set; } = null!;
        [Column("LAYOUT_NAME")]
        [StringLength(150)]
        public string? LayoutName { get; set; }
        [Column("LAYOUT_WIDTH")]
        public int? LayoutWidth { get; set; }
        [Column("LAYOUT_HEIGHT")]
        public int? LayoutHeight { get; set; }
    }
}
