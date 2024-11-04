using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdEmployeeLine
    {
        public string EmpCode { get; set; } = null!;
        public string PdLine { get; set; } = null!;
        public string? PdLineName { get; set; }
        public string? PdLocation { get; set; }
        public string? PdLocationName { get; set; }
        public string? PdFactory { get; set; }
        public string? PdMachineNo { get; set; }
        public string? PdMachineName { get; set; }
        public string? PdAndon { get; set; }
        public string? PdRemark1 { get; set; }
        public string? PdRemark2 { get; set; }
        public string? PdRemark3 { get; set; }
        public string? PdRemark4 { get; set; }
        public string? PdRemark5 { get; set; }
        public string? PdUpdateBy { get; set; }
        public DateTime? PdUpdateDate { get; set; }
    }
}
