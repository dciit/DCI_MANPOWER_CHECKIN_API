using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPostpone
    {
        public int Id { get; set; }
        public string? VdAddr { get; set; }
        public string? PtPart { get; set; }
        public DateTime? DoDate { get; set; }
        public decimal? DoRequest { get; set; }
        public decimal? DoConfirm { get; set; }
        public decimal? DoReceive { get; set; }
        public decimal? DoPostpone1 { get; set; }
        public string? DoRemark { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
