using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsSaleOrder
    {
        public string? OrderCode { get; set; }
        public string? ModelName { get; set; }
        public string? PackagingType { get; set; }
        public double? Quantity { get; set; }
        public DateTime? LoadingDate { get; set; }
        public string? Customer { get; set; }
        public string? CustomerType { get; set; }
        public string? Pono { get; set; }
        public DateTime? Etd { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? Status { get; set; }
        public double? ActualQty { get; set; }
        public double? TotalQty { get; set; }
        public double? LoadQty { get; set; }
        public string? OrderStatus { get; set; }
        public string? SalesModel { get; set; }
        public double? OrderNo { get; set; }
    }
}
