using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PtPsStructure
    {
        public string BomParent { get; set; } = null!;
        public string PsComponent { get; set; } = null!;
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public decimal? PsQty { get; set; }
        public string? PtUm { get; set; }
        public DateTime? PsStart { get; set; }
        public DateTime? PsEnd { get; set; }
        public DateTime? PsModDate { get; set; }
        public string? PsUserid { get; set; }
        public string? PtStatus { get; set; }
        public string? PtIssPol { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
