using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoVendorHoliday
    {
        public string VdAddr { get; set; } = null!;
        public DateTime HolidayDate { get; set; }
        public string? HolidayDetail { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
