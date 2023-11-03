using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Keyless]
    public partial class ViMpckDictionary
    {
        [Column("Dict_Type")]
        [StringLength(50)]
        public string DictType { get; set; } = null!;
        [Column("Dict_Code")]
        [StringLength(50)]
        public string DictCode { get; set; } = null!;
        [Column("Dict_RefCode")]
        [StringLength(50)]
        public string DictRefCode { get; set; } = null!;
        [Column("Dict_Name")]
        [StringLength(250)]
        public string? DictName { get; set; }
        [StringLength(10)]
        public string? Factory { get; set; }
        [StringLength(10)]
        public string? Line { get; set; }
        [StringLength(20)]
        public string? SubLine { get; set; }
        [StringLength(50)]
        public string? LayoutName { get; set; }
        [Column("BypassMQ")]
        [StringLength(10)]
        public string? BypassMq { get; set; }
        [Column("BypassSA")]
        [StringLength(10)]
        public string? BypassSa { get; set; }
        [StringLength(10)]
        public string? LayoutStatus { get; set; }
        [StringLength(50)]
        public string? LayoutSubName { get; set; }
    }
}
