using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuEvaluateSupplierResult
    {
        public int Id { get; set; }
        public string Datayear { get; set; } = null!;
        public string Datamonth { get; set; } = null!;
        public string SupplierNo { get; set; } = null!;
        public decimal? DeliveryPoint { get; set; }
        public decimal? DocumentPoint { get; set; }
        public decimal? CorrectPoint { get; set; }
        public decimal? SafetyPoint { get; set; }
        public decimal? ResultPoint { get; set; }
        public string? ResultGrade { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
