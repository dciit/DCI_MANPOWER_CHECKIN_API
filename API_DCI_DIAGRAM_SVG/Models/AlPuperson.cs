using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPuperson
    {
        public string Vender { get; set; } = null!;
        public string Empcode { get; set; } = null!;
        public string? Empname { get; set; }
        public string? Periods { get; set; }
    }
}
