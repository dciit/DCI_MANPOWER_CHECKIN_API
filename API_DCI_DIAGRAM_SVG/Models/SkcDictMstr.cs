using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("SKC_DictMstr")]
    [Index(nameof(DictType), Name = "IX_SKC_DictMstr")]
    [Index(nameof(DictType), nameof(Code), Name = "IX_SKC_DictMstr_1")]
    [Index(nameof(DictType), nameof(Code), nameof(RefCode), Name = "IX_SKC_DictMstr_2")]
    public partial class SkcDictMstr
    {
        [Key]
        [Column("DICT_ID")]
        public int DictId { get; set; }
        [Column("DICT_TYPE")]
        [StringLength(20)]
        [Unicode(false)]
        public string? DictType { get; set; }
        [Column("CODE")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Code { get; set; }
        [Column("DICT_DESC")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DictDesc { get; set; }
        [Column("REF_CODE")]
        [StringLength(50)]
        [Unicode(false)]
        public string? RefCode { get; set; }
        [Column("REF_ITEM")]
        [StringLength(50)]
        [Unicode(false)]
        public string? RefItem { get; set; }
        [Column("NOTE")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Note { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("UPDATE_DATE", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("DICT_STATUS")]
        public bool? DictStatus { get; set; }
    }
}
