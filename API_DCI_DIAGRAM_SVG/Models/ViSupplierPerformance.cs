using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViSupplierPerformance
    {
        public int Id { get; set; }
        public string? Einvoice { get; set; }
        public string? Po { get; set; }
        public string? Invoice { get; set; }
        public string? SupplierNo { get; set; }
        public string? SupplierName { get; set; }
        public DateTime? RndDate { get; set; }
        public string? RndTime { get; set; }
        public string? DoDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public int? DiffMin { get; set; }
    }
}
