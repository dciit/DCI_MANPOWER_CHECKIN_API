using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViTrTrainessLog
    {
        public string? ExamSetName { get; set; }
        public string? ExamSetCode { get; set; }
        public string? ScheduleCode { get; set; }
        public string? CourseCode { get; set; }
        public int? Score { get; set; }
        public int? ScoreTotal { get; set; }
        public string? Result { get; set; }
        public string? Status { get; set; }
        public string? Cby { get; set; }
        public DateTime? Cdate { get; set; }
        public string? EmpCode { get; set; }
        public string? MqNo { get; set; }
        public DateTime? ScheduleStart { get; set; }
        public DateTime? ScheduleEnd { get; set; }
        public decimal? CoursePerPerson { get; set; }
    }
}
