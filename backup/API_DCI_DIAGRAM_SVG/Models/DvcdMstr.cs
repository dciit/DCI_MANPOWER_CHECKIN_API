using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("DVCD_MSTR")]
    public partial class DvcdMstr
    {
        [Key]
        [Column("DV_CD")]
        [StringLength(10)]
        public string DvCd { get; set; } = null!;
        [Column("DV_ENAME")]
        [StringLength(200)]
        public string DvEname { get; set; } = null!;
        [Column("DV_TNAME")]
        [StringLength(200)]
        public string? DvTname { get; set; }
        [Column("DV_DESCR")]
        [StringLength(200)]
        public string? DvDescr { get; set; }
        [Column("DV_TYPE")]
        [StringLength(200)]
        public string? DvType { get; set; }
        [Column("DV_HDV_CD")]
        [StringLength(10)]
        public string? DvHdvCd { get; set; }
        [Column("DEPT")]
        [StringLength(200)]
        public string? Dept { get; set; }
        [Column("SECT")]
        [StringLength(200)]
        public string? Sect { get; set; }
        [Column("GRP")]
        [StringLength(200)]
        public string? Grp { get; set; }
        [Column("TDEPT")]
        [StringLength(200)]
        public string? Tdept { get; set; }
        [Column("TSECT")]
        [StringLength(200)]
        public string? Tsect { get; set; }
        [Column("TGRP")]
        [StringLength(200)]
        public string? Tgrp { get; set; }
        [Column("DEPT_CD")]
        [StringLength(10)]
        public string? DeptCd { get; set; }
        [Column("SECT_CD")]
        [StringLength(10)]
        public string? SectCd { get; set; }
        [Column("GRP_CD")]
        [StringLength(10)]
        public string? GrpCd { get; set; }
        [Column("DEPT_NAME")]
        [StringLength(200)]
        public string? DeptName { get; set; }
        [Column("SECT_NAME")]
        [StringLength(200)]
        public string? SectName { get; set; }
        [Column("GRP_NAME")]
        [StringLength(200)]
        public string? GrpName { get; set; }
        [Column("SORT_NO")]
        public int? SortNo { get; set; }
    }
}
