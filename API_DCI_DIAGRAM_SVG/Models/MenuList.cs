using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class MenuList
    {
        public int Id { get; set; }
        public string? MenuName { get; set; }
        public string? MenuUrl { get; set; }
        public string? MenuIcon { get; set; }
        public int? MenuRoot { get; set; }
        public int? MenuOrder { get; set; }
        public short? IsActive { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
