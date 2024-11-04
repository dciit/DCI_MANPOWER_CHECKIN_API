using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdjSerialDataDit
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? SerialNo { get; set; }
        public DateTime? Pddate { get; set; }
        public TimeSpan? Pdtime { get; set; }
        public string? LineNo { get; set; }
        public int? Send { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
