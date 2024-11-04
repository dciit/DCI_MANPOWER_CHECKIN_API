using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class SupplierDeliveryMaster
    {
        public string Vender { get; set; } = null!;
        public string TimeIn { get; set; } = null!;
        public string TimeOut { get; set; } = null!;
        public int? TotalMin { get; set; }
        public int? CapLoad { get; set; }
        public int? OrderNo { get; set; }
        public bool? LoadArea1 { get; set; }
        public bool? LoadArea2 { get; set; }
        public bool? LoadArea3 { get; set; }
        public bool? LoadArea4 { get; set; }
        public bool? LoadArea5 { get; set; }
        public bool? LoadMethod1 { get; set; }
        public bool? LoadMethod2 { get; set; }
        public bool? LoadMethod3 { get; set; }
    }
}
