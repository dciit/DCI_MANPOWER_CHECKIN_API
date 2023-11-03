using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Employee
    {
        [Key]
        [Column("CODE")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("PREN")]
        [StringLength(50)]
        public string? Pren { get; set; }
        [Column("NAME")]
        [StringLength(200)]
        public string? Name { get; set; }
        [Column("SURN")]
        [StringLength(200)]
        public string? Surn { get; set; }
        [Column("SEX")]
        [StringLength(20)]
        public string? Sex { get; set; }
        [Column("TPREN")]
        [StringLength(20)]
        public string? Tpren { get; set; }
        [Column("TNAME")]
        [StringLength(200)]
        public string? Tname { get; set; }
        [Column("TSURN")]
        [StringLength(200)]
        public string? Tsurn { get; set; }
        [Column("TSEX")]
        [StringLength(20)]
        public string? Tsex { get; set; }
        [Column("BIRTH", TypeName = "date")]
        public DateTime? Birth { get; set; }
        [Column("JOIN", TypeName = "date")]
        public DateTime? Join { get; set; }
        [Column("RESIGN", TypeName = "date")]
        public DateTime? Resign { get; set; }
        [Column("RELIGION")]
        [StringLength(50)]
        public string? Religion { get; set; }
        [Column("RSTYPE")]
        [StringLength(50)]
        public string? Rstype { get; set; }
        [Column("DVCD")]
        [StringLength(10)]
        public string? Dvcd { get; set; }
        [Column("WTYPE")]
        [StringLength(50)]
        public string? Wtype { get; set; }
        [Column("WSTS")]
        [StringLength(50)]
        public string? Wsts { get; set; }
        [Column("POSIT")]
        [StringLength(50)]
        public string? Posit { get; set; }
        [Column("P_RANK")]
        [StringLength(10)]
        public string? PRank { get; set; }
        [Column("P_GRADE")]
        [StringLength(10)]
        public string? PGrade { get; set; }
        [Column("BUS")]
        [StringLength(50)]
        public string? Bus { get; set; }
        [Column("STOP")]
        [StringLength(50)]
        public string? Stop { get; set; }
        [Column("TCADDR3")]
        [StringLength(50)]
        public string? Tcaddr3 { get; set; }
        [Column("TCADDR4")]
        [StringLength(50)]
        public string? Tcaddr4 { get; set; }
        [Column("TCTEL")]
        [StringLength(50)]
        public string? Tctel { get; set; }
        [Column("TELEPHONE")]
        [StringLength(50)]
        public string? Telephone { get; set; }
        [Column("MAIL")]
        [StringLength(50)]
        public string? Mail { get; set; }
        [Column("OTYPE")]
        [StringLength(50)]
        public string? Otype { get; set; }
        [Column("DLRATE")]
        [StringLength(50)]
        public string? Dlrate { get; set; }
        [Column("GRPOT")]
        [StringLength(50)]
        public string? Grpot { get; set; }
        [Column("NICKNAME")]
        [StringLength(50)]
        public string? Nickname { get; set; }
        [Column("COSTCENTER")]
        [StringLength(50)]
        public string? Costcenter { get; set; }
        [Column("COMPANY")]
        [StringLength(50)]
        public string? Company { get; set; }
        [Column("TPOSINAME")]
        [StringLength(150)]
        public string? Tposiname { get; set; }
        [Column("TPOSIJOIN_DT", TypeName = "date")]
        public DateTime? TposijoinDt { get; set; }
        [Column("ANNUALCAL_DT", TypeName = "date")]
        public DateTime? AnnualcalDt { get; set; }
        [Column("ANDON")]
        [StringLength(500)]
        public string? Andon { get; set; }
        [Column("LOCATION")]
        [StringLength(500)]
        public string? Location { get; set; }
        [Column("WORKCENTER")]
        [StringLength(10)]
        public string? Workcenter { get; set; }
        [Column("BUDGETTYPE")]
        [StringLength(10)]
        public string? Budgettype { get; set; }
        [StringLength(100)]
        public string? LineCode { get; set; }
    }
}
