using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiLog
    {
        public string? EmpId { get; set; }
        public int LogId { get; set; }
        public string LogAction { get; set; } = null!;
        public string? LogItemNo { get; set; }
        public string? InvoiceNo { get; set; }
        public int? Version { get; set; }
        public DateTime LogDateTime { get; set; }
        public DateTime? Podate { get; set; }
        public string? Customer { get; set; }
        public string? Port { get; set; }
        public string? Remark { get; set; }
        public string? ModelDci { get; set; }
        public string? ModelCustomer { get; set; }
        public string? Pltype { get; set; }
        public string? Cm { get; set; }
        public string? Description { get; set; }
        public string? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? StartLoad { get; set; }
        public DateTime? EndLoad { get; set; }
        public DateTime? Etd { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? Ltd { get; set; }
    }
}
