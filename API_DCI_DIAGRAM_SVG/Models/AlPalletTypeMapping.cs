using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPalletTypeMapping
    {
        public string Plgrp { get; set; } = null!;
        public string Pltype { get; set; } = null!;
        public string? Plcode { get; set; }
        public string? RackControl { get; set; }
        public string? Plqty { get; set; }
        public string? Pllevel { get; set; }
        public string? Remark { get; set; }
    }
}
