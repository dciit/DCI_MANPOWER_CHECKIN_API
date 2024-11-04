using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlAuthRequest
    {
        public string Nbr { get; set; } = null!;
        public string? Code { get; set; }
        public string? AlGroupId { get; set; }
        public string? ReqAction { get; set; }
        public string? ReqStatus { get; set; }
        public string? ReqBy { get; set; }
        public DateTime? ReqDate { get; set; }
        public string? ReqMg { get; set; }
        public DateTime? ReqMgdate { get; set; }
        public string? ReqGm { get; set; }
        public DateTime? ReqGmdate { get; set; }
        public string? RecBy { get; set; }
        public DateTime? RecDate { get; set; }
        public string? RecMg { get; set; }
        public DateTime? RecMgdate { get; set; }
        public string? RecGm { get; set; }
        public DateTime? RecGmdate { get; set; }
        public string? InchargeBy { get; set; }
        public DateTime? InchargeDate { get; set; }
        public string? FinishBy { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
