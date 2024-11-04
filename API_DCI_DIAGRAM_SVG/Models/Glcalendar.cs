using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Glcalendar
    {
        public string FiscalYear { get; set; } = null!;
        public int Period { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public string? Enty { get; set; }
        public string? Description { get; set; }
        public string? ApClosed { get; set; }
        public string? ArClosed { get; set; }
        public string? FaClosed { get; set; }
        public string? IcClosed { get; set; }
        public string? SoClosed { get; set; }
        public string? GlClosed { get; set; }
        public string? YearClosed { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
