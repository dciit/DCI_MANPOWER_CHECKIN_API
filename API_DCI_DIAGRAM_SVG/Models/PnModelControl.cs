using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PnModelControl
    {
        public int Id { get; set; }
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public string? ModelType { get; set; }
        public string? Line { get; set; }
        public string? Status { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
