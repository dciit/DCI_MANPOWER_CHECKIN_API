using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdTransactionDetail
    {
        public string Trdid { get; set; } = null!;
        public string? Trhdid { get; set; }
        public string? SerialNumber { get; set; }
        public string? Wiplocation { get; set; }
        public string? PartStatus { get; set; }
        public string? Remark { get; set; }
        public DateTime? Mfgdate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
