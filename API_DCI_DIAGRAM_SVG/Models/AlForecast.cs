using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlForecast
    {
        public string Drawing { get; set; } = null!;
        public string VendorCode { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string ForecastType { get; set; } = null!;
        public DateTime ForecastDate { get; set; }
        public decimal? ForecastQty { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
