using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AiInspectUser
    {
        public string UserId { get; set; } = null!;
        public string? EmpCode { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Permission { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? VendorId { get; set; }
        public DateTime? LastActive { get; set; }
        public string? Approver { get; set; }
    }
}
