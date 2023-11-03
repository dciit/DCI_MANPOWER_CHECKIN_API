using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class LnsEquipmentCheckLog
    {
        public string Nbr { get; set; } = null!;
        public string? EqpId { get; set; }
        public string? EqpStatus { get; set; }
        public string? EqpRemark { get; set; }
        public DateTime? EqpNextCheckDt { get; set; }
        public DateTime? EqpCheckDt { get; set; }
        public string? EqpCheckBy { get; set; }
    }
}
