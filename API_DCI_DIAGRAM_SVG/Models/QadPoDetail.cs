using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class QadPoDetail
    {
        public int Id { get; set; }
        public string? PoNbr { get; set; }
        public DateTime? DueDate { get; set; }
        public string? VdAddr { get; set; }
        public string? VdSort { get; set; }
        public string? PodLine { get; set; }
        public string? PtPart { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtUm { get; set; }
        public decimal? PodQtyOrd { get; set; }
        public decimal? PodQtyRcvd { get; set; }
        public decimal? PodQtyRemain { get; set; }
        public decimal? PodPrice { get; set; }
    }
}
