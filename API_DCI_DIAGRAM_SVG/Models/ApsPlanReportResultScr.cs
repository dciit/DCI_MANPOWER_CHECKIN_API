using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ApsPlanReportResultScr
    {
        public string Nbr { get; set; } = null!;
        public string? Dataset { get; set; }
        public string? Ymd { get; set; }
        public string? PlanCode { get; set; }
        public string? MainResource { get; set; }
        public string? MasterOperationCode { get; set; }
        public string? MainCode { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public double? PlanQty { get; set; }
        public int? SetupTime { get; set; }
        public DateTime? PrdStartDt { get; set; }
        public DateTime? PrdEndDt { get; set; }
        public int? PrdTime { get; set; }
        public int? LeadTime { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public int? LateNess { get; set; }
        public string? Comments { get; set; }
        public string? PlanStatus { get; set; }
        public DateTime? ReportDt { get; set; }
        public double? ReportQty { get; set; }
        public DateTime CreateDt { get; set; }
    }
}
