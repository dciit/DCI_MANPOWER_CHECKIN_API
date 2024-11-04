using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class EkbWipPartStockTitleMaster
    {
        public string MstSet { get; set; } = null!;
        public string MstHead { get; set; } = null!;
        public string MstCode { get; set; } = null!;
        public int? MstMerge { get; set; }
        public int? MstSort { get; set; }
        public int? MstFactory { get; set; }
    }
}
