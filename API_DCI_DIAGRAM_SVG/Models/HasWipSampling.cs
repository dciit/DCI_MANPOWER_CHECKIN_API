using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class HasWipSampling
    {
        public string Nbr { get; set; } = null!;
        public string? RefDocno { get; set; }
        public DateTime? Pddate { get; set; }
        public string? Shift { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public string? Drawing { get; set; }
        public string? Cm { get; set; }
        public string? JudegementResult { get; set; }
        public int? JudegementQty { get; set; }
        public string? HoldLine { get; set; }
        public string? HoldMachine { get; set; }
        public string? HoldJig { get; set; }
        public string? HoldBasketQty { get; set; }
        public string? HoldProblemDetail { get; set; }
        public string? HoldStandard { get; set; }
        public string? HoldActual { get; set; }
        public string? HoldStatus { get; set; }
        public string? HoldBy { get; set; }
        public DateTime? HoldDate { get; set; }
        public string? UnholdLineProblem { get; set; }
        public string? UnholdPipe { get; set; }
        public string? UnholdProductionBy { get; set; }
        public string? UnholdProblemDetail { get; set; }
        public string? InspectionBy { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? HoldJud { get; set; }
        public string? HoldJudVal { get; set; }
        public string? UnholdPoint { get; set; }
        public string? UnholdPointVal { get; set; }
        public string? UnholdProblem { get; set; }
        public string? UnholdJud { get; set; }
        public int? UnholdJudOkVal { get; set; }
        public int? UnholdJudNgVal { get; set; }
        public string? UnholdProcessProblem { get; set; }
        public string? UnholdProblemPd { get; set; }
        public string? UnholdProblemQc { get; set; }
        public int? UnholdJudScrapVal { get; set; }
        public string? UnholdJudOtherVal { get; set; }
    }
}
