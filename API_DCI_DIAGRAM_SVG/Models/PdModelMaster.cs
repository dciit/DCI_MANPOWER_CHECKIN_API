using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdModelMaster
    {
        public int ModelMasterId { get; set; }
        public string? PcCode { get; set; }
        public string? LineName { get; set; }
        public string? ModelNo { get; set; }
        public string? Mqno { get; set; }
    }
}
