using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuSpecialPart
    {
        public string PtPart { get; set; } = null!;
        public string PtModel { get; set; } = null!;
        /// <summary>
        /// NOTUSE, SUBCONT, RANK
        /// </summary>
        public string? DataCondition { get; set; }
        /// <summary>
        /// PERCENT,VALUE
        /// </summary>
        public string? DataKey { get; set; }
        public string? DataValue { get; set; }
        public string? DataUm { get; set; }
        /// <summary>
        /// ACTIVE, UNACTIVE
        /// </summary>
        public string? DataStatus { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Rmk1 { get; set; }
        public string? Rmk2 { get; set; }
        public string? Rmk3 { get; set; }
        public string? Rmk4 { get; set; }
        public string? Rmk5 { get; set; }
        public string? Rmk6 { get; set; }
        public string? Rmk7 { get; set; }
        public string? Rmk8 { get; set; }
        public string? Rmk9 { get; set; }
        public string? Rmk10 { get; set; }
    }
}
