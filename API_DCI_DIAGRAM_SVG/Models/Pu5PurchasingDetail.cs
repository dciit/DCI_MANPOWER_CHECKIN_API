using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Pu5PurchasingDetail
    {
        public long Id { get; set; }
        public string? GenPurchaseCode { get; set; }
        public string? LocalCode { get; set; }
        public string? ImportCode { get; set; }
        public string? OrderType { get; set; }
        public decimal? OrderLeadTime { get; set; }
        public bool? IsBoi { get; set; }
        public string? PodNbr { get; set; }
        public int? PodLine { get; set; }
        public string? PodItemnumber { get; set; }
        public decimal? PodOrderqty { get; set; }
        public string? PodUm { get; set; }
        public string? PodSite { get; set; }
        public string? PodLocation { get; set; }
        public decimal? PodPrice { get; set; }
        public decimal? PodDisc { get; set; }
        public DateTime? PodDuedate { get; set; }
        public string? PodAccount { get; set; }
        public string? PodSubaccount { get; set; }
        public string? PodCostcenter { get; set; }
        public bool? PodSinglelot { get; set; }
        public int? PodRevision { get; set; }
        public string? PodSupplieritem { get; set; }
        public DateTime? PodPerformancedate { get; set; }
        public DateTime? PodNeeddate { get; set; }
        public string? PodSalejob { get; set; }
        public bool? PodFixedprice { get; set; }
        public string? PodProject { get; set; }
        public string? PodType { get; set; }
        public string? PodSworkorder { get; set; }
        public int? PodSid { get; set; }
        public int? PodSoperation { get; set; }
        public string? PodSsubcontracttype { get; set; }
        public string? PodSlotserial { get; set; }
        public bool? PodInspectrequest { get; set; }
        public decimal? PodUmconversion { get; set; }
        public bool? PodLastcostupdate { get; set; }
        public string? PodStatus { get; set; }
        public string? PodVendorpart { get; set; }
        public string? PodTaxUse { get; set; }
        public string? PodTaxEnvironment { get; set; }
        public int? PodTaxClass { get; set; }
        public bool? PodTaxAble { get; set; }
        public bool? PodTaxIn { get; set; }
        public int? PodErsOption { get; set; }
        public int? PodErsPricelistOption { get; set; }
        public bool? PodCmmnt { get; set; }
        public int? PodComment { get; set; }
        public string? MonthPriceCode { get; set; }
        public string? MonthCode { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? PodReceived { get; set; }
    }
}
