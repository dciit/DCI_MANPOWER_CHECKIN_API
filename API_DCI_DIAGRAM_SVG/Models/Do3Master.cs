using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Do3Master
    {
        public int RunningId { get; set; }
        public string? RunningCode { get; set; }
        public string? DataYear { get; set; }
        public string? DataMonth { get; set; }
        public string? DataType { get; set; }
        public string? GenPurchaseCode { get; set; }
        public DateTime? DataCutOff { get; set; }
        public string? ItemNumber { get; set; }
        public string? ItemUm { get; set; }
        public decimal? ItemWip { get; set; }
        public decimal? ItemStock { get; set; }
        public decimal? ItemDoBalance { get; set; }
        public string? OrderType { get; set; }
        public int? OrderLeadtime { get; set; }
        public string? SafetyQty { get; set; }
        public decimal? CurrentDoQty { get; set; }
        public decimal? FutureDoQty { get; set; }
        public decimal? PackingStd { get; set; }
        public string? DefaultSupplier { get; set; }
        public decimal? SupplierRatio { get; set; }
        public decimal? D01Req { get; set; }
        public decimal? D02Req { get; set; }
        public decimal? D03Req { get; set; }
        public decimal? D04Req { get; set; }
        public decimal? D05Req { get; set; }
        public decimal? D06Req { get; set; }
        public decimal? D07Req { get; set; }
        public decimal? D08Req { get; set; }
        public decimal? D09Req { get; set; }
        public decimal? D10Req { get; set; }
        public decimal? D11Req { get; set; }
        public decimal? D12Req { get; set; }
        public decimal? D13Req { get; set; }
        public decimal? D14Req { get; set; }
        public decimal? D15Req { get; set; }
        public decimal? D16Req { get; set; }
        public decimal? D17Req { get; set; }
        public decimal? D18Req { get; set; }
        public decimal? D19Req { get; set; }
        public decimal? D20Req { get; set; }
        public decimal? D21Req { get; set; }
        public decimal? D22Req { get; set; }
        public decimal? D23Req { get; set; }
        public decimal? D24Req { get; set; }
        public decimal? D25Req { get; set; }
        public decimal? D26Req { get; set; }
        public decimal? D27Req { get; set; }
        public string? Status { get; set; }
        public int? Revision { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
