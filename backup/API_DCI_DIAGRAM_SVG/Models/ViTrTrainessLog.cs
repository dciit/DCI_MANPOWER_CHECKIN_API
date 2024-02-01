using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Keyless]
    public partial class ViTrTrainessLog
    {
        [Column("EXAM_SET_NAME")]
        [StringLength(150)]
        public string? ExamSetName { get; set; }
        [Column("EXAM_SET_CODE")]
        [StringLength(50)]
        public string? ExamSetCode { get; set; }
        [Column("SCHEDULE_CODE")]
        [StringLength(50)]
        public string? ScheduleCode { get; set; }
        [Column("COURSE_CODE")]
        [StringLength(50)]
        public string? CourseCode { get; set; }
        public int? Score { get; set; }
        public int? ScoreTotal { get; set; }
        [StringLength(50)]
        public string? Result { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string? Status { get; set; }
        [Column("CBY")]
        [StringLength(50)]
        public string? Cby { get; set; }
        [Column("CDATE", TypeName = "datetime")]
        public DateTime? Cdate { get; set; }
        [Column("EMP_CODE")]
        [StringLength(50)]
        public string? EmpCode { get; set; }
        [Column("MQ_NO")]
        [StringLength(50)]
        public string? MqNo { get; set; }
        [Column("SCHEDULE_START", TypeName = "datetime")]
        public DateTime? ScheduleStart { get; set; }
        [Column("SCHEDULE_END", TypeName = "datetime")]
        public DateTime? ScheduleEnd { get; set; }
        [Column("COURSE_PER_PERSON", TypeName = "decimal(18, 2)")]
        public decimal? CoursePerPerson { get; set; }
    }
}
