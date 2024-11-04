using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? MenuId { get; set; }
        public short? View { get; set; }
        public short? Add { get; set; }
        public short? Edit { get; set; }
        public short? Delete { get; set; }
        public short? Print { get; set; }
        public short? Approve { get; set; }
        public short? Confirm { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
