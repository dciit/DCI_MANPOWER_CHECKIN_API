using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VendorRunNbr
    {
        public int Id { get; set; }
        public string? Chr1st { get; set; }
        public string? Chr1stNbr { get; set; }
        public string? Chr2nd { get; set; }
        public int? Chr2ndNbr { get; set; }
        public int? NextId { get; set; }
        public int? PadNbr { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
