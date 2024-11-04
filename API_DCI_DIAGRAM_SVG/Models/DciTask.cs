using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DciTask
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; } = null!;
        public string TaskDesc { get; set; } = null!;
        public DateTime? TaskDuedate { get; set; }
        public int? TaskWarning { get; set; }
        public string TaskPriority { get; set; } = null!;
        public string? TaskAssign { get; set; }
        public string TaskStatus { get; set; } = null!;
        public string TaskCreateBy { get; set; } = null!;
        public DateTime TaskCreateDt { get; set; }
        public string TaskUpdateBy { get; set; } = null!;
        public DateTime TaskUpdateDt { get; set; }
    }
}
