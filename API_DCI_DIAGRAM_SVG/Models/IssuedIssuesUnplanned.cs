using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class IssuedIssuesUnplanned
    {
        public string SiOrder { get; set; } = null!;
        public string? SiPart { get; set; }
        public decimal? SiQty { get; set; }
        public string? SiUm { get; set; }
        public decimal? SiUmCon { get; set; }
        public string? SiSite { get; set; }
        public string? SiLocation { get; set; }
        public string? SiLotSerial { get; set; }
        public string? SiReference { get; set; }
        public bool? SiMulti { get; set; }
        public int? SiLine { get; set; }
        public string? SiSaleJob { get; set; }
        public string? SiAddress { get; set; }
        public string? SiRemarks { get; set; }
        public DateTime? SiEffectiveDate { get; set; }
        public string? SiDrAcc { get; set; }
        public string? SiSubAcc { get; set; }
        public string? SiCc { get; set; }
        public string? SiProj { get; set; }
        public DateTime? SiCreateDate { get; set; }
        public string? SiCreateBy { get; set; }
        public DateTime? SiUpdateDate { get; set; }
        public string? SiUpdateBy { get; set; }
        public string? SiStatus { get; set; }
    }
}
