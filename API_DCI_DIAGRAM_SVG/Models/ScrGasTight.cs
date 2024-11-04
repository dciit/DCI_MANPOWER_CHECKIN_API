using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ScrGasTight
    {
        public int Id { get; set; }
        public string Serial { get; set; } = null!;
        public string? ModelCode { get; set; }
        public string? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
