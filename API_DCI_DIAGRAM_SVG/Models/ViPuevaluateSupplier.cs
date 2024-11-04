using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPuevaluateSupplier
    {
        public int Id { get; set; }
        public string? Einvoice { get; set; }
        public string? RndInvnoSup { get; set; }
        public DateTime RndDate { get; set; }
        public string? RndTime { get; set; }
        public string? Comment { get; set; }
        public string? Remark { get; set; }
        public decimal Point { get; set; }
        public string Type { get; set; } = null!;
        public string InputType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? VdAddr { get; set; }
        public string? VdSort { get; set; }
        public string? UpdateName { get; set; }
    }
}
