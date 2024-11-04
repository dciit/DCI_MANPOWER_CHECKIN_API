using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PlSaleDelser
    {
        public string Plno { get; set; } = null!;
        public string Pltype { get; set; } = null!;
        public string Plgrp { get; set; } = null!;
        public string Dono { get; set; } = null!;
        public string Ivno { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Customer { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
