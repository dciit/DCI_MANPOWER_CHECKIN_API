using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class SupplierDeliveryRecord
    {
        public string Nbr { get; set; } = null!;
        public string? Vender { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DatetimeIn { get; set; }
        public DateTime? DatetimeOut { get; set; }
    }
}
