using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiPrivilegeGroup
    {
        public string EmpId { get; set; } = null!;
        public string GrpId { get; set; } = null!;
        public string? GrpName { get; set; }
        public string? GrpAction { get; set; }
    }
}
