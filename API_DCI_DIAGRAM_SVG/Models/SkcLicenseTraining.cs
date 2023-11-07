using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("SKC_LicenseTraining")]
    public partial class SkcLicenseTraining
    {
        [Key]
        [Column("TR_ID")]
        public int TrId { get; set; }
        [Column("EMPCODE")]
        [StringLength(10)]
        public string? Empcode { get; set; }
        [Column("DICT_CODE")]
        [StringLength(30)]
        public string? DictCode { get; set; }
        [Column("REF_CODE")]
        [StringLength(10)]
        public string? RefCode { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column("EXPIRED_DATE", TypeName = "datetime")]
        public DateTime? ExpiredDate { get; set; }
        [Column("ALERT_DATE", TypeName = "datetime")]
        public DateTime? AlertDate { get; set; }
        [Column("TR_STATUS")]
        public bool TrStatus { get; set; }
        [Column("CREATE_BY")]
        [StringLength(30)]
        public string? CreateBy { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
