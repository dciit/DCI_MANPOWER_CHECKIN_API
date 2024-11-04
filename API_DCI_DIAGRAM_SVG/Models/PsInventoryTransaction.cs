using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PsInventoryTransaction
    {
        public string TransId { get; set; } = null!;
        public string? TransType { get; set; }
        public string? TransReference { get; set; }
        public string? TransPart { get; set; }
        public decimal? TransQtyChange { get; set; }
        public string? TransUm { get; set; }
        public string? TransLocation { get; set; }
        public string? TransUser { get; set; }
        public DateTime? TransDate { get; set; }
        public DateTime? TransEffdate { get; set; }
    }
}
