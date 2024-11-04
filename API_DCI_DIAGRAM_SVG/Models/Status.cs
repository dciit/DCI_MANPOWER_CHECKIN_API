using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Status
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
        public string? StatusGroup { get; set; }
        public string? Remarks { get; set; }
    }
}
