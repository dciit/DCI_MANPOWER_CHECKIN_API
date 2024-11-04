using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UserList
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? SupplierNo { get; set; }
        public string EmpCode { get; set; } = null!;
        public int? PwdExpired { get; set; }
        public short? IsActive { get; set; }
        public DateTime? PwdLastUpdate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? AccessCode { get; set; }
    }
}
