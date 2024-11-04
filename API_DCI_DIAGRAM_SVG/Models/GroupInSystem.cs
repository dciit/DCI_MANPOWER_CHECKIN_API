using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class GroupInSystem
    {
        public int Id { get; set; }
        public int? SystemId { get; set; }
        public int? GroupId { get; set; }
        public short? IsActive { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
