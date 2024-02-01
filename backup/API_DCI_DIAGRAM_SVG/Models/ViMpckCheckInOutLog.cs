using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViMpckCheckInOutLog
    {
        public string Nbr { get; set; } = null!;
        public string? ObjCode { get; set; }
        public string? EmpCode { get; set; }
        public string? EmpName { get; set; }
        public string? Posit { get; set; }
        public string? Ckdate { get; set; }
        public string? Ckshift { get; set; }
        public string? Cktype { get; set; }
        public DateTime? CkdateTime { get; set; }
    }
}
