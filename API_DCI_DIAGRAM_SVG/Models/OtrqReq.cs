using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("OTRQ_REQ")]
    public partial class OtrqReq
    {
        [Key]
        [Column("ODATE", TypeName = "date")]
        public DateTime Odate { get; set; }
        [Key]
        [Column("RQ")]
        [StringLength(10)]
        public string Rq { get; set; } = null!;
        [Key]
        [Column("CODE")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("BUS")]
        [StringLength(10)]
        public string? Bus { get; set; }
        [Column("STOP")]
        [StringLength(10)]
        public string? Stop { get; set; }
        [Column("OTFROM")]
        [StringLength(10)]
        public string? Otfrom { get; set; }
        [Column("OTTO")]
        [StringLength(10)]
        public string? Otto { get; set; }
        [Column("OT15")]
        [StringLength(10)]
        public string? Ot15 { get; set; }
        [Column("OT1")]
        [StringLength(10)]
        public string? Ot1 { get; set; }
        [Column("OT2")]
        [StringLength(10)]
        public string? Ot2 { get; set; }
        [Column("OT3")]
        [StringLength(10)]
        public string? Ot3 { get; set; }
        [Column("DVCD")]
        [StringLength(20)]
        public string? Dvcd { get; set; }
        [Column("FBUS")]
        [StringLength(20)]
        public string? Fbus { get; set; }
        [Column("JOB")]
        [StringLength(10)]
        public string? Job { get; set; }
        [Column("SECT")]
        [StringLength(10)]
        public string? Sect { get; set; }
        [StringLength(10)]
        public string? N15 { get; set; }
        [StringLength(10)]
        public string? N1 { get; set; }
        [StringLength(10)]
        public string? N2 { get; set; }
        [StringLength(10)]
        public string? N3 { get; set; }
        [Column("RES")]
        [StringLength(200)]
        public string? Res { get; set; }
        [Column("NFROM")]
        [StringLength(10)]
        public string? Nfrom { get; set; }
        [Column("NTO")]
        [StringLength(10)]
        public string? Nto { get; set; }
        [Column("STS")]
        [StringLength(10)]
        public string? Sts { get; set; }
        [Column("CR_BY")]
        [StringLength(20)]
        public string? CrBy { get; set; }
        [Column("CR_DT", TypeName = "datetime")]
        public DateTime? CrDt { get; set; }
        [Column("UPD_BY")]
        [StringLength(30)]
        public string? UpdBy { get; set; }
        [Column("UPD_DT", TypeName = "datetime")]
        public DateTime? UpdDt { get; set; }
        [Column("DOC_ID")]
        [StringLength(50)]
        public string? DocId { get; set; }
        [Column("OT1FROM")]
        [StringLength(10)]
        public string? Ot1from { get; set; }
        [Column("OT1TO")]
        [StringLength(10)]
        public string? Ot1to { get; set; }
        [Column("OT15FROM")]
        [StringLength(10)]
        public string? Ot15from { get; set; }
        [Column("OT2FROM")]
        [StringLength(10)]
        public string? Ot2from { get; set; }
        [Column("OT2TO")]
        [StringLength(10)]
        public string? Ot2to { get; set; }
        [Column("OT3FROM")]
        [StringLength(10)]
        public string? Ot3from { get; set; }
        [Column("OT3TO")]
        [StringLength(10)]
        public string? Ot3to { get; set; }
        [Column("OT15TO")]
        [StringLength(10)]
        public string? Ot15to { get; set; }
        [Column("WTYPE")]
        [StringLength(2)]
        public string? Wtype { get; set; }
        [Column("APPROVE_BY")]
        [StringLength(30)]
        public string? ApproveBy { get; set; }
        [Column("APPROVE_DT", TypeName = "datetime")]
        public DateTime? ApproveDt { get; set; }
        [Column("REQ_STATUS")]
        [StringLength(30)]
        public string? ReqStatus { get; set; }
        [Column("SHIFT")]
        [StringLength(10)]
        public string? Shift { get; set; }
        [StringLength(10)]
        public string? ProgBit { get; set; }
        [StringLength(250)]
        public string? Remark { get; set; }
    }
}
