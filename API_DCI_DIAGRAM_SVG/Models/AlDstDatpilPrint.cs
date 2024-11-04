using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlDstDatpilPrint
    {
        public string Nbr { get; set; } = null!;
        public string? Idate { get; set; }
        public string? Docno { get; set; }
        public string? PrintBy { get; set; }
        public DateTime? PrintDate { get; set; }
    }
}
