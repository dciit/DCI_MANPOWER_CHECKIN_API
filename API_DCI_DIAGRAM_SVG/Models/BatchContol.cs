using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class BatchContol
    {
        public int Id { get; set; }
        public string? BatchSystem { get; set; }
        public string? BatchSettingType { get; set; }
        public string? BatchSettingValue { get; set; }
        public string? BatchType { get; set; }
        public string? BatchExecute { get; set; }
        public DateTime? BatchNext { get; set; }
        public DateTime? BatchLast { get; set; }
        public string? BatchStatus { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
    }
}
