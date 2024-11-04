using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuTempMasterDataPolog
    {
        public int Id { get; set; }
        public string? GenPurchaseCode { get; set; }
        public string? VdAddr { get; set; }
        public string? PtPart { get; set; }
        public string? PoNbr { get; set; }
        public decimal? PoQty { get; set; }
        public decimal? PoRecv { get; set; }
        public decimal? PoRemain { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
