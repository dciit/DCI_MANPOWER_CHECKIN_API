using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlOutsideMaster
    {
        public string Apartno { get; set; } = null!;
        public string Avender { get; set; } = null!;
        public decimal? Aratio { get; set; }
        public string? Awhunit { get; set; }
        public string Bpartno { get; set; } = null!;
        public string Bvender { get; set; } = null!;
        public decimal? Bratio { get; set; }
        public string? Bwhunit { get; set; }
        public DateTime? Createdate { get; set; }
        public string? Createby { get; set; }
    }
}
