using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoDailyStock
    {
        public int Int { get; set; }
        public string? DoPart { get; set; }
        public decimal? DoStock { get; set; }
        public string? DoUm { get; set; }
        public DateTime? DoUpdate { get; set; }
    }
}
