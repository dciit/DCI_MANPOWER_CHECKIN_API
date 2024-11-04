using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViAlGsdPdActCost
    {
        public int? Fisy { get; set; }
        public string? Prdym { get; set; }
        public int? Wcno { get; set; }
        public string? Model { get; set; }
        public decimal? Monthlyplan { get; set; }
        public decimal Totalcost { get; set; }
        public decimal? Prdamt { get; set; }
        public decimal Laborcost { get; set; }
        public decimal? Laboramt { get; set; }
        public decimal Burdencost { get; set; }
        public decimal? Burdenamt { get; set; }
        public decimal Overheadcost { get; set; }
        public decimal? Overheadamt { get; set; }
    }
}
