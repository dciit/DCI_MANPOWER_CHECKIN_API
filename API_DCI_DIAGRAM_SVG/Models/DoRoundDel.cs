using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoRoundDel
    {
        public int RndId { get; set; }
        public int DryId { get; set; }
        public DateTime RndDate { get; set; }
        public string RndTime { get; set; } = null!;
        public string? RndInvno { get; set; }
        public string? RndLotno { get; set; }
        public int RndStatus { get; set; }
        public string? RndInvnoSup { get; set; }
        public DateTime? RndInvnoSupDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Remark { get; set; }
    }
}
