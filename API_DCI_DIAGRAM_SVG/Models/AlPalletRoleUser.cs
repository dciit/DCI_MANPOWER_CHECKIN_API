using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletRoleUser
    {
        public string RoleCode { get; set; } = null!;
        public string EmpCode { get; set; } = null!;
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
