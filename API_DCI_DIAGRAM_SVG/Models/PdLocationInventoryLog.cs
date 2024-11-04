using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdLocationInventoryLog
    {
        public int Id { get; set; }
        public string? LocationName { get; set; }
        public string? TagId { get; set; }
        public decimal? Qty { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
