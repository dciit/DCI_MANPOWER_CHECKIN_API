using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhPalletGroup
    {
        public string GroupId { get; set; } = null!;
        public string? GroupName { get; set; }
        public string PalletType { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
