using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiCalLeadTime
    {
        public string CustomerCode { get; set; } = null!;
        public string? CustomerName { get; set; }
        public int? CustomerLoadday { get; set; }
        public int? CustomerStatLoad { get; set; }
        public int? CustomerEndLoad { get; set; }
        public int? CustomerEtd { get; set; }
        public int? CustomerEta { get; set; }
        public int? CustomerLtd { get; set; }
    }
}
