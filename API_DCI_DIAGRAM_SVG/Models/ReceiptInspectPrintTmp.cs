using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptInspectPrintTmp
    {
        public string RmNo { get; set; } = null!;
        public string? PrintBy { get; set; }
        public DateTime? PrintDate { get; set; }
        public string? StatusPrint { get; set; }
        public string? PrintType { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? PrintZone { get; set; }
        public string? PrinterName { get; set; }
    }
}
