using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UserRelation
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? UserParent { get; set; }
        public string? UserEmail { get; set; }
        public string? EmpCode { get; set; }
        public string? SupplierList { get; set; }
    }
}
