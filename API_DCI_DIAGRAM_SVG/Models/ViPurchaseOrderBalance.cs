using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPurchaseOrderBalance
    {
        public string? PodNbr { get; set; }
        public DateTime? PodOrderDate { get; set; }
        public DateTime? PodDueDate { get; set; }
        public string? PodSupplierName { get; set; }
        public string? PodSupplierCode { get; set; }
        public int? PodLine { get; set; }
        public string? PodPart { get; set; }
        public string? PodDesc1 { get; set; }
        public string? PodDesc2 { get; set; }
        public decimal? PodPrice { get; set; }
        public decimal? PodOrderQty { get; set; }
        public decimal PodReceived { get; set; }
        public string? PodUm { get; set; }
        public DateTime? PodCreateDate { get; set; }
        public string? PodCreateBy { get; set; }
        public string? Status { get; set; }
    }
}
