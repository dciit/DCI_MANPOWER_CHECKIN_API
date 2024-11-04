using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PriceList
    {
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public string? PriceList1 { get; set; }
        public string? ItemNumber { get; set; }
        public string? Unit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? AmountType { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
