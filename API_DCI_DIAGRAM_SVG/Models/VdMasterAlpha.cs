using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VdMasterAlpha
    {
        public int Nbr { get; set; }
        public string? VdAddr { get; set; }
        public string? VdSort { get; set; }
        public string? VdAlphaCode { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
