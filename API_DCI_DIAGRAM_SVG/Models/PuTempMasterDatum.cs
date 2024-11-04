using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuTempMasterDatum
    {
        public long Id { get; set; }
        public string? GenPurchaseCode { get; set; }
        public string? LocalCode { get; set; }
        public string? ImportCode { get; set; }
        public DateTime? DataCutOff { get; set; }
        public string? OrderType { get; set; }
        public decimal? OrderLeadTime { get; set; }
        public bool? IsBoi { get; set; }
        public string? VdAddr { get; set; }
        public decimal? VdOrderRatio { get; set; }
        public string? PtPart { get; set; }
        public string? BomUm { get; set; }
        public decimal? SafetyQty { get; set; }
        public decimal? StockQty { get; set; }
        public decimal? WipQty { get; set; }
        public decimal? PoBalanceQty { get; set; }
        public decimal? CurrPoQty { get; set; }
        public decimal? FutrPoQty { get; set; }
        public decimal? PackStdQty { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
