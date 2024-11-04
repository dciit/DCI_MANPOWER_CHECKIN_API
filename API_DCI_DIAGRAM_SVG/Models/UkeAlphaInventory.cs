using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UkeAlphaInventory
    {
        public string Model { get; set; } = null!;
        public string Pltype { get; set; } = null!;
        public int Cnt { get; set; }
        /// <summary>
        /// YYYYMMDD
        /// </summary>
        public string Ymd { get; set; } = null!;
        public DateTime? UpdateDt { get; set; }
    }
}
