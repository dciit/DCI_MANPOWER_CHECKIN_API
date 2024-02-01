using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class MpckLayout
    {
        public string LayoutCode { get; set; } = null!;
        public string? LayoutName { get; set; }
        public string? LayoutSubName { get; set; }
        public string? Factory { get; set; }
        public string? Line { get; set; }
        public string? SubLine { get; set; }
        public string? LayoutStatus { get; set; }
        public string? BypassMq { get; set; }
        public string? BypassSa { get; set; }
        public string? UpdateBy { get; set; }
        /// <summary>
        /// CURRENT_TIMESTAMP
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
