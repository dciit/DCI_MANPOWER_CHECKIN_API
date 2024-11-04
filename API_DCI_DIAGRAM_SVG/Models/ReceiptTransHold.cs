using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptTransHold
    {
        public int Id { get; set; }
        public string? Einvoice { get; set; }
        public string? Invoice { get; set; }
        public string? Status { get; set; }
        public DateTime? HoldDate { get; set; }
        public string? HoldBy { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string? CompleteBy { get; set; }
        public string? Comment { get; set; }
    }
}
