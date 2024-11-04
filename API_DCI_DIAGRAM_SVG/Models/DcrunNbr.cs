using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DcrunNbr
    {
        public int FormatId { get; set; }
        public string DocKey { get; set; } = null!;
        public string? DocPrefix { get; set; }
        public string? Remark { get; set; }
        public int YearNbrPrefix { get; set; }
        public int MonthNbrPrefix { get; set; }
        public int DayNbrPrefix { get; set; }
        public int FormatNbr { get; set; }
        public string ResetOption { get; set; } = null!;
        public int NextId { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
