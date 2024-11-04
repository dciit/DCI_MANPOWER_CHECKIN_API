using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViEinvoicePartTag
    {
        public string TagId { get; set; } = null!;
        public string? Einvoice { get; set; }
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? PartNo { get; set; }
        public string? PartName { get; set; }
        public string? Description { get; set; }
        public decimal? TagQty { get; set; }
        public string? ReceiveBy { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}
