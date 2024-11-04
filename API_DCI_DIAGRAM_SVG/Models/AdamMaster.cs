using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdamMaster
    {
        public int Admid { get; set; }
        public string? Ipaddress { get; set; }
        public string? Description { get; set; }
        public int? NumberSlot { get; set; }
        public int? NumberChanel { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
