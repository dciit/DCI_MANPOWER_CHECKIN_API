using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PlPalletdci
    {
        public string Plno { get; set; } = null!;
        public string Pltype { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime? InsertDate { get; set; }
    }
}
