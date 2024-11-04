using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoSupplierCalendar
    {
        public string SupplierCode { get; set; } = null!;
        public DateTime DoDate { get; set; }
        public string? IsHoliday { get; set; }
        public string? Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
