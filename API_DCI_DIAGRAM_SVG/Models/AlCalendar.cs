using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlCalendar
    {
        public DateTime Pddate { get; set; }
        public bool? Holiday { get; set; }
        public bool? Production { get; set; }
        public bool? Delivery { get; set; }
        public DateTime? Updatedate { get; set; }
        public string? Updateby { get; set; }
    }
}
