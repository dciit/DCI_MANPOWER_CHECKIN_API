using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiPoListCustomer
    {
        public string PolistPoNo { get; set; } = null!;
        public string? PolistCurrency { get; set; }
        public DateTime? PolistDate { get; set; }
        public DateTime? PolistStartLoad { get; set; }
        public DateTime? PolistEndLoad { get; set; }
        public DateTime? PolistEtd { get; set; }
        public DateTime? PolistEta { get; set; }
        public DateTime? PolistEtaltd { get; set; }
        public string? PolistCustomer { get; set; }
        public string? PolistPort { get; set; }
        public string? PolistConsignee { get; set; }
        public string? PolistShipTo { get; set; }
        public decimal? PolistTotalAmount { get; set; }
        public string? PolistPathFile { get; set; }
        public string? PolistSaleConfrim { get; set; }
        public DateTime? PolistIssuedDt { get; set; }
        public string? PolistPlanConfrim { get; set; }
        public DateTime? PolistCheckdDt { get; set; }
        public string? PolistMgConfrim { get; set; }
        public DateTime? PolistMgApprovedDt { get; set; }
        public string? PolistAgmConfrim { get; set; }
        public DateTime? PolistAgmApprovedDt { get; set; }
        public string? PolistRemark { get; set; }
        public DateTime? PolistLastUpdate { get; set; }
    }
}
