using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsPlanReportResultScrSubError
    {
        public string Nbr { get; set; } = null!;
        public string? Dataset { get; set; }
        public string? Ymd { get; set; }
        public string? MasterOperationCode { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public double? ReportQty { get; set; }
        public DateTime CreateDt { get; set; }
    }
}
