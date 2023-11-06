using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("MPCK_Dictionary")]
    [Index(nameof(DictType), Name = "IX_MPCK_Dictionary")]
    [Index(nameof(DictType), nameof(DictRefCode), Name = "IX_MPCK_Dictionary_1")]
    public partial class MpckDictionary
    {
        [Key]
        [Column("Dict_Type")]
        [StringLength(50)]
        public string DictType { get; set; } = null!;
        [Key]
        [Column("Dict_Code")]
        [StringLength(50)]
        public string DictCode { get; set; } = null!;
        [Column("Dict_Name")]
        [StringLength(250)]
        public string? DictName { get; set; }
        [Column("Dict_SubName")]
        [StringLength(250)]
        public string? DictSubName { get; set; }
        [Key]
        [Column("Dict_RefCode")]
        [StringLength(50)]
        public string DictRefCode { get; set; } = null!;
        [Column("Dict_RefName")]
        [StringLength(250)]
        public string? DictRefName { get; set; }
        [Column("Dict_RefSubName")]
        [StringLength(250)]
        public string? DictRefSubName { get; set; }
        [Column("Dict_RefCode2")]
        [StringLength(50)]
        public string? DictRefCode2 { get; set; }
    }
}
