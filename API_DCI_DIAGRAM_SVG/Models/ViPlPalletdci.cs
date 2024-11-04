using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViPlPalletdci
    {
        public string Plno { get; set; } = null!;
        public int? Leng { get; set; }
        public string? Plrack { get; set; }
        public string Pltype { get; set; } = null!;
        public string? Plgrp { get; set; }
        public string Model { get; set; } = null!;
        public DateTime? InsertDate { get; set; }
    }
}
