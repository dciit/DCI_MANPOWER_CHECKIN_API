using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViUserGroup
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string EmpCode { get; set; } = null!;
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
    }
}
