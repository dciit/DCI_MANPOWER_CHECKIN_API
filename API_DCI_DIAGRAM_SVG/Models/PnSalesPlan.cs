using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnSalesPlan
    {
        public int Id { get; set; }
        public string? DataMonth { get; set; }
        public int? Revision { get; set; }
        public string? Model { get; set; }
        public string? Customer { get; set; }
        public DateTime? LoadDate { get; set; }
        public int? Quantity { get; set; }
        public string? PalletType { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? Status { get; set; }
    }
}
