using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPobalance
    {
        public string Pono { get; set; } = null!;
        public string ItemNo { get; set; } = null!;
        public string? Drawing { get; set; }
        public string? Cm { get; set; }
        public string? Description { get; set; }
        public decimal? PoorderQty { get; set; }
        public decimal? PoreceivedQty { get; set; }
        public decimal? PoremainQty { get; set; }
        public string? Whunit { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryPlace { get; set; }
        public string? VendorCode { get; set; }
        public string? VendorName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
    }
}
