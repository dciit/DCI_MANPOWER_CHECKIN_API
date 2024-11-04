using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PdFgbypassDataIoT
    {
        public int Id { get; set; }
        public string? Wcno { get; set; }
        public string? Model { get; set; }
        public string? Serialno { get; set; }
        public string? Modelcode { get; set; }
        public DateTime? Prddate { get; set; }
        public string? Prdtype { get; set; }
        public string? Massprod { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Sendbit { get; set; }
        public DateTime? Senddate { get; set; }
    }
}
