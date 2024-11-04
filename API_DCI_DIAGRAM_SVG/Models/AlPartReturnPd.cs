using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartReturnPd
    {
        public string Docno { get; set; } = null!;
        public string PrdYmd { get; set; } = null!;
        public string Shift { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string PartNo { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? PartDesc { get; set; }
        public string DataType { get; set; } = null!;
        public decimal? Qty { get; set; }
        public string? RefNo { get; set; }
        public string? Bgdept { get; set; }
        public string? Bgno { get; set; }
        public string? Remark { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string? DataStatus { get; set; }
    }
}
