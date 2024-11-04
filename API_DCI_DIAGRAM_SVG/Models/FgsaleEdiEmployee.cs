using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiEmployee
    {
        public string EmpId { get; set; } = null!;
        public string? EmpName { get; set; }
        public string? EmpEmail { get; set; }
        public string? EmpPassword { get; set; }
        public string? EmpDepartment { get; set; }
    }
}
