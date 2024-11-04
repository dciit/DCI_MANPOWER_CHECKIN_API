using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiCustomerPort
    {
        public string CustomerCode { get; set; } = null!;
        public string PortofDischarge { get; set; } = null!;
        public string? PortTransBy { get; set; }
        public DateTime? PortAddDate { get; set; }
        public string? PortStatus { get; set; }
    }
}
