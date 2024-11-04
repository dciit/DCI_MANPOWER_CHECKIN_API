using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AdamSlot
    {
        public int Adsid { get; set; }
        public int? Admid { get; set; }
        public int? SlotNumber { get; set; }
        public string? Description { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
