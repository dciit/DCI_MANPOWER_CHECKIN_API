using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuPriceListMaster
    {
        public string PcList { get; set; } = null!;
        public string PcPart { get; set; } = null!;
        public string PcUm { get; set; } = null!;
        public string PcAmtType { get; set; } = null!;
        public decimal PcAmt { get; set; }
        public string PcCurr { get; set; } = null!;
        public string? PcProdLine { get; set; }
        public DateTime PcStart { get; set; }
        public DateTime? PcExpire { get; set; }
        public DateTime? PcModDate { get; set; }
        public string? PcUserid { get; set; }
    }
}
