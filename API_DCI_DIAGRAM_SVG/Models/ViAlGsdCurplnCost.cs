using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViAlGsdCurplnCost
    {
        public int? Fisy { get; set; }
        public string Prdym { get; set; } = null!;
        public int Wcno { get; set; }
        public string Model { get; set; } = null!;
        public decimal? Monthlyplan { get; set; }
        public decimal Totalcost { get; set; }
        public decimal? Prdamt { get; set; }
        public decimal Laborcost { get; set; }
        public decimal? Laboramt { get; set; }
        public decimal Burdencost { get; set; }
        public decimal? Burdenamt { get; set; }
        public decimal Overheadcost { get; set; }
        public decimal? Overheadamt { get; set; }
        public DateTime? Cdate { get; set; }
    }
}
