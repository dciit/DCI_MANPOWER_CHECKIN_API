using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletRoleUserLog
    {
        public string Nbr { get; set; } = null!;
        public string? RoleCode { get; set; }
        public string? EmpCode { get; set; }
        public string? ActionType { get; set; }
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
