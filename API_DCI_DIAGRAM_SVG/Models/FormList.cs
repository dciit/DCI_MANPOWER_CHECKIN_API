using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FormList
    {
        public int FormId { get; set; }
        public int? SystemId { get; set; }
        public string? FormName { get; set; }
        public string? FormUrl { get; set; }
        public string? FormDescription { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
