using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptManualPoDetail
    {
        public string PodTran { get; set; } = null!;
        public string? PodNumber { get; set; }
        public string? PodInvoice { get; set; }
        public int? PodLine { get; set; }
        public string? PodItemId { get; set; }
        public string? PodItemName { get; set; }
        public string? PodItemDesc { get; set; }
        public decimal? PodReceiptQty { get; set; }
        public string? PodUm { get; set; }
        public decimal? PodPrice { get; set; }
        public string? PodCurrency { get; set; }
        public string? PodSite { get; set; }
        public string? PodLocation { get; set; }
        public string? PodSubId { get; set; }
        public int? PodSubOp { get; set; }
    }
}
