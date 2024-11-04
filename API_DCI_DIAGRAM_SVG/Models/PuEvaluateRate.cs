using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PuEvaluateRate
    {
        public int Id { get; set; }
        public decimal? MinScore { get; set; }
        public decimal? MaxScore { get; set; }
        public string? Grade { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
