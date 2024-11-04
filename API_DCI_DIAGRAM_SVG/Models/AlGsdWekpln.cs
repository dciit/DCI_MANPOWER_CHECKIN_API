using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlGsdWekpln
    {
        public int? Wcno { get; set; }
        public int? Sebango { get; set; }
        public string? Model { get; set; }
        public string? Prdmodel { get; set; }
        public string? Pilot { get; set; }
        public string? Prdym { get; set; }
        /// <summary>
        /// Production packet
        /// </summary>
        public string? PrdDate { get; set; }
        /// <summary>
        /// Decision date
        /// </summary>
        public string? VaridDate { get; set; }
        /// <summary>
        /// How many day in a week
        /// </summary>
        public int? DayNum { get; set; }
        public int? Weekno { get; set; }
        public int? PrdplanTotal { get; set; }
        public int? PrdplanRun { get; set; }
        public int? PrdadjTotal { get; set; }
        public int? PrdadjRun { get; set; }
        public int? PrdttloldTotal { get; set; }
        public int? PrdttloldRun { get; set; }
        public DateTime? DataDate { get; set; }
    }
}
