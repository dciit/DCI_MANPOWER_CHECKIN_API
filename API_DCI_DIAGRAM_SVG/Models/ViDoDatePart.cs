using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViDoDatePart
    {
        public int Nbr { get; set; }
        public int DryId { get; set; }
        public DateTime DoDate { get; set; }
        public string? PtPart { get; set; }
        public decimal DoRequest { get; set; }
        public decimal DoConfirm { get; set; }
        public decimal DoReceive { get; set; }
        public decimal DoRemain { get; set; }
        public int DoStatus { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Remark1 { get; set; }
        public string? Remark2 { get; set; }
        public string? Remark3 { get; set; }
        public string? Remark4 { get; set; }
        public string? Remark5 { get; set; }
        public string SupplierNo { get; set; } = null!;
        public string? VdSort { get; set; }
    }
}
