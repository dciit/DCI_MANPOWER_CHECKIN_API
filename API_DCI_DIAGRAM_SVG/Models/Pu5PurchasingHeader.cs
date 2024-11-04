using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Pu5PurchasingHeader
    {
        public long Id { get; set; }
        public string? GenPurchaseCode { get; set; }
        public string? LocalCode { get; set; }
        public string? ImportCode { get; set; }
        public string? OrderType { get; set; }
        public decimal? OrderLeadTime { get; set; }
        public bool? IsBoi { get; set; }
        public string? PoNbr { get; set; }
        public string? PoSupplier { get; set; }
        public string? PoShipto { get; set; }
        public string? PoSite { get; set; }
        public DateTime? PoOrderDate { get; set; }
        public DateTime? PoDueDate { get; set; }
        public string? PoBuyer { get; set; }
        public string? PoBillTo { get; set; }
        public string? PoSalejob { get; set; }
        public string? PoContract { get; set; }
        public string? PoContact { get; set; }
        public string? PoRemark { get; set; }
        public string? PoPricetable { get; set; }
        public string? PoDisctable { get; set; }
        public decimal? PoDiscpercent { get; set; }
        public string? PoProject { get; set; }
        public bool? PoConfirm { get; set; }
        public bool? PoImportexport { get; set; }
        public string? PoCurrency { get; set; }
        public string? PoLanguage { get; set; }
        public bool? PoFixedPrice { get; set; }
        public bool? PoTaxAble { get; set; }
        public int? PoTaxClass { get; set; }
        public DateTime? PoTaxDate { get; set; }
        public string? PoTaxpUsage { get; set; }
        public string? PoTaxpEnvironment { get; set; }
        public int? PoTaxpClass { get; set; }
        public bool? PoTaxpAble { get; set; }
        public bool? PoTaxpIn { get; set; }
        public string? PoCreditTerms { get; set; }
        public decimal? PoCreditInt { get; set; }
        public bool? PoConsign { get; set; }
        public string? PoRequestid { get; set; }
        public bool? PoCmmnt { get; set; }
        public int? PoComment { get; set; }
        public string? PoErsOption { get; set; }
        public int? PoErsPricelistOption { get; set; }
        public string? MonthPriceCode { get; set; }
        public string? MonthCode { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? PoShipvia { get; set; }
        public string? PoApAccount { get; set; }
        public string? PoApCostcenter { get; set; }
        public string? PoApSubaccount { get; set; }
        public string? PoFob { get; set; }
    }
}
