using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptComment
    {
        public int Id { get; set; }
        public string EinvoiceId { get; set; } = null!;
        public string? Invoice { get; set; }
        public string? Comment { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
