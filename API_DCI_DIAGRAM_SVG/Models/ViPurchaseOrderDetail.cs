using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPurchaseOrderDetail
    {
        public string? PoNbr { get; set; }
        public string? PoSupplier { get; set; }
        public DateTime? PoOrderDate { get; set; }
        public string? PoPricetable { get; set; }
        public string? PoCurrency { get; set; }
        public int? PodLine { get; set; }
        public string? PodItemnumber { get; set; }
        public decimal? PodOrderqty { get; set; }
        public string? PodUm { get; set; }
        public decimal? PodPrice { get; set; }
        public DateTime? PodDuedate { get; set; }
        public string? Status { get; set; }
        public string? PoSupplierName { get; set; }
        public string? PodItemName { get; set; }
        public string? LocalCode { get; set; }
        public string? MonthCode { get; set; }
    }
}
