using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlWcMaster
    {
        public string Wcno { get; set; } = null!;
        public string? Sname { get; set; }
        public string? Name { get; set; }
        public string? GrpCode { get; set; }
        public string? Factory { get; set; }
        public string? Product { get; set; }
        public string? LineType { get; set; }
        public string? LineSub { get; set; }
        public string? LineName { get; set; }
        /// <summary>
        /// Line capacity per day
        /// </summary>
        public decimal Capacity { get; set; }
        public int? MaxStock { get; set; }
        public int? MinStock { get; set; }
        public string? LockIssue { get; set; }
        public string? QcSampling { get; set; }
        public string? Kind { get; set; }
    }
}
