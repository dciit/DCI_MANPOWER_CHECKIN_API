using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdWipHold
    {
        public string DocNo { get; set; } = null!;
        public DateTime Pddate { get; set; }
        public string Shift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Drawing { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public int? HoldQty { get; set; }
        public int? Okqty { get; set; }
        public int? Ngqty { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? Qcstd { get; set; }
        public string? Qcresult { get; set; }
        public string? Qcprocess { get; set; }
        public string? Qctools { get; set; }
        public string? QcPdno { get; set; }
        public string? QcToolsLiftDress { get; set; }
        public string? HoldBy { get; set; }
        public DateTime? HoldDate { get; set; }
        public string? Okby { get; set; }
        public DateTime? Okdate { get; set; }
        public string? Ngby { get; set; }
        public DateTime? Ngdate { get; set; }
        public string? PrdBy { get; set; }
        public DateTime? PrdDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
