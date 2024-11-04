using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoSupDelivery
    {
        public int DryId { get; set; }
        public string SupplierNo { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int DryRev { get; set; }
        public DateTime? DryRevDate { get; set; }
        public string? DryRevBy { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
