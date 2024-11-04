using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletRoleMenu
    {
        public string RoleCode { get; set; } = null!;
        public string MenuCode { get; set; } = null!;
        public string? ActAccess { get; set; }
        public string? ActRead { get; set; }
        public string? ActEdit { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
